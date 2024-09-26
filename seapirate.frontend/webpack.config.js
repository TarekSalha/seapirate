const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: './src/game.js',  // Entry point for your game's main JS file
  output: {
    filename: 'bundle.js',  // Output all bundled JS into a single file
    path: path.resolve(__dirname, 'dist'),  // Output to the 'dist' folder
    clean: true,  // Clean the 'dist' folder before each build
  },
  mode: 'development',  // Use 'development' mode (use 'production' for production builds)
  module: {
    rules: [
      {
        test: /\.js$/,  // Apply this rule to all .js files
        exclude: /node_modules/,  // Skip node_modules
        use: {
          loader: 'babel-loader',  // Use Babel loader
          options: {
            presets: ['@babel/preset-env'],  // Use Babel preset to transpile ES6 to ES5
          },
        },
      },
      {
        test: /\.(ico|png|jpg|jpeg|gif|svg)$/,  // For images, handle them using file-loader
        use: [
          {
            loader: 'file-loader',
            options: {
              name: '[name].[ext]',  // Output file name and extension
              outputPath: 'assets/',  // Place all images in the 'assets/' folder
            },
          },
        ],
      },
    ],
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './src/index.html',
    }),
  ],
  devServer: {
    static: {
      directory: path.resolve(__dirname, 'dist'),  // Serve files from 'dist' folder
    },
    open: true,  // Automatically open the browser
    hot: true,  // Enable hot module reloading
  },
};
