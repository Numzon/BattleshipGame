using BattleshipGame.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void PlayAMatchAndReturnItsHistory_SuccesfullyPlayAGameAndReturnsHistory_HistoryListIsNotEmpty()
        {
            var game = new Game();

            var history = game.PlayAMatchAndReturnItsHistory();

            Assert.IsTrue(history != null);
        }
    }
}
