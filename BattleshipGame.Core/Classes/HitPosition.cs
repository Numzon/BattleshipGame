using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class HitPosition : Position
    {
        public bool HasBeenHit { get; set; }
        public HitPosition(int x, int y) : base(x, y)
        {
        }
    }
}
