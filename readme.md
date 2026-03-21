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
