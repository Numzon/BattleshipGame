using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Game
    {
        private const int FIRST_PLAYER_NUMBER = 0;
        private const int SECOND_PLAYER_NUMBER = 1;
        public List<Board> PlayersBoards { get; set; } = new List<Board>();

        public Game()
        {
            var firstPlayer = new Board(FIRST_PLAYER_NUMBER);
            var secondPlayer = new Board(SECOND_PLAYER_NUMBER);
            PlayersBoards = new List<Board> { firstPlayer, secondPlayer };
        }

        public GameHistory PlayAMatchAndReturnItsHistory()
        {
            var firedPositions = new List<PlayerHitPosition>();
            var random = new Random();
            var playerTurn = random.Next(2);
            var endOfTheMatch = false;
            PlayersBoards.ForEach(x => x.SetNewShipsPositions());

            do
            {
                var player = PlayersBoards.FirstOrDefault(x => x.PlayerNumber == playerTurn);
                var coordinates = GetRandomCoordinatesThanHasNeverBeenUsedBefore(playerTurn, firedPositions);
                var result = player.Fire(coordinates.Item1, coordinates.Item2);

                firedPositions.Add(result);
                endOfTheMatch = player.AllShipsHasBeenSunk();
                playerTurn = (playerTurn + 1) % 2;
            } while (endOfTheMatch == false);

            var gameHistory = new GameHistory(PlayersBoards, playerTurn);

            return gameHistory;
        }

        private (int, int) GetRandomCoordinatesThanHasNeverBeenUsedBefore(int playerNumber, List<PlayerHitPosition> history)
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
