using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatTheBlast
{
    class CellCreater
    {
        public CellCreater()
        {

        }

        // set up a new Minesweeper game
        public void playBeatTheBlast(int size, string playerName)
        {
            BeatTheBlastGrid msg = new BeatTheBlastGrid(size, playerName);
            msg.InitializeBTB();
        }

    }
}
