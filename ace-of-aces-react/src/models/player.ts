// src/models/player.ts

import { Player } from './types';

export abstract class Pilot implements Player {
  private _hitPoints: number = 8;

  get hitPoints(): number {
    return this._hitPoints;
  }

  set hitPoints(value: number) {
    this._hitPoints = value;
  }

  abstract getNextManeuver(_page: number, _otherMove: string): string;
  abstract getDamage(range: number): number;
}

export class Human extends Pilot {
  getNextManeuver(_page: number, _otherMove: string): string {
    return ''; // Human chooses manually, so return empty
  }

  getDamage(range: number): number {
    return range;
  }
}