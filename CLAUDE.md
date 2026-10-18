# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

A single-player adaptation of the WWI picture-book dogfight game *Ace of Aces*. The repo holds two implementations of the same game:

- `Aces/` — the original C# Windows Forms app (`Aces.sln`, Visual Studio 2013+). Treat it as the reference implementation.
- `ace-of-aces-react/` — an in-progress TypeScript/React (Vite) port that reproduces the WinForms control and display logic. Most active work happens here.

The rules from the original books are in `beginner-game-rules.md`, `intermediate-game-rules.md` and `advanced-game-rules.md`. Only the basic rules are implemented; the advanced ones (ammunition, altitude, airspeed, inclination, power dive) are future work.

## Commands (React app, run from `ace-of-aces-react/`)

- Dev server (Docker, hot reload): `docker-compose up --build` → http://localhost:5173
- Production (nginx): `docker-compose -f docker-compose.prod.yml build --no-cache` then `docker-compose -f docker-compose.prod.yml up -d` → http://localhost
- Without Docker: `npm install`, `npm run dev`, `npm run build` (`tsc && vite build`), `npm run lint`
- Regenerate book data after editing the CSVs: `node src/data/parseCsv.js` (rewrites `src/data/books.ts`)

There is no test suite, and no ESLint config file is checked in, so `npm run lint` will not work until one is added.

## Architecture

### Books: the core data model
Each player has a "book" with 223 pages. A book is a table keyed by maneuver name (plus the state rows `Attack`, `Damage`, `Tail`, `Range`) that maps page number → value. For maneuver rows the value is the next page number. The source data is `allies.csv` / `germans.csv`, which exist in both `Aces/Resources/` and `ace-of-aces-react/src/data/`. In React the CSVs are **not** read at runtime: `parseCsv.js` bakes them into the generated `books.ts` (~200KB). Don't edit `books.ts` by hand.

Page **223** is the "out of range" sentinel and ends the game.

### Turn resolution (`GameLogic.getNextPage`, mirrors `MainForm` in C#)
1. Look up the enemy's maneuver in the **germans** book from the current page to get a mid-page.
2. Look up the player's maneuver in the **allies** book from the mid-page to get the result.
3. If the result is 223, try the other order (allies first, then germans).

Damage comes from the allies book at the new page: the enemy takes `Attack`, and the player takes `enemy.getDamage(Damage)`. The `getDamage` implementation depends on the opponent type, so the Trainer takes no damage. Both sides start with 8 hit points. New games start on a random page from `GameLogic.startPages`.

### Maneuver restrictions (`GameLogic.canDoManeuver`)
Maneuver metadata (direction, difficult, speed) lives in `models/maneuvers.ts`, which mirrors `Maneuvers.cs`. Difficult maneuvers are disabled at ≤4 hit points. After a difficult maneuver, the next one must be non-difficult or the same maneuver.

### Pilots / AI (`Player` interface)
`Human` (its moves come from the UI), `EnemyPilot` (picks moves by page direction under difficulty and speed rules), `EnemyAce` (a pre-scripted choice per page) and `Trainer` (cycles a fixed pattern, takes no damage). Each one maps 1:1 to a C# class of the same name. When you change AI behavior, keep the two implementations consistent unless the divergence is intentional.

### React UI
`App.tsx` holds all game state in `useState` hooks and drives the turn loop through the static `GameLogic` service. `components/` contains presentational pieces only. `CockpitView` loads `/images/allies_{page}.png` and falls back to `.jpg`. The page images live in `public/images/`, and the prod Dockerfile copies `public/` into the nginx root.

## Notes
- `ace-of-aces-react/dist/` is committed build output.
- `readme.md` is the user-facing description; its "Code Structure" section documents the C# classes in more detail.
