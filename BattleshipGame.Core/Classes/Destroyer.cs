using BattleshipGame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Destroyer : Ship
    {
        private const int _destroyerSize = 3;

        public Destroyer() : base(ShipNameEnum.Destroyer, _destroyerSize)
        {

        }
    }
}
