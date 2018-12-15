using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BeatTheBlast
{
    public partial class ChooseLevelForm : Form
    {
        public ChooseLevelForm()
        {

            InitializeComponent();

            CellCreater cc = new CellCreater();

            // Name label and textbox
            Label lbl_name = new Label();
            lbl_name.Text = "Enter your Name";

            ComboBox cb_fi = new ComboBox(); // first initial
            ComboBox cb_mi = new ComboBox(); // middle initial
            ComboBox cb_li = new ComboBox(); // last initial

            TextBox tb_name = new TextBox();
            tb_name.Location = new Point(0, lbl_name.Location.Y + lbl_name.Height);

            // "select difficulty" label
            Label lbl_Diff = new Label();
            lbl_Diff.Text = "Select Difficulty";
            lbl_Diff.Location = new Point(0, 90);

            // difficulty buttons created
            RadioButton rbEasy = new RadioButton();
            RadioButton rbMedium = new RadioButton();
            RadioButton rbHard = new RadioButton();

            // difficulty buttons labeled
            rbEasy.Text = "Easy";
            rbMedium.Text = "Medium";
            rbHard.Text = "Hard";

            // difficulty buttons locations given
            rbEasy.Location = new Point(20, 110);
            rbMedium.Location = new Point(20, 130);
            rbHard.Location = new Point(20, 150);

            // start button created, labeled, and positioned
            Button btnStart = new Button();
            btnStart.Text = "Start";
            btnStart.Location = new Point(20, 220);
            btnStart.Click += btnStart_clicked;

            // add everything
            Controls.Add(lbl_name);
            Controls.Add(tb_name);
            Controls.Add(lbl_Diff);
            Controls.Add(rbEasy);
            Controls.Add(rbMedium);
            Controls.Add(rbHard);
            Controls.Add(btnStart);

            void btnStart_clicked(object sender, EventArgs e)
            {
                if (tb_name.Text != "")
                {
                    //MessageBox.Show(tb_name.Text);
                    if (rbEasy.Checked)
                    {
                        Controls.Clear();
                        cc.playBeatTheBlast(5, tb_name.Text);
                        Size = new Size(200, 200);
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                        //chooseLevelForm.close();

                    }
                    else if (rbMedium.Checked)
                    {
                        Controls.Clear();
                        cc.playBeatTheBlast(10, tb_name.Text);
                        Size = new Size(350, 350);
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    }
                    else if (rbHard.Checked)
                    {
                        Controls.Clear();
                        cc.playBeatTheBlast(15, tb_name.Text);
                        Size = new Size(450, 450);
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    }
                    else
                    {
                        MessageBox.Show("Please select a difficulty.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a name.");
                }
            }
        }

        private void ChooseLevelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
