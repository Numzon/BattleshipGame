using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class GameHistory 
    {
        public HistoryHitPosition[][] PlayerOneHistory { get; set; }
        public HistoryHitPosition[][] PlayerTwoHistory { get; set; }
        public int PlayerWhoWon { get; set; }

        public GameHistory()
        {
            PlayerOneHistory = InitHistoryArray(PlayerOneHistory, 0);
            PlayerTwoHistory = InitHistoryArray(PlayerTwoHistory, 1);
        }

        public HistoryHitPosition[][] InitHistoryArray(HistoryHitPosition[][] history, int playerNumber)
        {
            history = new HistoryHitPosition[10][];
            for (int i = 0; i < 10; i++)
            {
                history[i] = new HistoryHitPosition[10];
                for (int j = 0; j < 10; j++)
                {
                    history[i][j] = new HistoryHitPosition(i, j, playerNumber);
                }
            }

            return history;
        }
    }
}
