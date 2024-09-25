# Pirate Economy Simulation Game

## Overview
You play as a pirate on an island, raiding other islands to gather resources, build warships, and expand your empire. Other islands on the map produce resources regularly, with varying efficiency. Your goal is to strategically raid islands, build your economy, and dominate the seas through combat and resource management.

---

## 1. Game Map and Island Distribution
- **Map Coordinates**: Islands are randomly distributed on a 100x100 grid.
  - Each coordinate point represents 1 nautical mile.
  - The player's island starts at a random location.
- **Islands**: 
  - Each island specializes in 2 randomly selected resources with increased efficiency (ranging from 1.5x to 3x).
  - 2 other randomly selected resources are produced with decreased efficiency (0.5x).

---

## 2. Resources
Islands produce 6 primary resources at different rates:
- **Wood**
- **Stone**
- **Iron Ore**
- **Coal**
- **Gold**
- **Food**

### 2.1 Production Rates
- **Baseline Production**: Each resource facility produces 1 unit of its resource per minute at level 0.
  - **Level 0**: Produces 0.5x the baseline.
  - **Level 1**: Produces at 1x (baseline).
  - **Levels 2-5**: Produce at increased efficiency (1.5x, 2x, 2.5x, 3x).
- **Increased Efficiency**: Specialization increases the production of 2 resources by random factors of 1.5, 2, 2.5, or 3.
- **Decreased Efficiency**: 2 resources are produced at 0.5x the normal rate.

### 2.2 Storage Limits
- **Storehouse Capacity**: The storehouse has a global limit per island.
  - **Level 0**: 100 units total (all resources combined).
  - **Each additional level**: Adds +100 units to the global capacity.

If the storage limit is reached, all production halts until the storage is cleared by using or trading resources.

### 2.3 Resource Consumption
- **Gold**: Required for creating army/navy units (except militia and corvettes).
- **Wood**: Used for archers, spearmen, all ships, buildings, and siege weapons.
- **Stone**: Needed for militia, corvette ships, buildings, and mangonels.
- **Food**: Required for army creation (minimal) and for raiding convoys (fuel for travel).
  - Travel cost: 1 unit of food per ship per nautical mile.
- **Coal**: Used for swordsmen, spearmen, siege weapons, advanced ships, and tech research.
- **Iron Ore**: Required for swordsmen, spearmen, siege weapons, advanced ships, and tech research.

### 2.4 Resource Trade
- Resources can be traded at the **Harbour**.
  - Initial exchange rate: 4:1.
  - Exchange rates can be improved through tech research down to 3:1 and later 2:1.

---

## 3. Island Buildings
Each neutral island has the following buildings with levels ranging from 0 to 5:
1. **Storehouse**: Determines total storage capacity.
2. **City Wall**: Increases island defense (Defense = Wall Level * 100).
3. **Watchtower**: Increases sight range to detect incoming ships and convoys.
4. **Resource Facilities**: Mines, farms, and camps for resource production (wood, stone, coal, gold, iron, food).
5. **Construction Crane**: Allows pirates to build and upgrade other structures (level 0 for neutral islands).

### 3.1 Pirate-Exclusive Buildings
Pirates (players and AI) can build additional structures:
- **University**: Unlocks research and technology.
- **Shipyard**: Researches new ship types and increases ship capacity.
- **Harbour**: Controls convoys and raids. The level determines the maximum number of ships in a convoy.
- **Forge**: Builds cannons, mangonels, and scorpions. The level determines production speed.
- **Barracks**: Trains archers, spearmen, militia, and swordsmen. The level determines training speed.

---

## 4. Ships
- **Corvette**: Fast and lightly armored. Carries 1 unit.
- **Frigate**: Standard warship. Carries 6 units.
- **Clipper**: Nimble, but with less capacity. Carries 4 units.
- **Galleon**: Large warship. Carries 10 units, but has limited sight range.
- **Cargo Ship**: High storage, low attack/defense.

### Ship Progression
Ships can be upgraded through research in the Shipyard to increase carrying capacity and combat effectiveness.

---

## 5. Combat and Raiding
- **Auto-Resolve Combat**: Combat is resolved automatically based on unit strengths, ship types, and a rock-paper-scissors mechanic.
  - **Archers** beat **Swordsmen**.
  - **Swordsmen** beat **Spearmen**.
  - **Spearmen** beat **Archers**.
  - **Corvettes** beat **Galleons**.
  - **Galleons** beat **Frigates**.
  - **Frigates** beat **Clippers**.
  
### 5.1 Island Defense
- **City Wall Level**: Provides a base defense score (Wall Level * 100).
- **Watchtower**: Increases sight range, showing incoming convoys.
  - Watchtowers can also house siege weapons for defense.
  
### 5.2 Raiding Rewards
- When a convoy wins a raid, it can take resources up to the storage capacity of the convoy.
- The convoy must also carry enough food to return home, reducing the available loot space.

---

## 6. Economy and Technology Progression
Research can be conducted at the **University** to unlock new ships, better trade rates, enhanced resource production, and increased unit effectiveness.

### 6.1 Tech Tree Suggestions
- **Resource Efficiency**: Increases the output of resource facilities.
- **Ship Upgrades**: Increases carrying capacity and attack/defense of ships.
- **Unit Upgrades**: Increases the effectiveness of combat units (archers, spearmen, swordsmen).
- **Harbour Upgrades**: Increases the number of ships in a convoy and the number of concurrent convoys.
- **Defense Upgrades**: Improves island defenses (city wall, watchtower range, and siege weapons).

---

## 7. AI Behavior
AI pirate players employ various strategies:
1. **Random Raiders**: Raid islands at random.
2. **Targeted Attackers**: Focus on weaker islands with low defenses.
3. **Defensive Builders**: Focus on strengthening their islands' defenses after each raid.

Neutral islands will rebuild after a raid, but do not actively improve their structures unless controlled by a pirate.

---

## 8. Colonization
Pirates can capture and control neutral islands using **Colonization Ships**, which have a 50% chance of capturing the island after a successful raid. The player can control a maximum of 10 islands based on research progress.

---

## 9. Units
- **Militia**: Fast, cheap, weak in combat. Requires only wood and stone.
- **Archers**: Strong attackers, weak defenders. Requires wood, gold.
- **Spearmen**: Strong defenders, weak attackers. Requires wood, gold, coal, and iron ore.
- **Swordsmen**: Balanced attack and defense. Requires wood, gold, coal, and iron ore.

---

## 10. Victory Conditions
There are no set objectives. The game is designed for **infinite play**, with the player deciding their own goals, whether through resource accumulation, raiding, or expanding territory.

---

## 11. Future Expansion Ideas
- **Diplomacy**: Introduce alliances and truces between AI and player-controlled pirates.
- **Weather and Hazards**: Introduce storms or sea conditions that impact travel and raids.

---

