# Migration Plan: C# .NET to TypeScript/React

This document outlines a step-by-step plan to migrate the Ace of Aces game from C# .NET Windows Forms to TypeScript/React. The goal is to maintain the same game logic and behavior while making it portable and web-based.

## Prerequisites

- Docker installed and running.
- Basic knowledge of TypeScript and React.
- Access to the original C# codebase for reference.
- Docker image with Node.js (e.g., `node:18-alpine`) for development.

## Overall Strategy

- **Incremental Migration**: Break down the migration into small, testable steps.
- **Preserve Logic**: Port game mechanics exactly to ensure identical behavior.
- **Modernize UI**: Replace Windows Forms with React components.
- **Data Handling**: Convert CSV resources to JSON or keep as CSV with parsing.
- **Testing**: After each major step, verify game flow matches original.
- **Containerization**: Use Docker for all development, build, and deployment to avoid local setup issues.

## Step 1: Set Up New Project Structure

1. Create a new directory for the React project (e.g., `ace-of-aces-react`).
2. Create a `Dockerfile` for the development environment:
   ```
   FROM node:18-alpine
   WORKDIR /app
   COPY package*.json ./
   RUN npm install
   COPY . .
   EXPOSE 3000
   CMD ["npm", "start"]
   ```
3. Create `docker-compose.yml` for easy container management:
   ```
   version: '3.8'
   services:
     app:
       build: .
       ports:
         - "5173:5173"
       volumes:
         - .:/app
         - /app/node_modules
   ```
4. Initialize a React project with TypeScript inside the container:
   - Run `docker-compose up --build` to start the container.
   - Inside the container or via docker exec: `npx create-react-app . --template typescript` (if using CRA) or `npm create vite@latest . -- --template react-ts`.
5. Install additional dependencies inside the container:
   ```
   npm install @types/node csv-parser
   ```
6. Set up project structure:
   ```
   src/
   ├── components/
   ├── models/
   ├── services/
   ├── data/
   ├── utils/
   ├── App.tsx
   └── index.tsx
   ```
7. Copy original assets (images, CSVs) to `public/` or `src/data/`.

## Step 2: Migrate Data Structures

1. Convert CSV files to JSON for easier handling in JS/TS.
   - Create a script to parse `allies.csv` and `germans.csv` into JSON objects.
   - Run the script inside the Docker container.

1. Convert CSV files to JSON for easier handling in JS/TS.
   - Create a script to parse `allies.csv` and `germans.csv` into JSON objects.
   - Example: `src/data/books.ts` with exported objects like `alliesData` and `germansData`.
2. Define TypeScript interfaces for data:
   ```typescript
   interface BookData {
     [maneuver: string]: { [page: number]: number };
   }
   ```
3. Ensure data loading is synchronous or handle async loading in React.

## Step 3: Define Core Types and Interfaces

1. Create `src/models/types.ts`:
   - `ManeuverDetails`: { direction: string, difficult: boolean, speed: string }
   - `Player`: Interface with `getNextManeuver(page: number, otherMove: string): string`, `hitPoints: number`, `getDamage(range: number): number`
   - `GameState`: { page: number, player: Player, enemy: Player, playerManeuver: string, enemyManeuver: string }
2. Define constants for maneuvers in `src/models/maneuvers.ts`.

## Step 4: Implement Maneuvers Module

1. Port `Maneuvers.cs` to `src/models/maneuvers.ts`:
   - Export maneuver constants.
   - Create a map of maneuver to details.
   - Implement `getDetails(maneuver: string): ManeuverDetails | null`
   - Implement `select(pred: (details: ManeuverDetails) => boolean): string[]`

## Step 5: Implement Book Service

1. Port `Book.cs` to `src/services/book.ts`:
   - Class or functions to load data from JSON.
   - Methods: `lookup(maneuver: string, page: number): string`
   - `lookupInt`, `lookupBool`, `lookupPage` equivalents.

## Step 6: Implement Player Classes

1. Create `src/models/player.ts`:
   - Abstract `Pilot` class with `hitPoints`.
   - `Human` class: `getNextManeuver` returns null, `getDamage` returns range.
2. Create AI players in separate files:
   - `src/models/enemyPilot.ts`: Port logic from `EnemyPilot.cs`.
   - `src/models/enemyAce.ts`: Port from `EnemyAce.cs`.
   - `src/models/trainer.ts`: Port from `Trainer.cs`.
3. Handle randomization with `Math.random()` instead of `Random`.

## Step 7: Implement Game Logic

1. Create `src/services/gameLogic.ts`:
   - `canDoManeuvers(player: Player, last: string, next: string): boolean`
   - `getNextPage(page: number, playerMove: string, enemyMove: string, alliesBook: Book, germansBook: Book): number`
   - `applyDamage(currentPage: number, player: Player, enemy: Player, alliesBook: Book): void`
   - `isGameOver(player: Player, enemy: Player, page: number): { over: boolean, message: string }`

## Step 8: Create React Components

1. `src/components/CockpitView.tsx`: Displays the current page image.
2. `src/components/ManeuverButtons.tsx`: Buttons for each maneuver, disabled based on `canDoManeuvers`.
3. `src/components/GameStatus.tsx`: Shows hit points and enemy direction.
4. `src/components/GameControls.tsx`: Menus for new game, select enemy type, turn to page.

## Step 9: Implement Main Game Component

1. `src/components/Game.tsx`:
   - Manages `GameState` with `useState`.
   - Handles user input (maneuver selection).
   - Updates state on each turn: select enemy move, calculate next page, apply damage, check game over.
   - Renders sub-components.

## Step 10: Integrate and Test

1. Update `App.tsx` to render `Game` component.
2. Run the development server inside the container: `docker-compose up`.
3. Test each feature in the browser at `http://localhost:3000`:
   - Load initial page and display image.
   - Select maneuvers and verify page transitions.
   - Check damage application and game end conditions.
   - Test different enemy types.
4. Handle edge cases: Out of range (page 223), both players dead, etc.
5. Optimize: Ensure images load efficiently, consider lazy loading.

## Step 11: Polish and Deploy

1. Add styling with CSS or a library like Tailwind (install via npm in container).
2. Implement keyboard shortcuts for maneuvers.
3. Add sound effects or animations if desired.
4. Test on different browsers using the container.
5. Build for production: The project includes `Dockerfile.prod` and `docker-compose.prod.yml` for production deployment.
6. To deploy in production mode:
   - Navigate to the `ace-of-aces-react` directory.
   - Run `docker-compose -f docker-compose.prod.yml down` (if running).
   - Run `docker-compose -f docker-compose.prod.yml build --no-cache` to rebuild.
   - Run `docker-compose -f docker-compose.prod.yml up -d` to start.
   - Access the app at `http://localhost`.
7. For updates, repeat the above steps.
8. Optionally, deploy the image to a registry (e.g., Docker Hub) and host on a server or cloud platform.

## Potential Challenges

- **Randomization**: Ensure `Math.random()` produces similar distributions.
- **Images**: Ensure all 223 page images are available and load correctly.
- **Performance**: Page lookups should be fast; consider memoization.
- **UI Responsiveness**: Make it work on mobile devices.
- **Data Accuracy**: Verify JSON conversion matches original CSVs.
- **Container Networking**: Ensure ports are properly exposed for local testing.

## Rollback Plan

- Keep original C# project intact.
- Commit frequently to git for easy reversion.
- Test each step independently before proceeding.
- If issues arise, stop the container and revert code changes.

This plan ensures a systematic migration, minimizing errors and maintaining game fidelity.