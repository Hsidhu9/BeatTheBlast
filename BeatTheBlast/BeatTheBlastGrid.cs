using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace BeatTheBlast
{
    class BeatTheBlastGrid : Grid
    {

        Stopwatch s = new Stopwatch();
        


        void IPlayable()
        {
            return;
        }

        // blank constructor
        public BeatTheBlastGrid()
        {

        }

        // populated constructor
        public BeatTheBlastGrid(int size, string name)
        {
            try
            {
                playerName = name;
                //Allot the size according to the level chosen
                GridSize = size; 
                GridOfCells = new Cell[GridSize, GridSize]; 
                for (int i = 0; i < GridSize; i++)
                {
                    for (int j = 0; j < GridSize; j++)
                    {
                        GridOfCells[i, j] = new Cell();
                        GridOfCells[i, j].setRow(i);
                        GridOfCells[i, j].setColumn(j);
                        GridOfCells[i, j].Size = new Size(25,25);
                        GridOfCells[i, j].Location = new Point(GridOfCells[i, j].getRow() * GridOfCells[i, j].Width + 40, GridOfCells[i, j].getColumn() * GridOfCells[i, j].Height + 30);
                        GridOfCells[i, j].MouseDown += C_Click;
                        GridOfCells[i, j].BackColor = Color.LightGreen;
                        GridOfCells[i, j].Text = "";
                        Form.ActiveForm.Controls.Add(GridOfCells[i, j]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // show the grid as far as the player has revealed cells.
        public void showPlayerGrid()
        {
            try
            {
                foreach (Cell c in GridOfCells)
                {

                    if (c.getHasBeenVisited() == true)
                    {
                        c.BackColor = Color.DarkOliveGreen;
                        if (c.getIsLive())
                        {
                            c.Text = "*";
                        }
                        else if (c.getNumOfLiveNeighbors() != 0)
                        {

                            c.Text = c.getNumOfLiveNeighbors().ToString();
                        }
                        else // liveNeighbors == 0
                        {
                            c.Text = "";
                        }

                    }
                    else // if not visited
                    {

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // cell click method
        private void C_Click(object sender, MouseEventArgs e)
        {
            try
            {
                Cell c = (Cell)sender;
                int rowInt = c.getRow();
                int colInt = c.getColumn();

               
                if (e.Button == MouseButtons.Right)
                {
                    c.Text = "F";
                    c.MouseDown -= C_Click;
                }
                else
                {
                    revealBlankCell(rowInt, colInt);
                }
                playBTB(c);
            }
            catch
            {
                MessageBox.Show("Problem with C_Click");
            }
        }

        // set a number of cells to be active, and activate that number of cells
        public void activateCells()
        {
            try
            {
                // create the randomized number of live cells
                Random r = new Random();
                double percent = r.Next(10, 11);
                double liveCells = (percent / 100) * GridSize * GridSize;
                // add the number of liveCells to the grid
                int rowCount = 0;
                int colCount = 0;

                for (int liveCount = 0; liveCount < Math.Ceiling(liveCells); liveCount++) // until we've populated our maxCell count..
                {
                    rowCount = r.Next(0, GridSize); // select a random row
                    colCount = r.Next(0, GridSize); // select a random column
                    if (GridOfCells[rowCount, colCount].getIsLive() != true) // if the cell is not live
                    {
                        this.GridOfCells[rowCount, colCount].setIsLive(true); // make it live
                    }
                    else
                    {
                        liveCount--; // try again
                    }
                }
                int liveCellInt = (int)liveCells;
                setLiveCellCount(liveCellInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // get the number of live cells in a given grid (implemented in checkForWin())
        public int showLiveCellCount()
        {
            int liveCells = 0;
            foreach (Cell c in GridOfCells)
            {
                if (c.getIsLive() == true)
                {
                    liveCells++;
                }
                else
                {
                    continue;
                }
            }

            return liveCells;
        }

        // for each cell in the grid, set the neighbor cells' numOfLiveNeighbors based on each live cell
        public void countLiveNeighbors()
        {
            try
            {
                for (int y = 0; y < GridSize; y++) // cell row
                {
                    for (int x = 0; x < GridSize; x++) // cell column
                    {
                        if (GridOfCells[x, y].getIsLive() == true) // if the cell is live..
                        {
                            for (int y2 = -1; y2 < 2; y2++) // neighbor row
                            {
                                for (int x2 = -1; x2 < 2; x2++) // neighbor column
                                {
                                    if (x2 == 0 && y2 == 0) // if it's the same cell...
                                    {
                                        // ignore
                                    }
                                    else // otherwise
                                    {
                                        try
                                        {
                                            GridOfCells[(x + x2), (y + y2)].setNumOfLiveNeighbors(GridOfCells[(x + x2), (y + y2)].getNumOfLiveNeighbors() + 1); // increase neighbors' numOfNeighbs by 1.
                                        }
                                        catch
                                        {
                                            // if it's out-of-bounds, do nothing.
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        // after the game ends, show the full grid reveal
        public override void revealGrid()
        {
            foreach (Cell c in GridOfCells)
            {
                c.BackColor = Color.DarkOliveGreen;
                if (c.getIsLive())
                {
                    c.Text = "*";
                }
                else if (c.getNumOfLiveNeighbors() != 0)
                {
                    c.Text = c.getNumOfLiveNeighbors().ToString();
                }
                else // liveNeighbors == 0
                {
                    c.Text = "";
                }
            }

        }

        // recursive method :: if the selected cell is blank, reveal that cell and the surrounding cells until there are no more blank cells in the region
        public void revealBlankCell(int x, int y)
        {
            try
            {
                Cell c = GridOfCells[x, y]; // the selected cell


                if (c.getHasBeenVisited())
                {

                }
                else
                {
                    c.setHasBeenVisited(true);
                    if (c.getIsLive())
                    {

                    }
                    else
                    {
                        if (c.getNumOfLiveNeighbors() != 0)
                        {

                        }
                        else
                        {

                            revealBlankCell(x - 1, y); // do the same for the cell to the left
                            revealBlankCell(x - 1, y - 1); // do the same for the cell below and to the left
                            revealBlankCell(x, y - 1); // do the same for the cell below
                            revealBlankCell(x + 1, y - 1); // do the same for the cell below and to the right
                            revealBlankCell(x + 1, y); // do the same for the cell to the right
                            revealBlankCell(x + 1, y + 1); // do the same for the cell above and to the right
                            revealBlankCell(x, y + 1); // do the same for the cell above
                            revealBlankCell(x - 1, y + 1); // do the same for the cell above and to the left
                        }
                    }
                }
            }
            catch
            {

            }
        }

        // if the user selects an active cell, return true.
        public bool checkForLose()
        {
            bool b = false;
            int numOfLiveVisited = 0;
            foreach (Cell c in GridOfCells)
            {
                if (c.getHasBeenVisited() == true && c.getIsLive() == true) // if it's visited and live
                {
                    //b = true; // game over :: you lose
                    numOfLiveVisited++;
                }
            }
            if (numOfLiveVisited > 0)
            {
                b = true;
            }
            return b;
        }

        // if every not-live cell has been revealed, return true :: uses showLiveCellCount()
        public bool checkForWin()
        {
            bool b = false;
            int visitedCells = 0;
            int notLiveCells = GridOfCells.Length - showLiveCellCount();
            foreach (Cell c in GridOfCells)
            {
                if (c.getHasBeenVisited() == true && c.getIsLive() == false) // if the cell visited isn't live...
                {
                    visitedCells++; // that's another cell that's safe
                }
            }
            if (visitedCells == notLiveCells) // once all inactive cells are revealed...
            {
                b = true; // game over :: you win!
            }
            return b;
        }


        // start up the game :: for use in Driver class
        public void InitializeBTB()
        {
            try
            {
                activateCells();
                countLiveNeighbors();
                showPlayerGrid();
                s.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // play the game step by step...
        public void playBTB(Cell c)
        {
            try
            {

                //revealBlankCell(colInt, rowInt); // reveal the cell, and any relevant neighbors
                bool lost = checkForLose(); // check if the cell is a bomb
                bool won = checkForWin(); // check if that's the last inactive cell
                                         
                if (lost == true) // if it was a bomb...
                {
                    s.Stop();
                    revealGrid();
                    MessageBox.Show("We're sorry. You failed.\nTime elapsed: " + s.ElapsedMilliseconds/1000 + " seconds.");

                    HighScoreForm hsf = new HighScoreForm(GridSize, null);
                    hsf.Show();
                }
                else if (won == true) // if all inactives are visited...
                {
                    s.Stop();
                    revealGrid();
                    MessageBox.Show("Congratulations! You won!\nTime elapsed: " + s.ElapsedMilliseconds / 1000 + " seconds.");

                    PlayerScores ps = new PlayerScores();
                    ps.setPlayerName(playerName);

                    if (GridSize == 5)
                        ps.setDifficultyPlayed("Easy");
                    else if (GridSize == 10)
                        ps.setDifficultyPlayed("Medium");
                    else
                        ps.setDifficultyPlayed("Hard");

                    ps.setTimeElapsed((int)s.ElapsedMilliseconds / 1000);

                    MessageBox.Show(ps.getPlayerName() + "\n" + ps.getDifficultyPlayed() + "\n" + ps.getTimeElapsed());

                    
                    HighScoreForm hsf = new HighScoreForm(GridSize, ps);
                    
                    
                    hsf.Show();

                }
                else // if the game hasn't ended yet, update the grid and ask again.
                {
                    showPlayerGrid();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
