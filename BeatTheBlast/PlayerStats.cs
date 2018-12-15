using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatTheBlast
{
    public class PlayerScores : IComparable
    {

        private string playerName;
        private string difficultyPlayed;
        private int timeElapsed;

        public PlayerScores()
        {

        }

        public PlayerScores(string name, string dificulty, int time)
        {
            this.playerName = name;
            this.difficultyPlayed = dificulty;
            this.timeElapsed = time;

        }

        public string getPlayerName()
        {
            return this.playerName;
        }

        public string getDifficultyPlayed()
        {
            return this.difficultyPlayed;
        }

        public int getTimeElapsed()
        {
            return this.timeElapsed;
        }

        public void setPlayerName(string name)
        {
            this.playerName = name;
        }

        public void setDifficultyPlayed(string difficulty)
        {
            this.difficultyPlayed = difficulty;
        }

        public void setTimeElapsed(int time)
        {
            this.timeElapsed = time;
        }

        public override string ToString()
        {
            return playerName + "\n" + difficultyPlayed + "\n" + timeElapsed;
        }

        public int CompareTo(object obj)
        {
            return timeElapsed.CompareTo(obj);
        }
    }
}
