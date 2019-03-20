using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public static class Maneuvers
    {
        public const string Stall_left = "Stall left";
        public const string Turn_left = "Turn left";
        public const string Weave_left_right = "Weave left-right";
        public const string Stall = "Stall";
        public const string Stall_right = "Stall right";
        public const string Turn_right = "Turn right";
        public const string Rotary_turn = "Rotary turn";
        public const string Weave_right_left = "Weave right-left";
        public const string Cruise_then_left = "Cruise then left";
        public const string Left_then_cruise = "Left then cruise";
        public const string Wing_left = "Wing left";
        public const string Straight = "Straight";
        public const string Immlemann = "Immleman";
        public const string Slip_left = "Slip left";
        public const string Slip_right = "Slip right";
        public const string Cruise_then_right = "Cruise then right";
        public const string Right_then_cruise = "Right then cruise";
        public const string Wing_right = "Wing right";
        public const string Fast_then_left = "Fast then left";
        public const string Left_then_fast = "Left then fast";
        public const string Fast = "Fast";
        public const string Barrel_roll_left = "Barrel roll left";
        public const string Barrel_roll_right = "Barrel roll right";
        public const string Fast_then_right = "Fast then right";
        public const string Right_then_fast = "Right then fast";

        public class Details
        {
            public Details() { }
            public Details(String direction, Boolean difficult) 
            {
                Difficult = difficult;
                Direction = direction;
            }
            public String Direction { get; set; }
            public Boolean Difficult { get; set; }
            public String Speed { get; set; }
        }

        public static Details GetDetails(String maneuver)
        {
            if (maneuver != null && maneuvers.ContainsKey(maneuver))
                return maneuvers[maneuver];
            else
                return null;
        }

        public static IDictionary<String, Details> All { get { return maneuvers; } }

        public static List<string> Select(Predicate<Maneuvers.Details> pred)
        {
            List<string> result = new List<string>();
            foreach (string maneuver in maneuvers.Keys)
            {
                if (pred(maneuvers[maneuver])) result.Add(maneuver);
            }
            return result;
        }
        private static IDictionary<String, Details> maneuvers = new Dictionary<String, Details>()
        {
            // 0. Slow (no power dive)
            { Stall_left, new Details { Direction = "left", Speed = "slow", Difficult = false } }, 
            { Turn_left, new Details { Direction = "left", Speed = "slow", Difficult = false } }, 
            { Weave_left_right, new Details { Direction = "right", Speed = "slow", Difficult = true } }, 
    
            { Stall, new Details { Direction = "straight", Speed = "slow", Difficult = false } }, 
    
            { Stall_right, new Details { Direction = "right", Speed = "slow", Difficult = false } }, 
            { Turn_right, new Details { Direction = "right", Speed = "slow", Difficult = false } }, 
            { Rotary_turn, new Details { Direction = "right", Speed = "slow", Difficult = false } }, 
            { Weave_right_left, new Details { Direction = "left", Speed = "slow", Difficult = true } }, 
    
            // 1. Cruising
            { Cruise_then_left, new Details { Direction = "left", Speed = "cruise", Difficult = false } }, 
            { Left_then_cruise, new Details { Direction = "left", Speed = "cruise", Difficult = false } }, 
            { Wing_left, new Details { Direction = "left", Speed = "cruise", Difficult = true } }, 
    
            { Straight, new Details { Direction = "straight", Speed = "cruise", Difficult = false } }, 
            { Immlemann, new Details { Direction = "straight", Speed = "cruise", Difficult = true } }, 
            { Slip_left, new Details { Direction = "straight", Speed = "cruise", Difficult = true } }, 
            { Slip_right, new Details { Direction = "straight", Speed = "cruise", Difficult = true } }, 
    
            { Cruise_then_right, new Details { Direction = "right", Speed = "cruise", Difficult = false } }, 
            { Right_then_cruise, new Details { Direction = "right", Speed = "cruise", Difficult = false } }, 
            { Wing_right, new Details { Direction = "right", Speed = "cruise", Difficult = true } }, 
    
            // 2. Fast (no climb)
            { Fast_then_left, new Details { Direction = "left", Speed = "fast", Difficult = false } }, 
            { Left_then_fast, new Details { Direction = "left", Speed = "fast", Difficult = false } }, 
    
            { Fast, new Details { Direction = "straight", Speed = "fast", Difficult = false } }, 
            { Barrel_roll_left, new Details { Direction = "straight", Speed = "fast", Difficult = true } }, 
            { Barrel_roll_right, new Details { Direction = "straight", Speed = "fast", Difficult = true } }, 
    
            { Fast_then_right, new Details { Direction = "right", Speed = "fast", Difficult = false } }, 
            { Right_then_fast, new Details { Direction = "right", Speed = "fast", Difficult = false } }, 
        };
    }
}
