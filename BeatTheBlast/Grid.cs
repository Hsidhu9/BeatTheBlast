using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatTheBlast
{
    abstract class Grid
    {
        protected Cell[,] GridOfCells { get; set; }
        protected int GridSize { get; set; }
        protected int LiveCellCount { get; set; }
        protected string playerName;

        public Grid()
        {

        }
        public Grid(int size, string playerName)
        {
            this.GridSize = size;
            this.playerName = playerName;
            GridOfCells = new Cell[GridSize, GridSize];
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    GridOfCells[i, j] = new Cell();
                    GridOfCells[i, j].setRow(i);
                    GridOfCells[i, j].setColumn(j);
                }
            }
        }

        // getters and setters

        public Cell[,] getGridOfCells()
        {
            return this.GridOfCells;
        }

        public void setGridOfCells(Cell[,] gOC)
        {
            this.GridOfCells = gOC;
        }


        public int getGridSize()
        {
            return this.GridSize;
        }

        public void setGridSize(int size)
        {
            this.GridSize = size;
        }

        public int getLiveCellCount()
        {
            return this.LiveCellCount;
        }

        public void setLiveCellCount(int count)
        {
            this.LiveCellCount = count;
        }

        public virtual void revealGrid()
        {

        }
    }
}
