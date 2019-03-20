using System;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public interface Player
    {
        string getNextManeuver(int page, string otherMove);
        int HitPoints { get; set; }
        int GetDamage(int range);
    }
}
