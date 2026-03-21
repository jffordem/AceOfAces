import { useState, useEffect } from 'react';
import './App.css';
import CockpitView from './components/CockpitView';
import ManeuverButtons from './components/ManeuverButtons';
import StatusDisplay from './components/StatusDisplay';
import { Book } from './services/book';
import { GameLogic } from './services/gameLogic';
import { Human } from './models/player';
import { Trainer } from './models/trainer';
import { EnemyPilot } from './models/enemyPilot';
import { EnemyAce } from './models/enemyAce';
import { Player } from './models/types';
import { ManeuverConstants } from './models/maneuvers';

const maneuvers = Object.values(ManeuverConstants);

type EnemyType = 'EnemyPilot' | 'EnemyAce' | 'Trainer';

function createEnemy(type: EnemyType, germans: Book): Player {
  switch (type) {
    case 'EnemyAce':
      return new EnemyAce();
    case 'Trainer':
      return new Trainer([ManeuverConstants.Straight, ManeuverConstants.Cruise_then_right, ManeuverConstants.Right_then_cruise]);
    case 'EnemyPilot':
    default:
      return new EnemyPilot(germans);
  }
}

function App() {
  const [allies, setAllies] = useState<Book | null>(null);
  const [germans, setGermans] = useState<Book | null>(null);
  const [player, setPlayer] = useState<Player | null>(null);
  const [enemy, setEnemy] = useState<Player | null>(null);
  const [enemyType, setEnemyType] = useState<EnemyType>('EnemyPilot');
  const [page, setPage] = useState<number>(0);
  const [enemyManeuver, setEnemyManeuver] = useState<string>("Straight");
  const [lastPlayerManeuver, setLastPlayerManeuver] = useState<string>("Straight");

  useEffect(() => {
    const loadBooks = async () => {
      const alliesBook = await Book.loadAllies();
      const germansBook = await Book.loadGermans();
      setAllies(alliesBook);
      setGermans(germansBook);

      const human = new Human();
      const selectedEnemy = createEnemy(enemyType, germansBook);

      setPlayer(human);
      setEnemy(selectedEnemy);

      const gameState = GameLogic.newGame(human, selectedEnemy, alliesBook, germansBook);
      setPage(gameState.page);
      setEnemyManeuver(gameState.enemyManeuver);
      setLastPlayerManeuver(gameState.lastPlayerManeuver);
    };
    loadBooks();
  }, [enemyType]);

  const handleEnemyTypeChange = (newType: EnemyType) => {
    setEnemyType(newType);
    if (!player || !allies || !germans) return;

    const selectedEnemy = createEnemy(newType, germans);
    setEnemy(selectedEnemy);
    const gameState = GameLogic.newGame(player, selectedEnemy, allies, germans);
    setPage(gameState.page);
    setEnemyManeuver(gameState.enemyManeuver);
    setLastPlayerManeuver(gameState.lastPlayerManeuver);
  };

  const handleManeuverSelect = (maneuver: string) => {
    if (!player || !enemy || !allies || !germans) return;

    // Determine current enemy move for the current page (updateDisplay behavior)
    let enemyMove = GameLogic.getEnemyManeuver(page, null, enemy);

    // If we are tailed this turn, enemy re-selects with player move information
    if (germans.lookupBool("Tail", page)) {
      enemyMove = GameLogic.getEnemyManeuver(page, maneuver, enemy);
    }

    setEnemyManeuver(enemyMove);

    const nextPage = GameLogic.getNextPage(page, maneuver, enemyMove, allies, germans);
    setPage(nextPage);

    // Apply damage
    const { playerDamage, enemyDamage } = GameLogic.calculateDamage(nextPage, player, enemy, allies);
    player.hitPoints -= playerDamage;
    enemy.hitPoints -= enemyDamage;

    setLastPlayerManeuver(maneuver);

    // Check game over conditions
    const gameOverCheck = GameLogic.isGameOver(player, enemy, nextPage);
    if (gameOverCheck.gameOver) {
      alert(gameOverCheck.message);
      const newEnemy = createEnemy(enemyType, germans);
      setEnemy(newEnemy);
      const gameState = GameLogic.newGame(player, newEnemy, allies, germans);
      setPage(gameState.page);
      setEnemyManeuver(gameState.enemyManeuver);
      setLastPlayerManeuver(gameState.lastPlayerManeuver);
    }
  };

  if (!allies || !germans || !player || !enemy) {
    return <div>Loading...</div>;
  }

  return (
    <div className="App">
      <h1>Ace of Aces</h1>

      <div className="enemy-selector">
        <label htmlFor="enemyType">Enemy Pilot: </label>
        <select
          id="enemyType"
          value={enemyType}
          onChange={(e) => handleEnemyTypeChange(e.target.value as EnemyType)}
          style={{ fontSize: '1rem', padding: '0.25rem 0.5rem' }}
        >
          <option value="EnemyPilot">Enemy Pilot</option>
          <option value="EnemyAce">Enemy Ace</option>
          <option value="Trainer">Trainer</option>
        </select>
      </div>

      <CockpitView page={page} />
      <StatusDisplay player={player} enemy={enemy} page={page} enemyManeuver={enemyManeuver} allies={allies} />
      <ManeuverButtons maneuvers={maneuvers} player={player} lastManeuver={lastPlayerManeuver} onManeuverSelect={handleManeuverSelect} />
    </div>
  );
}

export default App;