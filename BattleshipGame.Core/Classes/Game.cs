using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Game
    {
        public List<Board> PlayersBoards { get; set; } = new List<Board>();


        public Game()
        {
            var firstPlayer = new Board(0);
            var secondPlayer = new Board(1);
            PlayersBoards = new List<Board> { firstPlayer, secondPlayer };
        }

        public GameHistory PlayAMatchAndReturnItsHistory()
        {
            var fireHistory = new List<HistoryHitPosition>();
            var gameHistory = new GameHistory();
            var random = new Random();
            var playerTurn = random.Next(2);
            var endOfTheMatch = false;

            PlayersBoards.ForEach(x => x.SetNewShipsPositions());

            do
            {
                var player = PlayersBoards.FirstOrDefault(x => x.PlayerNumber == playerTurn);
                var coordinates = GetRandomCoordinatesThanHasNeverBeenUsedBefore(playerTurn, fireHistory);
                var result = player.Fire(coordinates.Item1, coordinates.Item2);

                if (playerTurn == 0)
                {
                    gameHistory.PlayerOneHistory[coordinates.Item1][coordinates.Item2] = result;
                }
                else
                {
                    gameHistory.PlayerTwoHistory[coordinates.Item1][coordinates.Item2] = result;
                }

                fireHistory.Add(result);
                endOfTheMatch = player.AllShipsHasBeenSunk();
                playerTurn = (playerTurn + 1) % 2;
                if (endOfTheMatch)
                {
                    gameHistory.PlayerWhoWon = playerTurn;
                }
                
            } while (endOfTheMatch == false);

            return gameHistory;
        }

        private (int, int) GetRandomCoordinatesThanHasNeverBeenUsedBefore(int playerNumber, List<HistoryHitPosition> history)
        {
            var random = new Random();
            int xCoordinate = 0;
            int yCoordinate = 0;

            do
            {
                xCoordinate = random.Next(10);
                yCoordinate = random.Next(10);
            } while (history.Any(position => position.PlayerNumber == playerNumber && position.X == xCoordinate && position.Y == yCoordinate));

            return (xCoordinate, yCoordinate);
        }
    }
}
