using BattleshipGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class PatrolBoat : Ship
    {
        private const int _patrolBoatSize = 2;

        public PatrolBoat() : base(ShipNameEnum.PatrolBoat, _patrolBoatSize)
        {
        }
    }
}
