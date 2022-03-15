using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class HistoryHitPosition : Position
    {
        public int PlayerNumber { get; set; }
        public bool HasBeenHit { get; set; }
        public bool HasBeenSunk { get; set; }
        public string NameOfSunkShip { get; set; }
        public HistoryHitPosition(int x, int y, int playerNumber, bool hasBeenHit,bool hasBeenSunk, string nameOfSunkShip) : this(x,y,playerNumber,hasBeenHit)
        {
            HasBeenSunk = hasBeenSunk;
            NameOfSunkShip = nameOfSunkShip;
        }

        public HistoryHitPosition(int x, int y, int playerNumber, bool hasBeenHit) : this(x,y,playerNumber)
        {
            HasBeenHit = hasBeenHit;
        }

        public HistoryHitPosition(int x, int y, int playerNumber) : base(x, y)
        {
            PlayerNumber = playerNumber;
        }
    }
}   
