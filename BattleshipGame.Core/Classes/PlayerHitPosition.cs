using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class PlayerHitPosition : HitPosition
    {
        public int PlayerNumber { get; set; }

        public PlayerHitPosition(int x, int y, int playerNumber) : this(x, y, false, playerNumber)
        {

        }

        public PlayerHitPosition(int x, int y, bool hasBeenHit, int playerNumber) : this(x, y, hasBeenHit)
        {
            PlayerNumber = playerNumber;
        }

        public PlayerHitPosition(int x, int y, bool hasBeenHit) : base(x, y, hasBeenHit)
        {
        }
    }
}
