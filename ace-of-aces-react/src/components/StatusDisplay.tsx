// src/components/StatusDisplay.tsx

import React from 'react';
import { Player } from '../models/types';
import { Book } from '../services/book';
import { GameLogic } from '../services/gameLogic';

interface StatusDisplayProps {
  player: Player;
  enemy: Player;
  page: number;
  enemyManeuver: string;
  allies: Book;
}

const StatusDisplay: React.FC<StatusDisplayProps> = ({ player, enemy, page, enemyManeuver, allies }) => {
  const tail = allies.lookupBool("Tail", page);
  let status = `Player: ${player.hitPoints} Enemy: ${enemy.hitPoints}`;
  if (tail) {
    status += ` Enemy is going ${GameLogic.getDirection(enemyManeuver)}`;
  }
  return (
    <div className="status-display">
      <p>{status}</p>
    </div>
  );
};

export default StatusDisplay;