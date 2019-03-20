using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public class Trainer : Pilot
    {
        string[] movePattern;
        int index;

        public Trainer(string[] movePattern)
        {
            this.movePattern = movePattern;
            if (this.movePattern == null || this.movePattern.Length == 0)
            {
                this.movePattern = new string[] { "Straight" };
            }
            this.index = 0;
        }
        override public string getNextManeuver(int page, string playerMove)
        {
            string result = this.movePattern[this.index];
            this.index = (this.index + 1) % movePattern.Length;
            return result;
        }

        override public int HitPoints { get { return 8; } }

        public override int GetDamage(int range)
        {
            return 0;
        }
    }
}
