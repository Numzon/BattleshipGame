using BattleshipGame.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Tests
{
    [TestClass]
    public class BattleshipTests
    {
        [TestMethod]
        public void AddMaintainedPositions_SuccesfullyAddedOnePosition_ListContainsOneElement()
        {
            var bShip = new Battleship();
            bShip.AddMaintainedPositions(1, 4);

            var count = bShip.MaintainedPositions.Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void AddMaintainedPositions_TriesAddSimilarPositionAsHasBeenAddedEarlier_ThrowsAnException()
        {
            var bShip = new Battleship();
            bShip.AddMaintainedPositions(1, 4);

            Assert.ThrowsException<InvalidOperationException>(() => bShip.AddMaintainedPositions(1, 4));
        }

        [TestMethod]
        public void AddMaintainedPositions_AddMorePositionsThatIsAllowed_ThrowsAnException()
        {
            var bShip = new Battleship();
            bShip = FillShipWithPositions(bShip, 4);

            Assert.ThrowsException<IndexOutOfRangeException>(() => bShip.AddMaintainedPositions(4, 3));
        }

        private Battleship FillShipWithPositions(Battleship ship, int numberOfPositions)
        {
            for (int i = 0; i < numberOfPositions; i++)
            {
                ship.AddMaintainedPositions(i, i);
            }

            return ship;
        }

        [TestMethod]
        public void HasBattleshipBeenHit_ShipHasBeenHit_ReturnsTrue()
        {
            var bShip = new Battleship();
            bShip = FillShipWithPositions(bShip, 3);
            bShip.AddMaintainedPositions(4, 4);

            var result = bShip.HasBattleshipBeenHit(4, 4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasBattleshipBeenHit_ShipHasntBeenHit_ReturnsTrue()
        {
            var bShip = new Battleship();
            bShip = FillShipWithPositions(bShip, 4);

            var result = bShip.HasBattleshipBeenHit(8, 8);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasBeenSunk_OnlyOneMaintainedPostionHasBeenHit_ReturnsFalse()
        {
            var bShip = new Battleship();
            bShip = FillShipWithPositions(bShip, 3);
            bShip.AddMaintainedPositions(4, 4);

            bShip.HasBattleshipBeenHit(4, 4);

            Assert.IsFalse(bShip.HasBeenSunk());
        }

        [TestMethod]
        public void HasBeenSunk_ShipHasBeenSunk_ReturnsTrue()
        {
            var bShip = new Battleship();
            bShip.AddMaintainedPositions(1, 1);
            bShip.AddMaintainedPositions(2, 2);
            bShip.AddMaintainedPositions(3, 3);
            bShip.AddMaintainedPositions(4, 4);

            bShip.HasBattleshipBeenHit(1, 1);
            bShip.HasBattleshipBeenHit(2, 2);
            bShip.HasBattleshipBeenHit(3, 3);
            bShip.HasBattleshipBeenHit(4, 4);

            Assert.IsTrue(bShip.HasBeenSunk());
        }

        [TestMethod]
        public void ResetMaintainedPosition_AddSomePositionAndThenResest_NumberOfMaintainedPostionsEqualZero()
        {
            var bShip = new Battleship();
            bShip.AddMaintainedPositions(1, 1);

            bShip.ResetMaintainedPosition();
            var numberOfMaintainedPostions = bShip.MaintainedPositions.Count;

            Assert.AreEqual(0, numberOfMaintainedPostions);
        }
    }
}
