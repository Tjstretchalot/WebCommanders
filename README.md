# WebCommanders

This is my first project using websockets, and it's fairly ambitious, so there's a good chance it won't be completed. It is meant to be in the same vein as .io games - users connect and input a name and are immediately placed into the game. 

This is the server portion of the game.

## Game Overview

The game is teambased over a large map. There are three strategic resources - food, wood, and stone.  When players connect they 
are placed in the general pool until a team builds the unit or gets one via trickle units.

### Map

The map is composed of two parts - grass and mountain. Around the map there are points, surrounded by either rocks or trees.

- Grass: Passable, light green
- Mountain: Grey, impassable.
- Rocks: Can be captured for passive stone income.
- Trees: Can be captured for passive wood income.


### Gameplay

There are 4 teams on a map, which resets occassionally. The game is designed for around 200-500 players per map (similiar to other io games). Players may not be
distributed evenly. 

Commander:

- There is one commander per team. If there is no commander on a team, every player will see a button to become commander.
- The commander is able to issue orders to units, deploy units, and capture strategic resources.
- The commander may step down at any time. Any other player in the general pool may take over. 
- The commander may build two buildings:
  - A farm, which increases population cap. Requires wood.
  - A barracks, which provides passive units. A barracks may specify which type of unit it spawns. Requires wood and stone.

Pirate:

- Has a hook which can be used to pull enemies in. Hooking an enemy does a moderate amount of damage. Cannot target allies.
- Has a moderate amount of health. No health regen.

Medic:

- When in melee range of an ally, may punch that ally to heal it.
- Can throw a smoke bomb, which does a little ticking damage to opponents inside the smoke.
- Has a small amount of health. Moderate health regen.

Brawler:

- Can punch (melee range) for a moderate amount of damage. 
- Has a large amount of health. No health regen.