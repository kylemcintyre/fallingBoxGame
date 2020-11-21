using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testFucked
{
    public partial class Form1 : Form
    {

        private Direction playerPosition;
        private SoundPlayer Player = new SoundPlayer();
        Random randomEnemyX = new Random();
        Random randomEnemyY = new Random();

        public Form1()
        {
           InitializeComponent();

            playerPosition = Direction.Left;

            // Set settings to default
            new Settings();
            lblScore.Text = Settings.Score.ToString();

            // Set game speed and start timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();

            //Play background sound
            SoundPlayer backgroundMusic = new SoundPlayer("music_background.wav"); //put your own .wave file path
            backgroundMusic.PlayLooping();

        }

        private void StartGame()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Reset labels and enemy visibility
            Settings.Score = 0;
            lblGameOver.Visible = false;
            label1.Visible = true;
            lblScore.Visible = true;
            lblScore.Text = Settings.Score.ToString();
            pbEnemy1.Visible = true;

            // Set settings to default
            new Settings();

            // Center the player
            pictureBox1.Location = new Point(250, 420);
            pbEnemy1.Location = new Point(randomX, randomY);
            pbEnemy2.Location = new Point(randomX, randomY);
            pbEnemy3.Location = new Point(randomX, randomY);
            pbEnemy4.Location = new Point(randomX, randomY);
            pbEnemy5.Location = new Point(randomX, randomY);
        }   // End of StartGame

        private void UpdateScreen(object sender, EventArgs e)
        {
            // Call player and enemy modules
            MovePlayer();
            Enemy();
            Enemy2();
            Enemy3();
            Enemy4();
            Enemy5();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            // Enable keys if game is playable
            if (Settings.GameOver == false)
                if (e.KeyCode == Keys.Right)
                {
                   playerPosition = Direction.Right;
                }
                else if (e.KeyCode == Keys.Left)
                {
                   playerPosition = Direction.Left;
                }

            // Start a new game using Enter key and gameover is true
            if ((Settings.GameOver == true) && (e.KeyCode == Keys.Enter))
            {
                pictureBox1.Location = new Point(250, 420);
                StartGame();
            }
            Invalidate();
        }

        private void MovePlayer()
        {
            // Collision with borders
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) || (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds)))
            {
                Die();
            }
        }

        private void Enemy()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Enemy drops
            pbEnemy1.Location = new Point(pbEnemy1.Location.X, pbEnemy1.Location.Y + 20);
            if ((pictureBox1.Bounds.IntersectsWith(pbEnemy1.Bounds)) || (pictureBox1.Bounds.IntersectsWith(pbEnemy2.Bounds)) || (pictureBox1.Bounds.IntersectsWith(pbEnemy3.Bounds)) || (pictureBox1.Bounds.IntersectsWith(pbEnemy4.Bounds)) || (pictureBox1.Bounds.IntersectsWith(pbEnemy5.Bounds)))
            {
                Die();
            }

            // Enemy missed player scores
            if (pbEnemy1.Bounds.IntersectsWith(pbFloor.Bounds))
            {
                // Respawn enemy to the top
                pbEnemy1.Location = new Point(randomX, randomY);



                // Add to score
                Settings.Score += Settings.Points;
                string Score = Settings.Score.ToString();
                lblScore.Text = Score;
            }

            Invalidate();
        }

        private void Enemy2()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Enemy drops
            pbEnemy2.Location = new Point(pbEnemy2.Location.X, pbEnemy2.Location.Y + 20);

            if (pictureBox1.Bounds.IntersectsWith(pbEnemy2.Bounds))
            {
                Die();
            }
            // Enemy missed player scores
            if (pbEnemy2.Bounds.IntersectsWith(pbFloor.Bounds))
            {
                // Respawn enemy to the top
                pbEnemy2.Location = new Point(randomX, randomY);

                // Add to score
                Settings.Score += Settings.Points;
                string Score = Settings.Score.ToString();
                lblScore.Text = Score;
            }

            Invalidate();
        }

        private void Enemy3()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Enemy drops
            pbEnemy3.Location = new Point(pbEnemy3.Location.X, pbEnemy3.Location.Y + 20);

            if (pictureBox1.Bounds.IntersectsWith(pbEnemy3.Bounds))
            {
                Die();
            }
            // Enemy missed player scores
            if (pbEnemy3.Bounds.IntersectsWith(pbFloor.Bounds))
            {
                // Respawn enemy to the top
                pbEnemy3.Location = new Point(randomX, randomY);

                // Add to score
                Settings.Score += Settings.Points;
                string Score = Settings.Score.ToString();
                lblScore.Text = Score;
            }

            Invalidate();
        }

        private void Enemy4()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Enemy drops
            pbEnemy4.Location = new Point(pbEnemy4.Location.X, pbEnemy4.Location.Y + 20);

            if (pictureBox1.Bounds.IntersectsWith(pbEnemy4.Bounds))
            {
                Die();
            }
            // Enemy missed player scores
            if (pbEnemy4.Bounds.IntersectsWith(pbFloor.Bounds))
            {
                // Respawn enemy to the top
                pbEnemy4.Location = new Point(randomX, randomY);

                // Add to score
                Settings.Score += Settings.Points;
                string Score = Settings.Score.ToString();
                lblScore.Text = Score;
            }

            Invalidate();
        }

        private void Enemy5()
        {
            int randomX = randomEnemyX.Next(30, 420);
            int randomY = randomEnemyY.Next(-1000, -200);

            // Enemy drops
            pbEnemy3.Location = new Point(pbEnemy5.Location.X, pbEnemy5.Location.Y + 20);

            if (pictureBox1.Bounds.IntersectsWith(pbEnemy5.Bounds))
            {
                Die();
            }
            // Enemy missed player scores
            if (pbEnemy5.Bounds.IntersectsWith(pbFloor.Bounds))
            {
                // Respawn enemy to the top
                pbEnemy5.Location = new Point(randomX, randomY);

                // Add to score
                Settings.Score += Settings.Points;
                string Score = Settings.Score.ToString();
                lblScore.Text = Score;
            }

            Invalidate();
        }


        private void Die()
        {
            // Change settings and labels for player death
            pbEnemy1.Location = new Point(1000, 1000);
            pbEnemy2.Location = new Point(1000, 1000);
            pbEnemy3.Location = new Point(1000, 1000);
            pbEnemy4.Location = new Point(1000, 1000);
            pbEnemy5.Location = new Point(1000, 1000);
            Settings.GameOver = true;
            string gameOver = "Game over \nFinal score: " + Settings.Score + "\nPress Enter to try again";
            lblGameOver.Text = gameOver;
            lblGameOver.Visible = true;
            label1.Visible = false;
            lblScore.Visible = false;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if (Settings.GameOver == false)
            {
                if (playerPosition == Direction.Right)
                {
                    pictureBox1.Location = new Point(x += 10, y);
                }
                else if (playerPosition == Direction.Left)
                {
                    pictureBox1.Location = new Point(x -= 10, y);
                }
            }
        }
    }
}
