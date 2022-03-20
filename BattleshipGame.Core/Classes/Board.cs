using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleshipGame.Core.Classes
{
    public class Board
    {
        private const int BoardSize = 10;
        public int PlayerNumber { get; set; }
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public Board(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }

        public PlayerHitPosition Fire(int x, int y)
        {
            var fightingShips = Ships.Where(x => x.HasBeenSunk() == false).ToList();
            bool hasBeenHit = false;
            bool hasBeenSunk = false;
            Ship ship = null;
            int i = 0;

            while (i < fightingShips.Count)
            {
                ship = fightingShips[i];
                hasBeenHit = ship.HasBattleshipBeenHit(x, y);
                if (hasBeenHit)
                {
                    hasBeenSunk = ship.HasBeenSunk();
                    break;
                }
                i++;
            }

            return new PlayerHitPosition(x, y, hasBeenHit, PlayerNumber);
        }

        public void SetNewShipsPositions()
        {
            var basicShipsList = CreateNewShips();
            var shipCount = basicShipsList.Count;
            var shipNumber = 0;
            var doColidates = false;
            do
            {
                basicShipsList[shipNumber] = SetShipPosition(basicShipsList[shipNumber]);
                doColidates = DoAnyShipColidatesWithOther(basicShipsList);
                if (doColidates == false)
                {
                    shipNumber++;
                }

            } while (shipNumber < shipCount);

            Ships = basicShipsList;
        }

        private List<Ship> CreateNewShips()
        {
            return new List<Ship>() {
                new Carrier(),
                new Battleship(),
                new Destroyer(),
                new Submarine(),
                new PatrolBoat()
            };
        }

        private Ship SetShipPosition(Ship ship)
        {
            bool isHorizontal = false;
            var random = new Random();
            ship.ResetMaintainedPosition();

            isHorizontal = random.Next(2) == 0;
            int firstPositionY = random.Next(isHorizontal == false ? BoardSize - ship.Size : BoardSize);
            int firstPositionX = random.Next(isHorizontal ? BoardSize - ship.Size : BoardSize);

            ship.AddMaintainedPositions(firstPositionX, firstPositionY);

            for (int i = 1; i <= ship.Size - 1; i++)
            {
                if (isHorizontal)
                {
                    ship.AddMaintainedPositions(firstPositionX + i, firstPositionY);
                }
                else
                {
                    ship.AddMaintainedPositions(firstPositionX, firstPositionY + i);
                }
            }

            return ship;
        }

        private bool DoAnyShipColidatesWithOther(List<Ship> ships)
        {
            var maintainedPositions = ships.SelectMany(x => x.MaintainedPositions).ToList();
            var numberOfPositions = maintainedPositions.Count;

            var discountedMaintainedPositions = maintainedPositions.Distinct();
            var numberOfDiscountedPositons = discountedMaintainedPositions.Count();

            return numberOfPositions != numberOfDiscountedPositons;
        }

        public bool AllShipsHasBeenSunk()
        {
            return Ships.TrueForAll(x => x.HasBeenSunk());
        }
    }
}
