using BattleshipGame.Core.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        [HttpGet]
        public GameHistory Game()
        {
            var game = new Game();
            var gameHistory = game.PlayAMatchAndReturnItsHistory();

            return gameHistory;
        }
    }
}
