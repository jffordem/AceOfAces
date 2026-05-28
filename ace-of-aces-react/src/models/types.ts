// src/models/types.ts

export interface ManeuverDetails {
  direction: string;
  difficult: boolean;
  speed: string;
}

export interface Player {
  getNextManeuver(page: number, otherMove: string): string;
  hitPoints: number;
  getDamage(range: number): number;
}

export interface GameState {
  page: number;
  player: Player;
  enemy: Player;
  playerManeuver: string;
  enemyManeuver: string;
}