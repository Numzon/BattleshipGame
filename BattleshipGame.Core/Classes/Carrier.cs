using BattleshipGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Carrier : Ship
    {
        private const int _carrierSize = 5;

        public Carrier() : base(ShipNameEnum.Carrier, _carrierSize)
        {

        }
    }
}
