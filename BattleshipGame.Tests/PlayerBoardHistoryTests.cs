using BattleshipGame.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Tests
{
    [TestClass]
    public class PlayerBoardHistoryTests
    {
        [TestMethod]
        public void Constructor_CorrectlyFillHistoryBoard_ShipsAndTheirStatesMatchesHistoryBoard()
        {
            var board = new Board(0);
            board.SetNewShipsPositions();
            var firstShip = board.Ships.FirstOrDefault();
            var secondShip = board.Ships.Last();
            foreach (var item in firstShip.MaintainedPositions)
            {
                board.Fire(item.X, item.Y);
            }
            foreach (var item in secondShip.MaintainedPositions.Take(secondShip.MaintainedPositions.Count / 2))
            {
                board.Fire(item.X, item.Y);
            }

            var playerHistoryBoard = new PlayerBoardHistory(board);
            var errorCount = 0;
            foreach (var history in playerHistoryBoard.BoardHistory)
            {
                foreach (var position in history)
                {
                    Ship ship = null;
                    if (string.IsNullOrEmpty(position.ShipInitial) == false)
                    {
                        board.Ships.FirstOrDefault(x => x.FirstLetterOfName == position.ShipInitial);
                    }
                    if (ship == null && string.IsNullOrEmpty(position.ShipInitial) == false)
                    {
                        errorCount++;
                    }
                    if (ship != null)
                    {
                        var shipPosition = ship.MaintainedPositions.Where(x => x.Equals(position)).FirstOrDefault();

                        if (shipPosition.HasBeenHit != position.HasBeenHit)
                        {
                            errorCount++;
                        }

                        if (position.HasBeenSunk && ship.HasBeenSunk() == false)
                        {
                            errorCount++;
                        }
                    }
                }
            }
        }
    }
}
