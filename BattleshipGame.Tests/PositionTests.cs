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
        public void Equals_SameObjectIsCompared_ReturnsTrue()
        {
            var position = new Position(5, 3);

            var result = position.Equals(position);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_OneOfTheObjectsIsNull_ReturnsFalse()
        {
            var position = new Position(2, 3);
            Position secondPosition = null;

            var result = position.Equals(secondPosition);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentTypesOfObjects_ReturnsFalse()
        {
            var position = new Position(1, 3);
            var someString = "testValue";

            var result = position.Equals(someString);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_DifferentFieldsValuesInsidePositionObjects_ReturnsFalse()
        {
            var firstPosition = new Position(1, 5);
            var secondPosition = new Position(7, 3);

            var result = firstPosition.Equals(secondPosition);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SameFieldsValuesInsidePositionObjects_ReturnsTrue()
        {
            var firstPosition = new Position(1, 5);
            var secondPosition = new Position(1, 5);

            var result = firstPosition.Equals(secondPosition);

            Assert.IsTrue(result);  
        }
    }
}
