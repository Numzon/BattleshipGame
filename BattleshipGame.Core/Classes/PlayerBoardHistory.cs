using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class PlayerBoardHistory
    {
        public int PlayerNumber { get; set; }
        public HistoryHitPosition[][] BoardHistory { get; set; }

        public PlayerBoardHistory(Board board)
        {
            PlayerNumber = board.PlayerNumber;
            BoardHistory = GenerateHistoryArray();
            BoardHistory = FillBoardHistoryData(BoardHistory, board);
        }

        private HistoryHitPosition[][] GenerateHistoryArray()
        {
            var history = new HistoryHitPosition[10][];
            for (int i = 0; i < 10; i++)
            {
                history[i] = new HistoryHitPosition[10];
                for (int j = 0; j < 10; j++)
                {
                    history[i][j] = new HistoryHitPosition(i, j);
                }
            }

            return history;
        }

        private HistoryHitPosition[][] FillBoardHistoryData(HistoryHitPosition[][] history, Board board)
        {
            bool hasBeenSunk = false;
            string shipInitial = string.Empty;

            foreach (var item in board.Ships)
            {
                hasBeenSunk = item.HasBeenSunk();
                shipInitial = item.FirstLetterOfName;
                foreach (var position in item.MaintainedPositions)
                {
                    history[position.X][position.Y] = new HistoryHitPosition(position.X, position.Y, position.HasBeenHit, hasBeenSunk, shipInitial);
                }
            }

            return history;
        }
    }
}
