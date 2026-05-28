# Ace of Aces

Back in my day we used to call 'television' books.

This is an adaptation of a classic two-player game called Ace of Aces, a combat picture book game where each player flies a WWI aircraft in a to-the-death dogfight.

## Requirements

Microsoft Visual Studio 2013 or newer with runtimes and C# compiler.

Installer is TBD, and this currently just runs on the local machine.

## Application Structure and Game Play

The interface is fairly simple: a main window which shows the current "page" image.  This is the pilot's current view of the enemy aircraft after the previous move was calculated.

For each turn, the player evaluates their position and chooses a maneuver that they hope will get the enemy's plane into their gunsights for a hit.  Conversely, if the enemy's guns are blazing, the player takes damage.

The game is over when one (or both) of the planes takes fatal damage, or their maneuvers cause them to lose sight of one another.

Since the game is supposed to be two-player, the computer steps in to be the opponent, and all the page-maneuver calculations are automated.  (This is a huge time-saver!)  Consequently, the capabilities of the computer pilot play an important part in the quality of the game, and a variety of enemy pilots were developed to explore the game's potential.

There are advanced rules described in the books as well relating to ammunition, altitude and airspeed that affect whether certain maneuvers are possible, and whether the aircraft are level enough for an attack to be feasible.  Those aspects weren't yet implemented and represent opportunities for future enhancement.

## Code Structure

The project is a Windows Forms application written in C#. The main entry point is `Program.cs`, which runs `MainForm.cs`.

### Core Classes

- **Player Interface**: Defines `getNextManeuver(int page, string otherMove)`, `HitPoints`, and `GetDamage(int range)`.
- **Pilot Abstract Class**: Base implementation of Player with HitPoints property.
- **Human Class**: Extends Pilot; `getNextManeuver` returns null (user chooses), `GetDamage` returns the range value.
- **EnemyPilot Class**: Extends Pilot; AI that selects maneuvers based on page direction and difficulty/speed constraints.
- **EnemyAce Class**: Extends Pilot; Advanced AI with pre-defined maneuver choices per page, considering player direction.
- **Trainer Class**: Extends Pilot; Cycles through a fixed pattern of maneuvers; takes no damage.

### Game Logic

- **Maneuvers Class**: Static class defining maneuver constants and a Details class with Direction, Difficult, and Speed properties. Provides lookup and filtering methods.
- **Book Class**: Loads CSV files (`allies.csv`, `germans.csv`) containing lookup tables for maneuver outcomes (page transitions) and game state (Attack, Damage, Tail, Range).
- **MainForm Class**: Main UI form handling game state, user input, display updates, and game flow.

### Game Flow

1. **Initialization**: Load books, set initial page, hit points to 8.
2. **Turn Loop**:
   - Display current page image (e.g., `allies_{page}.png`).
   - Player selects maneuver (via button or key).
   - Enemy selects maneuver based on AI type.
   - Calculate next page using `getNextPage`: Lookup in enemy book for player maneuver, then in allies book for enemy maneuver.
   - Apply damage: Enemy takes attack value from allies book; Player takes damage from enemy.GetDamage(damage value).
   - Update display, enable/disable maneuver buttons based on health and difficulty rules.
3. **End Conditions**: Game ends if hit points <= 0 or page == 223 (out of range).

### UI Elements

- Cockpit view: PictureBox showing current page image.
- Maneuver buttons: ToolStrip buttons for each maneuver.
- Status label: Shows health and enemy direction if tailing.
- Menu: New game, select enemy type (Pilot, Ace, Trainer), turn to page.

### Resources

- `allies.csv` and `germans.csv`: CSV files with page transition tables and game data.
- Image resources: Bitmaps for each page (e.g., `allies_1.png` to `allies_223.png`).

## Transliteration to React

To make this more portable I want to reimplement the same control and display logic for TypeScript/React.

## Building and Deploying

The React version is located in the `ace-of-aces-react` subdirectory.

### Development Mode

To run in development mode with hot reload:

1. Navigate to `ace-of-aces-react` directory.
2. Run `docker-compose up --build` to start the development server.
3. Access the app at `http://localhost:5173`.

To rebuild after code changes, run `docker-compose up --build` again.

### Production Mode

To build and deploy in production mode:

1. Navigate to `ace-of-aces-react` directory.
2. Run `docker-compose -f docker-compose.prod.yml down` (if running).
3. Run `docker-compose -f docker-compose.prod.yml build --no-cache` to rebuild.
4. Run `docker-compose -f docker-compose.prod.yml up -d` to start.
5. Access the app at `http://localhost`.

For updates, repeat steps 2-4.

## Advanced features, enhancement to gameplay and realism

The following sections are copied from the original books for consideration.

### Advanced Maneuver and Advanced Fire

In this game, severe restrictions are placed on the plane's ability to maneuver.  Speed variations are added (showing differences in motors and airframes) as well as Power Dive and Zoom Climb.  The gunfire system is refined to yield maximal realism.

**Sequence of play in the advanced game**

1. Each pilot selects the maneuver he will do for the upcoming turn.
2. Each pilot tracks the speed, inclination, and final altitude of his plane.  Each announces 'diving' or 'power diving' as well as 'pursuing'.
3. Shots are taken
4. Calculate the next turn page.
5. Each pilot checks enemy altitude, shooting and tailing for the next turn, giving clues where applicable.

During step 1 there are realistic restrictions placed on a pilot's ability to perform maneuvers.  These restrictions are based on previous moves, so an expert pilot is not one who flies turn-to-turn, but one who anticipates, and sets himself up to get a good shot.

**Maneuvers with dots**

All maneuvers with a dot below the arrow are considered fancy (i.e. difficult) maneuvers.  Usually, performing them takes a certain amount of preparation in getting up to speed, pointing the nose of the plane, etc.  Therefore, to do a fancy maneuver, the pilot must have on his previous turn performed a straight cruising, or straight fast maneuver.  Otherwise pilot may not do any maneuver with a dot underneath it on the current turn.

The exception to the above rule are slide-slips (done successively these are called 'falling leaf') and immelmann turns (done successively, called 'loops').  These fancy maneuvers still must be preceeded by a straight cruising or straight fast, but once they are begun, any number can be done in a row.

**Speed**

There are two speed numbers given next to SPEED on the Plane Characteristics chart.  The number on the left is speed at less than 7000 ft.  The number on the right is speed above 7000 ft (the speed decreases because the air is thinner).  These numbers represent the number of fast category maneuvers a pilot may do in a row.  After that number is reached, the next maneuver may not be a fast category maneuver.

Note: all other maneuver restrictions remain in effect (slow stall, and sideslip requires altitude loss, immleman requires altitude change).

**Inclination**

The pilot's choice of how to change his altitude is also restricted in the advanced game.  The basic restriction has to do with inclination (the way the nose of the plane is pointing).

(Levels are shown: zoom climb, climb, level, dive, and power dive.)

A plane may not perform an altitude change whose inclination is more than one step from the one used last turn.  The only exception is level flight may always be skipped if so desired, thus a plane may dive one turn and climb the next.

Example: the pilot power dives one turn, having dived the last turn.  Next turn he may remaing power diving, or he may move one step in either direction, to normal diving or zoom climbing.

There are two special circumstances: A pilot who is currently climbing may continue climbing or revert to level flight, but may not revert to zoom climb.  A pilot who zoom climbs one turn may continue zooming or revert to climb only.  Thus there is a one-way connection from power dive to zoom, and another one-way connection from zoom to climb.

If the maneuver performed loses altitude in some way (stall, diving, immleman, etc.) the inclination arrow is diving.

Notes on maneuver limitations: Each page of the game book shows two rules: slow (no power dive) and fast (no climb).  Only the second rule is used in the advanced game.  In the advanced game a pilot who power dives must go fast.

**Power Diving**

Power dive is a method of diving with the motor pulling the plane down.  A pilot may power dive after doing one dive of any kind (he must pass through dive mode because of the one-step inclination rule).  A pilot may only power dive a certain number of times in a row.  Each plane has a power dive speed number listed next to the power dive amount for that plane.  This is the maximum number of power dives that may be done in a row before a plane must revert to normal diving or zooming.

The advantages of a power dive are two-fold.  One, a pilot may lose altitude up to his power dive number, allowing a much greater loss of altitude in one turn than normally possible.  Two, a pilot who power dives must go fast.  You will note that many planes can do more power dives in a row than their speed number.  This is obviated by the following: a plane which does a power dive must go fast, but the fast maneuver done while power diving does not count against the plane's speed factor.  Thus a Sopwith Camel with a speed of 3 may do up to 3 fast maneuvers in a row while flying level or diving.  If the Sopwith begins to power dive, it must do fast maneuvers, but these fasts are power dive fasts and do not count against his speed factor.

After power diving 5 times (his power dive speed) the Camel may revert to normal diving, and use its normal speed factor to do 3 more fast maneuvers in a row while diving or flying level.  Thus a pilot may fly as many fast maneuvers in a row as he wishes, as long as he alternates speed fasts with power diving fasts - until he hits the ground.

Note: A pilot may power dive anywhere in his power dive range.  If he dives less, it is just a regular dive.