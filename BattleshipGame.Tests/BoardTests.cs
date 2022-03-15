using BattleshipGame.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void SetNewShipsPositions_CorrectlySetsNewShipsPositions_NumberOfShipsEqualsFive()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();

            var numberOfShip = board.Ships.Count;

            Assert.AreEqual(5, numberOfShip);
        }

        [TestMethod]
        public void SetNewShipsPositions_CorrectlySetsNewShipsPostions_NumberOfDistinctedPositionsEqualsSeventeen()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();

            var numberOfPositions = board.Ships.SelectMany(x => x.MaintainedPositions).Distinct().Count();

            Assert.AreEqual(17, numberOfPositions);
        }

        [TestMethod]
        public void SetNewShipsPositions_SetsNewShipsAndAfterSecondUseSetsANewOne_ShipsHaveDifferentReferences()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();
            var shipsCreated = board.Ships.ToList();
            board.SetNewShipsPositions();
            var shipsCreatedAfterSecondUse = board.Ships.ToList();

            var oneOrMoreHasSameReferences = shipsCreated.Any(x => shipsCreatedAfterSecondUse.Any(z => object.ReferenceEquals(x, z)));

            Assert.IsTrue(oneOrMoreHasSameReferences);
        }

        [TestMethod]
        public void Fire_ShotWasAMiss_HasBeenHitEqualsFalse()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();

            var result = board.Fire(11, 11);

            Assert.IsFalse(result.HasBeenHit);
        }

        [TestMethod]
        public void Fire_ShotHitTheTarget_HasBeenHitEqualsTrue()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();
            var shipPosition = board.Ships.Select(x => x.MaintainedPositions.FirstOrDefault()).FirstOrDefault();

            var result = board.Fire(shipPosition.X, shipPosition.Y);

            Assert.IsTrue(result.HasBeenHit);
        }

        [TestMethod]
        public void Fire_ShipGetsHitMultipleTimesAndGetSunk_HasBeenSunkEqualsTrue()
        {
            var board = new Board(1);
            board.SetNewShipsPositions();
            var shipPosition = board.Ships.Select(x => x.MaintainedPositions).FirstOrDefault();
            var historyHitPostions = new List<HistoryHitPosition>();

            foreach (var item in shipPosition)
            {
                historyHitPostions.Add(board.Fire(item.X, item.Y));
            }

            var lastHistoryHitPosition = historyHitPostions.Last();

            Assert.IsTrue(lastHistoryHitPosition.HasBeenSunk);
        }

    }
}
