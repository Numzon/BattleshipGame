using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class HistoryHitPosition : HitPosition
    {
        public bool HasBeenSunk { get; set; }
        public string ShipInitial { get; set; }

        public HistoryHitPosition(int x, int y) : base(x,y)
        {

        }

        public HistoryHitPosition(int x, int y, bool hasBeenHit, bool hasBeenSunk, string shipInitial) : base(x, y,hasBeenHit)
        {
            HasBeenSunk = hasBeenSunk;
            ShipInitial = shipInitial;
        }

    }
}
