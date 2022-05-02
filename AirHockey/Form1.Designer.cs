namespace AirHockey
{
    partial class AirHockey
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirHockey));
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.countdown = new System.Windows.Forms.Label();
            this.secret = new System.Windows.Forms.Label();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // countdown
            // 
            this.countdown.AutoSize = true;
            this.countdown.Font = new System.Drawing.Font("MV Boli", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdown.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.countdown.Location = new System.Drawing.Point(300, 297);
            this.countdown.Name = "countdown";
            this.countdown.Size = new System.Drawing.Size(62, 65);
            this.countdown.TabIndex = 0;
            this.countdown.Text = "3";
            this.countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.countdown.Visible = false;
            // 
            // secret
            // 
            this.secret.AutoSize = true;
            this.secret.Location = new System.Drawing.Point(572, 26);
            this.secret.Name = "secret";
            this.secret.Size = new System.Drawing.Size(44, 16);
            this.secret.TabIndex = 1;
            this.secret.Text = "label1";
            this.secret.TextChanged += new System.EventHandler(this.secret_TextChanged);
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.AutoSize = true;
            this.p1ScoreLabel.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p1ScoreLabel.Location = new System.Drawing.Point(603, 9);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(45, 45);
            this.p1ScoreLabel.TabIndex = 2;
            this.p1ScoreLabel.Text = "0";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.AutoSize = true;
            this.p2ScoreLabel.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2ScoreLabel.Location = new System.Drawing.Point(12, 766);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(45, 45);
            this.p2ScoreLabel.TabIndex = 3;
            this.p2ScoreLabel.Text = "0";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(206, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "PLAY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AirHockey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(659, 820);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.secret);
            this.Controls.Add(this.countdown);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AirHockey";
            this.Text = "Air Hockey";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AirHockey_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirHockey_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AirHockey_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label countdown;
        private System.Windows.Forms.Label secret;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Button button1;
    }
}

