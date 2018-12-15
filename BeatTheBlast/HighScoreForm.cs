using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatTheBlast
{
    public partial class HighScoreForm : Form
    {
        public List<PlayerScores> Scores = new List<PlayerScores>();
        public HighScoreForm( int size, PlayerScores ps)
        {
            loadData();
            addNewScore(ps);
            if (Scores.Count > 0)
            {
                DataTable dt_easy = new DataTable();
                DataTable dt_Medium = new DataTable();
                DataTable dt_Hard = new DataTable();

                List<DataTable> dt_list = new List<DataTable>();



                dt_list.Add(dt_easy);
                dt_list.Add(dt_Medium);
                dt_list.Add(dt_Hard);

                foreach (DataTable dt in dt_list)
                {

                    dt.Columns.Add("Place", typeof(int));
                    dt.Columns.Add("Player Name", typeof(string));
                    dt.Columns.Add("Time Elapsed", typeof(int));

                }

                List<PlayerScores> easyList = new List<PlayerScores>();
                List<PlayerScores> mediumList = new List<PlayerScores>();
                List<PlayerScores> hardList = new List<PlayerScores>();

                foreach(PlayerScores s in Scores)
                {
                    if (s.getDifficultyPlayed() == "Easy")
                    {
                        easyList.Add(s);
                    }
                    else if (s.getDifficultyPlayed() == "Medium")
                    {
                        mediumList.Add(s);
                    }
                    else // if == "Hard"
                    {
                        hardList.Add(s);
                    }
                }
               


                List<PlayerScores> sortedEasy = easyList.OrderBy(s => s.getTimeElapsed()).ToList();
                List<PlayerScores> sortedMedium = mediumList.OrderBy(s => s.getTimeElapsed()).ToList();
                List<PlayerScores> sortedHard = hardList.OrderBy(s => s.getTimeElapsed()).ToList();

                PlayerScores[] easyArr = sortedEasy.ToArray();
                PlayerScores[] mediumArr = sortedMedium.ToArray();
                PlayerScores[] hardArr = sortedHard.ToArray();

                for (int i = 0; i < 5; i++)
                {
                    if (easyArr.Length > 0 && easyArr.Length - 1 >= i)
                        dt_easy.Rows.Add(i + 1, easyArr[i].getPlayerName(), easyArr[i].getTimeElapsed());
                    if (mediumArr.Length > 0 && mediumArr.Length - 1 >= i)
                        dt_Medium.Rows.Add(i + 1, mediumArr[i].getPlayerName(), mediumArr[i].getTimeElapsed());
                    if (hardArr.Length > 0 && hardArr.Length - 1 >= i)
                        dt_Hard.Rows.Add(i + 1, hardArr[i].getPlayerName(), hardArr[i].getTimeElapsed());

                }


                DataGridView dgv = new DataGridView();
                Label lbl_difficulty = new Label();

                if (size == 5)
                {
                    dgv.DataSource = dt_easy;
                    lbl_difficulty.Text = "Easy Leaderboard";
                }
                else if (size == 10)
                {
                    dgv.DataSource = dt_Medium;
                    lbl_difficulty.Text = "Medium Leaderboard";
                }
                else
                {
                    dgv.DataSource = dt_Hard;
                    lbl_difficulty.Text = "Hard Leaderboard";
                }

                dgv.Location = new Point(20, lbl_difficulty.Location.Y + lbl_difficulty.Height);
                dgv.Size = new Size(345, 160);

                Controls.Add(lbl_difficulty);
                Controls.Add(dgv);

                Size = new Size(dgv.Width + 100, dgv.Height + 100);

                

            }
            
            FormClosing += saveData;
        }

        // save the data before closing -- path PlayerScores.txt
        public void saveData(object sender, FormClosingEventArgs e)
        {
            var fileUpdateLines = new List<string>();
            foreach (PlayerScores ps in Scores)
            {
                fileUpdateLines.Add(ps.ToString());
            }

            File.WriteAllLines("PlayerScores.txt", fileUpdateLines);
        }

        // load data when called -- path PlayerScores.txt
        public void  loadData()
        {
            
            if(File.Exists("PlayerScores.txt"))
            {
                StreamReader sr = new StreamReader("PlayerScores.txt");

                
                PlayerScores ps = new PlayerScores();

                string str;
                while (!sr.EndOfStream)
                {
                    try
                    {
                        str = sr.ReadLine();
                        ps.setPlayerName(str);

                        str = sr.ReadLine();
                        ps.setDifficultyPlayed(str);

                        str = sr.ReadLine();
                        int time = int.Parse(str);
                        ps.setTimeElapsed(time);

                        Scores.Add(ps);

                        ps = new PlayerScores();
                    }
                    catch
                    {
                        MessageBox.Show("We have a problem with loadData.");
                    }
                }
                sr.Close();
            }
            else
            {
                //just create the file
                using (StreamWriter sw = new StreamWriter(@"PlayerScores.txt", true))
                {
                  
                }

            }
            

        }

        public void addNewScore(PlayerScores ps)
        {
            if(ps != null)
                Scores.Add(ps);
        }

        


        private void HighScoreForm_Load(object sender, EventArgs e)
        {

        }
    }
}
