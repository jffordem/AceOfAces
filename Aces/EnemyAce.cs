using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public class EnemyAce : Pilot
    {
        private static class Direction
        {
            public const string Left = "left";
            public const string Straight = "straight";
            public const string Right = "right";
        }
        private static String when(string direction, string maneuver)
        {
            return direction + ":" + maneuver;
        }
        #region Maneuvers
        private static IDictionary<int, string[]> maneuvers = new Dictionary<int, string[]>()
        {
            { 1, new string[] { 
                when(Direction.Left, Maneuvers.Left_then_cruise),
                when(Direction.Left, Maneuvers.Stall_left),
                when(Direction.Left, Maneuvers.Stall_right),
                when(Direction.Left, Maneuvers.Cruise_then_left),
                when(Direction.Straight, Maneuvers.Weave_right_left),
                when(Direction.Straight, Maneuvers.Slip_left),
                when(Direction.Straight, Maneuvers.Cruise_then_left),
                when(Direction.Straight, Maneuvers.Stall_left),
                when(Direction.Right, Maneuvers.Stall),
                when(Direction.Right, Maneuvers.Slip_left),
                when(Direction.Right, Maneuvers.Straight),
            } },
            { 2, new string[] {
                when(Direction.Left, Maneuvers.Slip_left),
                when(Direction.Right, Maneuvers.Slip_right),
                when(Direction.Straight, Maneuvers.Straight) } },
            { 3, new string[] { 
                when(Direction.Right, Maneuvers.Right_then_cruise),
                when(Direction.Right, Maneuvers.Stall_right),
                when(Direction.Right, Maneuvers.Wing_right),
                when(Direction.Right, Maneuvers.Cruise_then_right),
                when(Direction.Straight, Maneuvers.Weave_left_right),
                when(Direction.Straight, Maneuvers.Slip_right),
                when(Direction.Straight, Maneuvers.Cruise_then_right),
                when(Direction.Straight, Maneuvers.Stall_right),
                when(Direction.Left, Maneuvers.Stall),
                when(Direction.Left, Maneuvers.Slip_left),
                when(Direction.Left, Maneuvers.Straight)
            } },
            { 4, new string[] { Maneuvers.Rotary_turn, Maneuvers.Immlemann, Maneuvers.Turn_right, Maneuvers.Wing_right } },
            { 5, new string[] { Maneuvers.Rotary_turn, Maneuvers.Immlemann } },
            { 6, new string[] { Maneuvers.Turn_left } },
            { 7, new string[] { Maneuvers.Stall_left } },
            { 8, new string[] {
                when(Direction.Left, Maneuvers.Slip_right),
                when(Direction.Right, Maneuvers.Cruise_then_right),
                when(Direction.Straight, Maneuvers.Cruise_then_right) } },
            { 9, new string[] { Maneuvers.Stall_right } },
            { 10, new string[] { Maneuvers.Rotary_turn,Maneuvers.Turn_right,Maneuvers.Barrel_roll_right,Maneuvers.Fast,Maneuvers.Fast_then_right } },
            { 11, new string[] { Maneuvers.Fast_then_right,Maneuvers.Rotary_turn,Maneuvers.Turn_right,Maneuvers.Immlemann } },
            { 12, new string[] { Maneuvers.Turn_left, Maneuvers.Immlemann, Maneuvers.Right_then_fast, Maneuvers.Wing_left } },
            { 13, new string[] { Maneuvers.Weave_left_right, Maneuvers.Stall_right, Maneuvers.Straight, Maneuvers.Fast } },
            { 14, new string[] { Maneuvers.Turn_right, Maneuvers.Rotary_turn, Maneuvers.Stall_right, Maneuvers.Wing_right } },
            { 15, new string[] { Maneuvers.Stall, Maneuvers.Stall_right, Maneuvers.Slip_right } },
            { 16, new string[] { Maneuvers.Immlemann, Maneuvers.Stall, Maneuvers.Fast_then_right, Maneuvers.Slip_right, Maneuvers.Slip_left, Maneuvers.Barrel_roll_right, Maneuvers.Barrel_roll_left, Maneuvers.Rotary_turn, Maneuvers.Wing_left, Maneuvers.Wing_right } },
            { 17, new string[] { Maneuvers.Stall, Maneuvers.Stall_left, Maneuvers.Slip_left } },
            { 18, new string[] { Maneuvers.Wing_left, Maneuvers.Stall_left, Maneuvers.Turn_left, Maneuvers.Barrel_roll_left, Maneuvers.Fast_then_left } },
            { 19, new string[] { Maneuvers.Stall_left, Maneuvers.Left_then_cruise, Maneuvers.Turn_left, Maneuvers.Fast_then_left, Maneuvers.Left_then_fast } },
            { 20, new string[] { Maneuvers.Fast_then_right, Maneuvers.Fast_then_left, Maneuvers.Immlemann, Maneuvers.Rotary_turn, Maneuvers.Wing_right, Maneuvers.Wing_left } },
            { 21, new string[] { Maneuvers.Stall_right, Maneuvers.Slip_right, Maneuvers.Fast_then_right, Maneuvers.Right_then_fast, Maneuvers.Right_then_cruise } },
            { 22, new string[] { Maneuvers.Stall_right, Maneuvers.Turn_right, Maneuvers.Rotary_turn, Maneuvers.Wing_right } },
            { 23, new string[] { Maneuvers.Fast_then_left, Maneuvers.Left_then_fast, Maneuvers.Immlemann, Maneuvers.Barrel_roll_left, Maneuvers.Wing_left } },
            { 24, new string[] { Maneuvers.Turn_left, Maneuvers.Wing_left, Maneuvers.Barrel_roll_left, Maneuvers.Fast_then_left, Maneuvers.Left_then_fast, Maneuvers.Fast } },
            { 25, new string[] { Maneuvers.Turn_left, Maneuvers.Wing_left, Maneuvers.Stall_left, Maneuvers.Left_then_cruise, Maneuvers.Cruise_then_left, Maneuvers.Fast_then_left, Maneuvers.Left_then_fast } },
            { 26, new string[] { Maneuvers.Stall_left, Maneuvers.Turn_left, Maneuvers.Wing_left, Maneuvers.Cruise_then_left, Maneuvers.Slip_left, Maneuvers.Stall } },
            { 27, new string[] { Maneuvers.Fast, Maneuvers.Fast_then_right, Maneuvers.Barrel_roll_right, Maneuvers.Rotary_turn, Maneuvers.Immlemann, Maneuvers.Right_then_fast, Maneuvers.Wing_right, Maneuvers.Slip_right } },
            { 28, new string[] { Maneuvers.Straight } },
            { 29, new string[] { Maneuvers.Straight } },
            { 30, new string[] { Maneuvers.Straight } },
            { 31, new string[] { Maneuvers.Straight } },
            { 32, new string[] { Maneuvers.Straight } },
            { 33, new string[] { Maneuvers.Straight } },
            { 34, new string[] { Maneuvers.Straight } },
            { 35, new string[] { Maneuvers.Straight } },
            { 36, new string[] { Maneuvers.Straight } },
            { 37, new string[] { Maneuvers.Straight } },
            { 38, new string[] { Maneuvers.Straight } },
            { 39, new string[] { Maneuvers.Straight } },
            { 40, new string[] { Maneuvers.Straight } },
            { 41, new string[] { Maneuvers.Straight } },
            { 42, new string[] { Maneuvers.Straight } },
            { 43, new string[] { Maneuvers.Straight } },
            { 44, new string[] { Maneuvers.Straight } },
            { 45, new string[] { Maneuvers.Straight } },
            { 46, new string[] { Maneuvers.Straight } },
            { 47, new string[] { Maneuvers.Straight } },
            { 48, new string[] { Maneuvers.Straight } },
            { 49, new string[] { Maneuvers.Straight } },
            { 50, new string[] { Maneuvers.Straight } },
            { 51, new string[] { Maneuvers.Straight } },
            { 52, new string[] { Maneuvers.Straight } },
            { 53, new string[] { Maneuvers.Straight } },
            { 54, new string[] { Maneuvers.Straight } },
            { 55, new string[] { Maneuvers.Straight } },
            { 56, new string[] { Maneuvers.Straight } },
            { 57, new string[] { Maneuvers.Straight } },
            { 58, new string[] { Maneuvers.Straight } },
            { 59, new string[] { Maneuvers.Straight } },
            { 60, new string[] { Maneuvers.Straight } },
            { 61, new string[] { Maneuvers.Straight } },
            { 62, new string[] { Maneuvers.Straight } },
            { 63, new string[] { Maneuvers.Straight } },
            { 64, new string[] { Maneuvers.Straight } },
            { 65, new string[] { Maneuvers.Straight } },
            { 66, new string[] { Maneuvers.Straight } },
            { 67, new string[] { Maneuvers.Straight } },
            { 68, new string[] { Maneuvers.Straight } },
            { 69, new string[] { Maneuvers.Straight } },
            { 70, new string[] { Maneuvers.Straight } },
            { 71, new string[] { Maneuvers.Straight } },
            { 72, new string[] { Maneuvers.Straight } },
            { 73, new string[] { Maneuvers.Straight } },
            { 74, new string[] { Maneuvers.Straight } },
            { 75, new string[] { Maneuvers.Straight } },
            { 76, new string[] { Maneuvers.Straight } },
            { 77, new string[] { Maneuvers.Straight } },
            { 78, new string[] { Maneuvers.Straight } },
            { 79, new string[] { Maneuvers.Straight } },
            { 80, new string[] { Maneuvers.Straight } },
            { 81, new string[] { Maneuvers.Straight } },
            { 82, new string[] { Maneuvers.Straight } },
            { 83, new string[] { Maneuvers.Straight } },
            { 84, new string[] { Maneuvers.Straight } },
            { 85, new string[] { Maneuvers.Straight } },
            { 86, new string[] { Maneuvers.Straight } },
            { 87, new string[] { Maneuvers.Straight } },
            { 88, new string[] { Maneuvers.Straight } },
            { 89, new string[] { Maneuvers.Straight } },
            { 90, new string[] { Maneuvers.Straight } },
            { 91, new string[] { Maneuvers.Straight } },
            { 92, new string[] { Maneuvers.Straight } },
            { 93, new string[] { Maneuvers.Straight } },
            { 94, new string[] { Maneuvers.Straight } },
            { 95, new string[] { Maneuvers.Straight } },
            { 96, new string[] { Maneuvers.Straight } },
            { 97, new string[] { Maneuvers.Straight } },
            { 98, new string[] { Maneuvers.Straight } },
            { 99, new string[] { Maneuvers.Straight } },
            { 100, new string[] { Maneuvers.Straight } },
            { 101, new string[] { Maneuvers.Straight } },
            { 102, new string[] { Maneuvers.Straight } },
            { 103, new string[] { Maneuvers.Straight } },
            { 104, new string[] { Maneuvers.Straight } },
            { 105, new string[] { Maneuvers.Straight } },
            { 106, new string[] { Maneuvers.Straight } },
            { 107, new string[] { Maneuvers.Straight } },
            { 108, new string[] { Maneuvers.Straight } },
            { 109, new string[] { Maneuvers.Straight } },
            { 110, new string[] { Maneuvers.Straight } },
            { 111, new string[] { Maneuvers.Straight } },
            { 112, new string[] { Maneuvers.Straight } },
            { 113, new string[] { Maneuvers.Straight } },
            { 114, new string[] { Maneuvers.Straight } },
            { 115, new string[] { Maneuvers.Straight } },
            { 116, new string[] { Maneuvers.Straight } },
            { 117, new string[] { Maneuvers.Straight } },
            { 118, new string[] { Maneuvers.Straight } },
            { 119, new string[] { Maneuvers.Straight } },
            { 120, new string[] { Maneuvers.Straight } },
            { 121, new string[] { Maneuvers.Straight } },
            { 122, new string[] { Maneuvers.Straight } },
            { 123, new string[] { Maneuvers.Straight } },
            { 124, new string[] { Maneuvers.Straight } },
            { 125, new string[] { Maneuvers.Straight } },
            { 126, new string[] { Maneuvers.Straight } },
            { 127, new string[] { Maneuvers.Straight } },
            { 128, new string[] { Maneuvers.Straight } },
            { 129, new string[] { Maneuvers.Straight } },
            { 130, new string[] { Maneuvers.Straight } },
            { 131, new string[] { Maneuvers.Straight } },
            { 132, new string[] { Maneuvers.Straight } },
            { 133, new string[] { Maneuvers.Straight } },
            { 134, new string[] { Maneuvers.Straight } },
            { 135, new string[] { Maneuvers.Straight } },
            { 136, new string[] { Maneuvers.Straight } },
            { 137, new string[] { Maneuvers.Straight } },
            { 138, new string[] { Maneuvers.Straight } },
            { 139, new string[] { Maneuvers.Straight } },
            { 140, new string[] { Maneuvers.Straight } },
            { 141, new string[] { Maneuvers.Straight } },
            { 142, new string[] { Maneuvers.Straight } },
            { 143, new string[] { Maneuvers.Straight } },
            { 144, new string[] { Maneuvers.Straight } },
            { 145, new string[] { Maneuvers.Straight } },
            { 146, new string[] { Maneuvers.Straight } },
            { 147, new string[] { Maneuvers.Straight } },
            { 148, new string[] { Maneuvers.Straight } },
            { 149, new string[] { Maneuvers.Straight } },
            { 150, new string[] { Maneuvers.Straight } },
            { 151, new string[] { Maneuvers.Straight } },
            { 152, new string[] { Maneuvers.Straight } },
            { 153, new string[] { Maneuvers.Straight } },
            { 154, new string[] { Maneuvers.Straight } },
            { 155, new string[] { Maneuvers.Straight } },
            { 156, new string[] { Maneuvers.Straight } },
            { 157, new string[] { Maneuvers.Straight } },
            { 158, new string[] { Maneuvers.Straight } },
            { 159, new string[] { Maneuvers.Straight } },
            { 160, new string[] { Maneuvers.Straight } },
            { 161, new string[] { Maneuvers.Straight } },
            { 162, new string[] { Maneuvers.Straight } },
            { 163, new string[] { Maneuvers.Straight } },
            { 164, new string[] { Maneuvers.Straight } },
            { 165, new string[] { Maneuvers.Straight } },
            { 166, new string[] { Maneuvers.Straight } },
            { 167, new string[] { Maneuvers.Straight } },
            { 168, new string[] { Maneuvers.Straight } },
            { 169, new string[] { Maneuvers.Straight } },
            { 170, new string[] { Maneuvers.Straight } },
            { 171, new string[] { Maneuvers.Straight } },
            { 172, new string[] { Maneuvers.Straight } },
            { 173, new string[] { Maneuvers.Straight } },
            { 174, new string[] { Maneuvers.Straight } },
            { 175, new string[] { Maneuvers.Straight } },
            { 176, new string[] { Maneuvers.Straight } },
            { 177, new string[] { Maneuvers.Straight } },
            { 178, new string[] { Maneuvers.Straight } },
            { 179, new string[] { Maneuvers.Straight } },
            { 180, new string[] { Maneuvers.Straight } },
            { 181, new string[] { Maneuvers.Straight } },
            { 182, new string[] { Maneuvers.Straight } },
            { 183, new string[] { Maneuvers.Straight } },
            { 184, new string[] { Maneuvers.Straight } },
            { 185, new string[] { Maneuvers.Straight } },
            { 186, new string[] { Maneuvers.Straight } },
            { 187, new string[] { Maneuvers.Straight } },
            { 188, new string[] { Maneuvers.Straight } },
            { 189, new string[] { Maneuvers.Straight } },
            { 190, new string[] { Maneuvers.Straight } },
            { 191, new string[] { Maneuvers.Straight } },
            { 192, new string[] { Maneuvers.Straight } },
            { 193, new string[] { Maneuvers.Straight } },
            { 194, new string[] { Maneuvers.Straight } },
            { 195, new string[] { Maneuvers.Straight } },
            { 196, new string[] { Maneuvers.Straight } },
            { 197, new string[] { Maneuvers.Straight } },
            { 198, new string[] { Maneuvers.Straight } },
            { 199, new string[] { Maneuvers.Straight } },
            { 200, new string[] { Maneuvers.Straight } },
            { 201, new string[] { Maneuvers.Straight } },
            { 202, new string[] { Maneuvers.Straight } },
            { 203, new string[] { Maneuvers.Straight } },
            { 204, new string[] { Maneuvers.Straight } },
            { 205, new string[] { Maneuvers.Straight } },
            { 206, new string[] { Maneuvers.Straight } },
            { 207, new string[] { Maneuvers.Straight } },
            { 208, new string[] { Maneuvers.Straight } },
            { 209, new string[] { Maneuvers.Straight } },
            { 210, new string[] { Maneuvers.Straight } },
            { 211, new string[] { Maneuvers.Straight } },
            { 212, new string[] { Maneuvers.Straight } },
            { 213, new string[] { Maneuvers.Straight } },
            { 214, new string[] { Maneuvers.Straight } },
            { 215, new string[] { Maneuvers.Straight } },
            { 216, new string[] { Maneuvers.Straight } },
            { 217, new string[] { Maneuvers.Straight } },
            { 218, new string[] { Maneuvers.Straight } },
            { 219, new string[] { Maneuvers.Straight } },
            { 220, new string[] { Maneuvers.Straight } },
            { 221, new string[] { Maneuvers.Straight } },
            { 222, new string[] { Maneuvers.Straight } },
            { 223, new string[] { Maneuvers.Straight } },
        };
        #endregion
        private static Random rand = new Random();

        public override string getNextManeuver(int page, string playerManeuver)
        {
            return chooseOption(maneuvers[page], playerManeuver);
        }
        public override int GetDamage(int range)
        {
            return range;
        }
        private string chooseOption(string[] options, string playerManeuver)
        {
            string playerDirection = null;
            Maneuvers.Details details = Maneuvers.GetDetails(playerManeuver);
            if (details != null) playerDirection = details.Direction;
            return chooseOption(getOptions(options, playerDirection));
        }
        private string chooseOption(string[] options)
        {
            if (options == null || options.Length == 0) return Maneuvers.Straight;
            int index = rand.Next(options.Length);
            return options[index];
        }
        private string[] getOptions(string[] options, string direction)
        {
            List<string> result = new List<string>();
            foreach (string option in options)
            {
                if (option.Contains(":"))
                {
                    string[] fields = option.Split(':');
                    if (fields.Length == 2)
                    {
                        if (direction == null || fields[0] == direction)
                        {
                            result.Add(fields[1]);
                        }
                    }
                }
                else
                {
                    result.Add(option);
                }
            }
            return result.ToArray();
        }
    }
}
