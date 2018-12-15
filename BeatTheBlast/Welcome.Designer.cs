namespace BeatTheBlast
{
    partial class Welcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.GameIntroLabel = new System.Windows.Forms.Label();
            this.EasyLabel = new System.Windows.Forms.Label();
            this.MediumLabel = new System.Windows.Forms.Label();
            this.HardLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(71, 20);
            this.WelcomeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(413, 29);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "WELCOME TO BEAT THE BLAST";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WelcomeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLabel.Location = new System.Drawing.Point(63, 72);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(159, 24);
            this.InstructionsLabel.TabIndex = 1;
            this.InstructionsLabel.Text = "INSTRUCTIONS";
            // 
            // GameIntroLabel
            // 
            this.GameIntroLabel.AutoSize = true;
            this.GameIntroLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameIntroLabel.Location = new System.Drawing.Point(64, 113);
            this.GameIntroLabel.Name = "GameIntroLabel";
            this.GameIntroLabel.Size = new System.Drawing.Size(443, 36);
            this.GameIntroLabel.TabIndex = 2;
            this.GameIntroLabel.Text = "Click on any cell in the cells. You loose when the bomb blasts.\r\n This Game consi" +
    "sts of three levels. Easy, Medium and Hard. ";
            // 
            // EasyLabel
            // 
            this.EasyLabel.AutoSize = true;
            this.EasyLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyLabel.Location = new System.Drawing.Point(64, 166);
            this.EasyLabel.Name = "EasyLabel";
            this.EasyLabel.Size = new System.Drawing.Size(247, 18);
            this.EasyLabel.TabIndex = 3;
            this.EasyLabel.Text = "Easy - This level is for beginners. ";
            // 
            // MediumLabel
            // 
            this.MediumLabel.AutoSize = true;
            this.MediumLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumLabel.Location = new System.Drawing.Point(64, 203);
            this.MediumLabel.Name = "MediumLabel";
            this.MediumLabel.Size = new System.Drawing.Size(335, 18);
            this.MediumLabel.TabIndex = 4;
            this.MediumLabel.Text = "Medium - This level is for intermediate players.";
            // 
            // HardLabel
            // 
            this.HardLabel.AutoSize = true;
            this.HardLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardLabel.Location = new System.Drawing.Point(64, 243);
            this.HardLabel.Name = "HardLabel";
            this.HardLabel.Size = new System.Drawing.Size(312, 18);
            this.HardLabel.TabIndex = 5;
            this.HardLabel.Text = "Hard - This level is for experienced players.";
            this.HardLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(152, 297);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(195, 51);
            this.PlayButton.TabIndex = 6;
            this.PlayButton.Text = "PLAY";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 406);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.HardLabel);
            this.Controls.Add(this.MediumLabel);
            this.Controls.Add(this.EasyLabel);
            this.Controls.Add(this.GameIntroLabel);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Label GameIntroLabel;
        private System.Windows.Forms.Label EasyLabel;
        private System.Windows.Forms.Label MediumLabel;
        private System.Windows.Forms.Label HardLabel;
        private System.Windows.Forms.Button PlayButton;
    }
}