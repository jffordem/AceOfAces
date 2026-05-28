// src/models/trainer.ts

import { Pilot } from './player';

export class Trainer extends Pilot {
  private movePattern: string[];
  private index: number;

  constructor(movePattern: string[]) {
    super();
    this.movePattern = movePattern;
    if (!this.movePattern || this.movePattern.length === 0) {
      this.movePattern = ["Straight"];
    }
    this.index = 0;
  }

  getNextManeuver(_page: number, _playerMove: string): string {
    const result = this.movePattern[this.index];
    this.index = (this.index + 1) % this.movePattern.length;
    return result;
  }

  getDamage(_range: number): number {
    return 0;
  }
}