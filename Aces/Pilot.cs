using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public abstract class Pilot : Player
    {
        int hp = 8;
        virtual public int HitPoints
        {
            get { return hp; }
            set { hp = value; }
        }

        public abstract string getNextManeuver(int page, string playerManeuver);
        public abstract int GetDamage(int range);
    }
}
