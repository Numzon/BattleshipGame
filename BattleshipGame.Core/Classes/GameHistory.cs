using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class GameHistory 
    {
        public List<PlayerBoardHistory> PlayersHistory { get; set; } = new List<PlayerBoardHistory>();
        public int PlayerWhoWon { get; set; }

        public GameHistory(IList<Board> playerBoards, int playerWhoWon)
        {
            PlayerWhoWon = playerWhoWon;
            foreach (var item in playerBoards)
            {
                PlayersHistory.Add(new PlayerBoardHistory(item));
            }
        }
    }
}
