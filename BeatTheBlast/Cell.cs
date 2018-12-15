using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatTheBlast
{
    class Cell : Button
    {
        protected int Row { get; set; }
        protected int Column { get; set; }
        protected bool HasBeenVisited { get; set; }
        protected bool IsLive { get; set; }
        protected int NumOfLiveNeighbors { get; set; }
        protected string Symbol { get; set; }

        public Cell()
        {
            this.Row = 0;
            this.Column = 0;
            this.HasBeenVisited = false;
            this.IsLive = false;
            this.NumOfLiveNeighbors = 0;
        }

        // get set Row
        public int getRow()
        {
            return this.Row;
        }

        public void setRow(int r)
        {
            this.Row = r;
        }

        // get set Column
        public int getColumn()
        {
            return this.Column;
        }

        public void setColumn(int c)
        {
            this.Column = c;
        }

        // get set IsLive
        public bool getIsLive()
        {
            return this.IsLive;
        }

        public void setIsLive(bool b)
        {
            this.IsLive = b;
        }


        // get set NumOfLiveNeighbors
        public int getNumOfLiveNeighbors()
        {
            return this.NumOfLiveNeighbors;
        }

        public void setNumOfLiveNeighbors(int num)
        {
            this.NumOfLiveNeighbors = num;
        }

        // get set HasBeenVisited
        public bool getHasBeenVisited()
        {
            return this.HasBeenVisited;
        }

        public void setHasBeenVisited(bool b)
        {
            this.HasBeenVisited = b;
        }

        // get set Symbol
        public string getSymbol()
        {
            return this.Symbol;
        }

        public void setSymbol(string symbol)
        {
            this.Symbol = symbol;
        }
    }
}
