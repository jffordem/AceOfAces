// src/services/gameLogic.ts

import { Book } from './book';
import { Player } from '../models/types';
import { getManeuverDetails } from '../models/maneuvers';

export class GameLogic {
  private static startPages: number[] = [
    110, 111, 112, 113, 114, 115, 117, 121, 123, 124, 127, 129, 130, 132, 133, 135, 136, 138, 139,
    141, 152, 144, 147, 148, 149, 150, 153, 154, 155, 156,
    159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175,
    178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
    202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222
  ];

  static newGame(_player: Player, _enemy: Player, _allies: Book, _germans: Book): { page: number; playerManeuver: string; enemyManeuver: string; lastPlayerManeuver: string } {
    const index = Math.floor(Math.random() * GameLogic.startPages.length);
    const page = GameLogic.startPages[index];
    _player.hitPoints = 8;
    _enemy.hitPoints = 8;
    const playerManeuver = "Straight";
    const enemyManeuver = "Straight";
    const lastPlayerManeuver = playerManeuver;
    return { page, playerManeuver, enemyManeuver, lastPlayerManeuver };
  }

  static isDifficult(maneuver: string): boolean {
    if (!maneuver) return false;
    const details = getManeuverDetails(maneuver);
    return details ? details.difficult : false;
  }

  static canDoManeuver(actor: Player, last: string, next: string): boolean {
    if (GameLogic.isDifficult(next) && actor.hitPoints <= 4) return false;
    if (!GameLogic.isDifficult(last)) return true;
    if (!GameLogic.isDifficult(next)) return true;
    if (last === next) return true;
    return false;
  }

  static calculateDamage(_page: number, _player: Player, enemy: Player, allies: Book): { playerDamage: number; enemyDamage: number } {
    const attack = allies.lookupInt("Attack", _page);
    const damage = allies.lookupInt("Damage", _page);
    const enemyDamage = attack;
    const playerDamage = enemy.getDamage(damage);
    return { playerDamage, enemyDamage };
  }

  static getEnemyManeuver(page: number, playerManeuver: string | null, enemy: Player): string {
    return enemy.getNextManeuver(page, playerManeuver || "");
  }

  static getNextPage(page: number, playerManeuver: string, enemyManeuver: string, allies: Book, germans: Book): number {
    let mid = germans.lookupPage(enemyManeuver, page);
    let result = allies.lookupPage(playerManeuver, mid);
    if (result === 223) {
      mid = allies.lookupPage(playerManeuver, page);
      result = germans.lookupPage(enemyManeuver, mid);
    }
    return result;
  }

  static getDirection(maneuver: string): string {
    const details = getManeuverDetails(maneuver);
    return details ? details.direction : "";
  }

  static isGameOver(player: Player, enemy: Player, page: number): { gameOver: boolean; message: string } {
    if (player.hitPoints <= 0 && enemy.hitPoints <= 0) {
      return { gameOver: true, message: "You have both been shot down." };
    } else if (player.hitPoints <= 0) {
      return { gameOver: true, message: "You have been shot down." };
    } else if (enemy.hitPoints <= 0) {
      return { gameOver: true, message: "You have won!" };
    } else if (page === 223) {
      return { gameOver: true, message: "Enemy is out of range." };
    }
    return { gameOver: false, message: "" };
  }
}