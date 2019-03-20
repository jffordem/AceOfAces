using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public abstract class Pilot : Player
    {
        int hp = 8; // Start with 8 hit points (the book had 3, with half-point damage for some hits)
        virtual public int HitPoints
        {
            get { return hp; }
            set { hp = value; }
        }

        public abstract string getNextManeuver(int page, string playerManeuver);
        public abstract int GetDamage(int range);
    }
}
