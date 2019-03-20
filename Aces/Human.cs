using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    class Human : Pilot
    {
        public override string getNextManeuver(int page, string playerManeuver)
        {
            return null;
        }
        public override int GetDamage(int range)
        {
            return range;
        }
    }
}
