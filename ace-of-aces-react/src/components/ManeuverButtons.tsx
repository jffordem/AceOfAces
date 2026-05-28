// src/components/ManeuverButtons.tsx

import React from 'react';
import { Player } from '../models/types';
import { GameLogic } from '../services/gameLogic';

interface ManeuverButtonsProps {
  maneuvers: string[];
  player: Player;
  lastManeuver: string;
  onManeuverSelect: (maneuver: string) => void;
}

const ManeuverButtons: React.FC<ManeuverButtonsProps> = ({ maneuvers, player, lastManeuver, onManeuverSelect }) => {
  return (
    <div className="maneuver-buttons">
      {maneuvers.map(maneuver => (
        <button
          key={maneuver}
          disabled={!GameLogic.canDoManeuver(player, lastManeuver, maneuver)}
          onClick={() => onManeuverSelect(maneuver)}
        >
          {maneuver}
        </button>
      ))}
    </div>
  );
};

export default ManeuverButtons;