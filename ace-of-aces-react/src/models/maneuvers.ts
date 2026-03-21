// src/models/maneuvers.ts

import { ManeuverDetails } from './types';

export const ManeuverConstants = {
  Stall_left: "Stall left",
  Turn_left: "Turn left",
  Weave_left_right: "Weave left-right",
  Stall: "Stall",
  Stall_right: "Stall right",
  Turn_right: "Turn right",
  Rotary_turn: "Rotary turn",
  Weave_right_left: "Weave right-left",
  Cruise_then_left: "Cruise then left",
  Left_then_cruise: "Left then cruise",
  Wing_left: "Wing left",
  Straight: "Straight",
  Immlemann: "Immleman",
  Slip_left: "Slip left",
  Slip_right: "Slip right",
  Cruise_then_right: "Cruise then right",
  Right_then_cruise: "Right then cruise",
  Wing_right: "Wing right",
  Fast_then_left: "Fast then left",
  Left_then_fast: "Left then fast",
  Fast: "Fast",
  Barrel_roll_left: "Barrel roll left",
  Barrel_roll_right: "Barrel roll right",
  Fast_then_right: "Fast then right",
  Right_then_fast: "Right then fast",
};

export const ManeuverDetailsMap: { [key: string]: ManeuverDetails } = {
  [ManeuverConstants.Stall_left]: { direction: "left", speed: "slow", difficult: false },
  [ManeuverConstants.Turn_left]: { direction: "left", speed: "slow", difficult: false },
  [ManeuverConstants.Weave_left_right]: { direction: "right", speed: "slow", difficult: true },
  [ManeuverConstants.Stall]: { direction: "straight", speed: "slow", difficult: false },
  [ManeuverConstants.Stall_right]: { direction: "right", speed: "slow", difficult: false },
  [ManeuverConstants.Turn_right]: { direction: "right", speed: "slow", difficult: false },
  [ManeuverConstants.Rotary_turn]: { direction: "right", speed: "slow", difficult: false },
  [ManeuverConstants.Weave_right_left]: { direction: "left", speed: "slow", difficult: true },
  [ManeuverConstants.Cruise_then_left]: { direction: "left", speed: "cruise", difficult: false },
  [ManeuverConstants.Left_then_cruise]: { direction: "left", speed: "cruise", difficult: false },
  [ManeuverConstants.Wing_left]: { direction: "left", speed: "cruise", difficult: true },
  [ManeuverConstants.Straight]: { direction: "straight", speed: "cruise", difficult: false },
  [ManeuverConstants.Immlemann]: { direction: "straight", speed: "cruise", difficult: true },
  [ManeuverConstants.Slip_left]: { direction: "straight", speed: "cruise", difficult: true },
  [ManeuverConstants.Slip_right]: { direction: "straight", speed: "cruise", difficult: true },
  [ManeuverConstants.Cruise_then_right]: { direction: "right", speed: "cruise", difficult: false },
  [ManeuverConstants.Right_then_cruise]: { direction: "right", speed: "cruise", difficult: false },
  [ManeuverConstants.Wing_right]: { direction: "right", speed: "cruise", difficult: true },
  [ManeuverConstants.Fast_then_left]: { direction: "left", speed: "fast", difficult: false },
  [ManeuverConstants.Left_then_fast]: { direction: "left", speed: "fast", difficult: false },
  [ManeuverConstants.Fast]: { direction: "straight", speed: "fast", difficult: false },
  [ManeuverConstants.Barrel_roll_left]: { direction: "straight", speed: "fast", difficult: true },
  [ManeuverConstants.Barrel_roll_right]: { direction: "straight", speed: "fast", difficult: true },
  [ManeuverConstants.Fast_then_right]: { direction: "right", speed: "fast", difficult: false },
  [ManeuverConstants.Right_then_fast]: { direction: "right", speed: "fast", difficult: false },
};

export function getManeuverDetails(maneuver: string): ManeuverDetails | null {
  return ManeuverDetailsMap[maneuver] || null;
}

export function selectManeuvers(pred: (details: ManeuverDetails) => boolean): string[] {
  return Object.keys(ManeuverDetailsMap).filter(maneuver => pred(ManeuverDetailsMap[maneuver]));
}