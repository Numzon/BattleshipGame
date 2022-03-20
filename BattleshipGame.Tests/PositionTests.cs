using BattleshipGame.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Tests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void HitPostitionConstructor_CreateNewObject_CorrectlyInitialisesFields()
        {
            var x = 1;
            var y = 2;
            var hasBeenHit = true;
            var position = new HitPosition(x,y,hasBeenHit);

            var xEquality = position.X == x;
            var yEquality = position.Y == y;
            var hasBeenHitEquality = position.HasBeenHit == hasBeenHit;

            Assert.IsTrue(xEquality && yEquality && hasBeenHitEquality);
        }

        [TestMethod]
        public void PlayerHitPostitionConstructor_CreateNewObject_CorrectlyInitialisesFields()
        {
            var x = 1;
            var y = 2;
            var hasBeenHit = true;
            var playerNumber = 4;
            var position = new PlayerHitPosition(x, y, hasBeenHit,playerNumber);

            var xEquality = position.X == x;
            var yEquality = position.Y == y;
            var hasBeenHitEquality = position.HasBeenHit == hasBeenHit;
            var playerNumberEquality = position.PlayerNumber == playerNumber;
            var result = xEquality && yEquality && hasBeenHitEquality && playerNumberEquality;

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void HistoryHitPostitionConstructor_CreateNewObject_CorrectlyInitialisesFields()
        {
            var x = 1;
            var y = 2;
            var hasBeenHit = true;
            var hasBeenSunk = true;
            var shipInitial = "D";
            var position = new HistoryHitPosition(x, y, hasBeenHit, hasBeenSunk, shipInitial);

            var xEquality = position.X == x;
            var yEquality = position.Y == y;
            var hasBeenHitEquality = position.HasBeenHit == hasBeenHit;
            var hasBeenSunkEquality = position.HasBeenSunk == hasBeenSunk;
            var shipInitialEquality = position.ShipInitial == shipInitial;
            var result = xEquality && yEquality && hasBeenHitEquality && hasBeenSunkEquality && shipInitialEquality;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_SameObjectIsCompared_ReturnsTrue()
        {
            var position = new HitPosition(5, 3);

            var result = position.Equals(position);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_OneOfTheObjectsIsNull_ReturnsFalse()
        {
            var position = new HitPosition(2, 3);
            Position secondPosition = null;

            var result = position.Equals(secondPosition);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypesOfObjects_ReturnsFalse()
        {
            var position = new HitPosition(1, 3);
            var someString = "testValue";

            var result = position.Equals(someString);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentFieldsValuesInsidePositionObjects_ReturnsFalse()
        {
            var firstPosition = new HitPosition(1, 5);
            var secondPosition = new HitPosition(7, 3);

            var result = firstPosition.Equals(secondPosition);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameFieldsValuesInsidePositionObjects_ReturnsTrue()
        {
            var firstPosition = new HitPosition(1, 5);
            var secondPosition = new HitPosition(1, 5);

            var result = firstPosition.Equals(secondPosition);

            Assert.IsTrue(result);  
        }
    }
}
