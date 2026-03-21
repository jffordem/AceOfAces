import { useState, useEffect } from 'react';
import './App.css';
import CockpitView from './components/CockpitView';
import ManeuverButtons from './components/ManeuverButtons';
import StatusDisplay from './components/StatusDisplay';
import { Book } from './services/book';
import { GameLogic } from './services/gameLogic';
import { Human } from './models/player';
import { EnemyPilot } from './models/enemyPilot';
import { Player } from './models/types';

const maneuvers = [
  "Cruise then left",
  "Stall left",
  "Stall right",
  "Cruise then right",
  "Weave right-left",
  "Slip left",
  "Cruise then left",
  "Stall left",
  "Stall",
  "Slip left",
  "Straight",
  "Slip left",
  "Slip right",
  "Straight",
  "Stall left",
  "Stall right",
  "Turn left",
  "Weave left-right",
  "Stall",
  "Stall right",
  "Turn right",
  "Rotary turn",
  "Immleman",
  "Turn right",
  "Wing right",
  "Fast then left",
  "Left then fast",
  "Fast",
  "Barrel roll left",
  "Barrel roll right",
  "Fast then right",
  "Right then fast",
];

function App() {
  const [allies, setAllies] = useState<Book | null>(null);
  const [germans, setGermans] = useState<Book | null>(null);
  const [player, setPlayer] = useState<Player | null>(null);
  const [enemy, setEnemy] = useState<Player | null>(null);
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
      const enemyPilot = new EnemyPilot(germansBook);
      setPlayer(human);
      setEnemy(enemyPilot);
      const gameState = GameLogic.newGame(human, enemyPilot, alliesBook, germansBook);
      setPage(gameState.page);
      setEnemyManeuver(gameState.enemyManeuver);
      setLastPlayerManeuver(gameState.lastPlayerManeuver);
    };
    loadBooks();
  }, []);

  const handleManeuverSelect = (maneuver: string) => {
    if (!player || !enemy || !allies || !germans) return;
    let enemyMove = enemyManeuver;
    if (germans.lookupBool("Tail", page)) {
      enemyMove = GameLogic.getEnemyManeuver(page, maneuver, enemy);
      setEnemyManeuver(enemyMove);
    }
    const nextPage = GameLogic.getNextPage(page, maneuver, enemyMove, allies, germans);
    setPage(nextPage);
    // Calculate damage
    const { playerDamage, enemyDamage } = GameLogic.calculateDamage(nextPage, player, enemy, allies);
    player.hitPoints -= playerDamage;
    enemy.hitPoints -= enemyDamage;
    setLastPlayerManeuver(maneuver);
    // Check game over
    const gameOverCheck = GameLogic.isGameOver(player, enemy, nextPage);
    if (gameOverCheck.gameOver) {
      alert(gameOverCheck.message);
      // Reset game
      const gameState = GameLogic.newGame(player, enemy, allies, germans);
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
      <CockpitView page={page} />
      <StatusDisplay player={player} enemy={enemy} page={page} enemyManeuver={enemyManeuver} allies={allies} />
      <ManeuverButtons maneuvers={maneuvers} player={player} lastManeuver={lastPlayerManeuver} onManeuverSelect={handleManeuverSelect} />
    </div>
  );
}

export default App;