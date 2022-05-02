using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace AirHockey
{
    public partial class AirHockey : Form
    {
        /// <summary>
        /// form1.Width = 510;
        ///     form1.width/2 = 255.5;
        ///                    - 80.0
        ///                     175.5
        ///                     
        /// form1.height = 705;
        ///     Form1.height/2 = 352.5;
        ///                      352
        /// </summary>

        Rectangle player1 = new Rectangle(235, 30, 40, 40);
        Rectangle player2 = new Rectangle(235, 595, 40, 40);
        Rectangle ball = new Rectangle(248, 345, 15, 15);

        Rectangle bottom = new Rectangle(0, 670, 510, 1);
        Rectangle top = new Rectangle(0, 0, 510, 1);
        Rectangle left = new Rectangle(-10, -10, 10, 705);
        Rectangle right = new Rectangle(500, -10, 10, 705);

        Rectangle p1Goal = new Rectangle(175, 1, 160, 2);
        Rectangle p2Goal = new Rectangle(176, 665, 160, 2);


        Brush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White, 2);

        int p1Score = 0;
        int p2Score = 0;
        int pXSpeed = 5;
        int pYSpeed = 4;

        int ballXSpeed = 8;
        int ballYSpeed = 6;


        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool leftArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;

        bool countingDown = true;

        Random random = new Random();
        public AirHockey()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ////Moving the players
            if (countingDown == false)
            {
                p2ScoreLabel.Text = $"{p2Score}";
                p1ScoreLabel.Text = $"{p1Score}";

                if (wDown == true && player1.Y > 0)
                {
                    player1.Y -= pYSpeed;
                }
                else if (sDown == true && player1.Y < this.Height - 80)
                {
                    player1.Y += pYSpeed;
                }

                if (upArrowDown == true && player2.Y > 0)
                {
                    player2.Y -= pYSpeed;
                }
                else if (downArrowDown == true && player2.Y < this.Height - 80)
                {
                    player2.Y += pYSpeed;
                }


                if (aDown == true && player1.X > 0)
                {
                    player1.X -= pXSpeed;
                }
                else if (dDown == true && player1.X < this.Width - 60)
                {
                    player1.X += pXSpeed;
                }

                if (leftArrowDown == true && player2.X > 0)
                {
                    player2.X -= pXSpeed;
                }
                else if (rightArrowDown == true && player2.X < this.Width - 60)
                {
                    player2.X += pXSpeed;
                }

                ////moving the ball
                ball.X += ballXSpeed;
                ball.Y += ballYSpeed;
                ///intersecting players
                if (ball.IntersectsWith(player1) && player1.Y > ball.Y || ball.IntersectsWith(player1) && player1.Y < ball.Y ||
                   ball.IntersectsWith(player2) && player1.Y > ball.Y || ball.IntersectsWith(player2) && player1.Y < ball.Y)
                {
                    ballYSpeed *= -1;
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();

                }
                if (ball.IntersectsWith(player1) && player1.X > ball.X || ball.IntersectsWith(player1) && player1.X < ball.X ||
                   ball.IntersectsWith(player2) && player1.X > ball.X || ball.IntersectsWith(player2) && player1.X < ball.X)
                {
                    ballXSpeed *= -1;
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();

                }
                ///intersecting walls
                ///
                if (ball.IntersectsWith(bottom))
                {
                    ballYSpeed = random.Next(-15, -5);
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();
                }
                else if (ball.IntersectsWith(top) || top.IntersectsWith(ball))
                {
                    ballYSpeed = random.Next(5, 15);
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();
                }
                if (ball.IntersectsWith(left))
                {
                    ballXSpeed = random.Next(6, 19);
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();
                }
                else if (ball.IntersectsWith(right))
                {
                    ballXSpeed = random.Next(-19, -6);
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.hit);
                    sound.Play();
                }
                ///Scoring goals
                if (ball.IntersectsWith(p1Goal))
                {

                    p2Score++;
                    player1.Location = new Point(235, 30);
                    player2.Location = new Point(235, 595);
                    ball.Location = new Point(248, 345);
                    p2ScoreLabel.Text = $"{p2Score}";
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.RPReplay_Final1651259595);
                    sound.Play();
                    if (p2Score == 3)
                    {
                        countdown.Text = "Player 2 wins!";
                        countdown.Visible = true;
                        countdown.Location = new Point(this.Width / 2 - countdown.Width / 2, this.Height / 2 - 100);
                        gameEngine.Enabled = false;

                        button1.Visible = true;
                        button1.Location = new Point(this.Width / 2 - button1.Width, 300);
                    }
                    else
                    {
                        countingDown = true;
                        secret.Text = "p1Goal";
                    }
                }
                else if (ball.IntersectsWith(p2Goal))
                {
                    p1Score++;
                    player1.Location = new Point(235, 30);
                    player2.Location = new Point(235, 595);
                    ball.Location = new Point(248, 345);
                    p1ScoreLabel.Text = $"{p1Score}";
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.RPReplay_Final1651259595);
                    sound.Play();
                    if (p1Score == 3)
                    {
                        countdown.Text = "Player 1 wins!";
                        countdown.Visible = true;
                        countdown.Location = new Point(this.Width / 2 - countdown.Width / 2, 220);
                        gameEngine.Enabled = false;

                        button1.Location = new Point(this.Width / 2 - button1.Width/2, 320);
                        button1.Visible = true;
                    }
                    else
                    {
                        countingDown = true;
                        secret.Text = "p2Goal";
                    }


                }
                else
                {
                    secret.Text = "playing";
                }

            }

            Refresh();
        }

        private void AirHockey_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }

        }

        private void AirHockey_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;

                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        public void Countdown()
        {
            countdown.Visible = true;
            countdown.Text = "3";
            countdown.Location = new Point(this.Width / 2 - countdown.Width / 2, 200);            
            Refresh();
            countdown.Text = "2";
            countdown.Location = new Point(this.Width / 2 - countdown.Width / 2, 200);
            Thread.Sleep(800);
            Refresh();
            countdown.Text = "1";
            countdown.Location = new Point(this.Width / 2 - countdown.Width / 2, 200);
            Thread.Sleep(800);
            Refresh();

            ballXSpeed = 8;
            ballXSpeed *= random.Next(-1, 2);
            while (ballXSpeed == 0)
            {
                ballXSpeed = 8;
                ballXSpeed *= random.Next(-1, 2);
            }

            ballYSpeed = 6;
            ballYSpeed *= random.Next(-1, 2);
            while (ballYSpeed == 0)
            {
                ballYSpeed = 6;
                ballYSpeed *= random.Next(-1, 2);
            }
            Thread.Sleep(800);
            Refresh();

            countdown.Visible = false;
            countingDown = false;
            this.Focus();
            Refresh();

        }
        private void AirHockey_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(whiteBrush, player1);
            e.Graphics.FillEllipse(whiteBrush, player2);

            e.Graphics.FillEllipse(whiteBrush, ball);

            e.Graphics.DrawEllipse(whitePen, this.Width / 2 - 80, this.Height / 2 - 80, 160, 160);

            //Goal circle thingies
            e.Graphics.DrawEllipse(whitePen, this.Width / 2 - 80, -80, 160, 130);
            e.Graphics.DrawEllipse(whitePen, this.Width / 2 - 80, this.Height - 90, 160, 130);

            //e.Graphics.DrawLine(whitePen, 0, this.Height / 2, this.Width, this.Height / 2);
            //e.Graphics.DrawLine(whitePen, this.Width / 2, 0, this.Width / 2, this.Height);

            //goals
            e.Graphics.FillRectangle(whiteBrush, p1Goal);
            e.Graphics.FillRectangle(whiteBrush, p2Goal);
        }


        private void secret_TextChanged(object sender, EventArgs e)
        {
            if (secret.Text == "playing")
            {

            }
            else
            {
                Countdown();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            gameEngine.Enabled = true;
            gameEngine.Start();
            p1Score = 0;
            p2Score = 0;
            p1ScoreLabel.Text = $"{p1Score}";
            p2ScoreLabel.Text = $"{p2Score}";
            button1.Visible = false;
            button1.Text = "PLAY AGAIN?";
            Countdown();
        }
    }
}

        
