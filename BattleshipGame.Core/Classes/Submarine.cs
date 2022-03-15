using BattleshipGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Submarine : Ship
    {
        private const int _submarineSize = 3;

        public Submarine() : base(ShipNameEnum.Submarine, _submarineSize)
        {

        }
    }
}
