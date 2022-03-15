using BattleshipGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Battleship : Ship
    {
        private const int _battleshipSize = 4;

        public Battleship() : base(ShipNameEnum.Battleship, _battleshipSize)
        {
        }
    }
}
