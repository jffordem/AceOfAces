# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is an adaptation of the board game "Ace of Aces" — a two-player WWI dogfight game where each player navigates a picture book by choosing maneuvers each turn. The project has two implementations:

1. **`Aces/`** — Original C# Windows Forms app (legacy, reference only)
2. **`ace-of-aces-react/`** — Active TypeScript/React rewrite (the current focus)

Read `readme.md` for game rules and application structure. Read `MIGRATION_PLAN.md` for the migration strategy from C# to React (steps 1–10 are complete as of the current branch).

## Running the React App

All development is Docker-based. From `ace-of-aces-react/`:

```bash
# Development (hot reload at http://localhost:5173)
docker-compose up --build

# Production build (http://localhost)
docker-compose -f docker-compose.prod.yml down
docker-compose -f docker-compose.prod.yml build --no-cache
docker-compose -f docker-compose.prod.yml up -d
```

To run without Docker (requires Node 18+):
```bash
cd ace-of-aces-react
npm install
npm run dev
```

Other scripts: `npm run build`, `npm run lint`, `npm run preview`.

## React App Architecture

The app is a Vite + React 18 + TypeScript single-page app. All game state lives in `App.tsx` via `useState`.

**Data flow:**
- `src/data/books.ts` — Pre-generated lookup tables (auto-generated from `allies.csv` / `germans.csv`). Never edit by hand; regenerate with `src/data/parseCsv.js`.
- `src/services/book.ts` — `Book` class wraps the lookup tables; exposes `lookup`, `lookupInt`, `lookupBool`, `lookupPage`.
- `src/services/gameLogic.ts` — `GameLogic` static class: `newGame`, `getNextPage`, `calculateDamage`, `canDoManeuver`, `isGameOver`.
- `src/models/types.ts` — Core interfaces: `Player`, `ManeuverDetails`, `GameState`.
- `src/models/maneuvers.ts` — `ManeuverConstants` (25 named maneuvers), `ManeuverDetailsMap` (direction/speed/difficult per maneuver), helper functions.
- `src/models/player.ts` — Abstract `Pilot`, concrete `Human`.
- `src/models/enemyPilot.ts` — `EnemyPilot`: direction-based AI using a per-page lookup table.
- `src/models/enemyAce.ts` — `EnemyAce`: stronger AI with hand-coded preferred maneuvers per page (pages 1–27 have real entries; pages 28–223 all default to "Straight" — this is an incomplete migration artifact).
- `src/models/trainer.ts` — `Trainer`: cycles through a fixed pattern; takes no damage (for practice).

**Turn loop (in `App.tsx` `handleManeuverSelect`):**
1. Enemy picks a maneuver (`GameLogic.getEnemyManeuver`), re-picking with player's direction info if the German book says `Tail=true` for the current page.
2. `GameLogic.getNextPage` cross-references both books to get the next page number (page 223 = out of range / game over).
3. `GameLogic.calculateDamage` reads `Attack` and `Damage` from the allies book; player receives `enemy.getDamage(damage)`, enemy receives `attack`.
4. Game-over check triggers an alert and auto-restarts.

**Page images:** Served from `/images/allies_{page}.png` (or `.jpg` fallback). These must exist in the Docker container's public folder; the dev image includes them via the volume mount.

**Maneuver button layout:** Buttons are grouped by speed (`fast`, `slow`) and direction+cruise (`left`, `straight`, `right`) and positioned around the cockpit image via CSS grid in `App.css`.

## Key Constraints

- The lookup tables in `src/data/books.ts` are the source of truth for all page transitions and game data. The CSV files in `src/data/` are the canonical source; `books.ts` is derived.
- `EnemyAce` only has meaningful AI for pages 1–27. Pages 28–223 all play "Straight" — this is a known gap from the migration.
- Page 223 is the sentinel for "out of range" game over.
- Players start with 8 hit points. `canDoManeuver` blocks difficult maneuvers when HP ≤ 4, and blocks chaining two *different* difficult maneuvers in succession.
