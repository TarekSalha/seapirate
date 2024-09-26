namespace SeaPirate.Infrastructure;

using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Sql;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Insights;
using Pulumi.AzureNative.Sql.Inputs;
using Pulumi.AzureNative.OperationalInsights;

class SeaPirateApp : Stack
{
    public SeaPirateApp()
    {
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("seapirate-rg");

        // Storage Account for static files (game assets, logs, etc.)
        var storageAccount = new StorageAccount("seapiratestorage", new StorageAccountArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Sku = new Pulumi.AzureNative.Storage.Inputs.SkuArgs
            {
                Name = Pulumi.AzureNative.Storage.SkuName.Standard_LRS
            },
            Kind = Pulumi.AzureNative.Storage.Kind.StorageV2,
            Location = resourceGroup.Location,
        });

        // Create an Azure SQL Server
        var sqlServer = new Server("seapirate-sqlserver", new ServerArgs
        {
            ResourceGroupName = resourceGroup.Name,
            AdministratorLogin = "chefpirate",     // Change this
            AdministratorLoginPassword = "P!ratesAre2Hungry",  // Change this
            Location = resourceGroup.Location
        });

        // Create an Azure SQL Database
        var sqlDatabase = new Database("seapirate-db", new DatabaseArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ServerName = sqlServer.Name,
            Sku = new SkuArgs
            {
                Name = "S0"  // Pricing tier (can be scaled later)
            }
        });

        // Connection string for the SQL Database
        var connectionString = Output.Tuple(sqlServer.Name, sqlDatabase.Name).Apply(names =>
            $"Server=tcp:{names.Item1}.database.windows.net,1433;Initial Catalog={names.Item2};Persist Security Info=False;User ID=chefpirate;Password=P!ratesAre2Hungry;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        // Create an Azure App Service Plan for the ASP.NET Core backend
        var appServicePlan = new AppServicePlan("seapirate-appservice-plan", new AppServicePlanArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Sku = new  Pulumi.AzureNative.Web.Inputs.SkuDescriptionArgs
            {
                Tier = "Free",  // You can scale this up as needed
                Name = "F1"
            },
            Location = resourceGroup.Location
        });

        // Create an Azure App Service for the ASP.NET Core Backend
        var appService = new WebApp("seapirate-backend", new WebAppArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ServerFarmId = appServicePlan.Id,
            SiteConfig = new Pulumi.AzureNative.Web.Inputs.SiteConfigArgs
            {
                AppSettings = new[]
                {
                    new Pulumi.AzureNative.Web.Inputs.NameValuePairArgs
                    {
                        Name = "ConnectionStrings__DefaultConnection",
                        Value = connectionString
                    },
                    new Pulumi.AzureNative.Web.Inputs.NameValuePairArgs
                    {
                        Name = "WEBSITE_RUN_FROM_PACKAGE",
                        Value = "1"
                    }
                }
            },
            Location = resourceGroup.Location
        });

        // Create Azure Static Web App for hosting the Phaser frontend
        var staticWebApp = new StaticSite("seapirate-frontend", new StaticSiteArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new Pulumi.AzureNative.Web.Inputs.SkuDescriptionArgs
            {
                Name = "Free"  // Can be scaled to "Standard" for more features
            },
            RepositoryUrl = "https://github.com/your-repo/seapirate-frontend",  // Replace with your GitHub repo URL
            Branch = "main",  // Branch for automatic deployments
            BuildProperties = new Pulumi.AzureNative.Web.Inputs.StaticSiteBuildPropertiesArgs
            {
                ApiLocation = "api",  // Assuming the API is in /api
                AppLocation = "frontend",  // Assuming the Phaser frontend is in /frontend
                OutputLocation = "dist"  // Location where the built frontend assets are stored
            }
        });

        var logAnalyticsWorkspace = new Workspace("seapirate-loganalyticsworkspace", new WorkspaceArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new Pulumi.AzureNative.OperationalInsights.Inputs.WorkspaceSkuArgs
            {
                Name = WorkspaceSkuNameEnum.PerGB2018
            },
            RetentionInDays = 30,
        });

        // Create Application Insights for backend monitoring
        var appInsights = new Component("seapirate-appinsights", new ComponentArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ApplicationType = "web",
            Kind = "web",
            Location = resourceGroup.Location,
            IngestionMode = "LogAnalytics",
            WorkspaceResourceId = logAnalyticsWorkspace.Id
        });

        // Output the backend URL, frontend URL, and SQL connection string
        this.BackendUrl = appService.DefaultHostName;
        this.FrontendUrl = staticWebApp.DefaultHostname;
        this.SqlConnectionString = connectionString;
        this.StorageAccountName = storageAccount.Name;
    }

    [Output] public Output<string> BackendUrl { get; set; }
    [Output] public Output<string> FrontendUrl { get; set; }
    [Output] public Output<string> SqlConnectionString { get; set; }
    [Output] public Output<string> StorageAccountName { get; set; }
}
