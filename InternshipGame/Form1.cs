using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipGame
{
    public partial class Form1 : Form
    {
        private GamePlay game = new GamePlay(54, 5, 70);
        private Bitmap bmp;
        public static Graphics graph;
        private List<Wall> walls = new List<Wall>(3);
        private Ball ball;
        private Platform platform;
        private List<Brick> bricks;

        public Form1()
        {
            InitializeComponent();
            CreateLevel();
            DrawEpisode();
            timer1.Start();
        }

        public void DrawEpisode()
        {
            for (int i = 0; i < bricks.Count; i++)
                bricks[i].Draw();
            for (int i = 0; i <= 2; i++)
                walls[i].Draw();
            ball.Draw();
            platform.Draw();
            pictureBox1.Image = bmp;
        }

        public void CreateLevel()
        {
            walls.Add(new Wall(0, 0, 15, 500));
            walls.Add(new Wall(0, 0, 400, 15));
            walls.Add(new Wall(400, 0, 15, 500));
            ball = new Ball(200, 350, 45, game.SpeedOfBall);
            platform = new Platform(200, 470, game.SizeOfPlatform);
            bricks = new List<Brick>(game.NumberOfBricks);
            for (int i = 0; i < game.NumberOfBricks; i++)
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        bricks.Add(new Brick(55 + i * 30, 50, 30));
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        bricks.Add(new Brick(55 + i * 30 - 300, 80, 30));
                        break;
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                        bricks.Add(new Brick(55 + i * 30 - 240, 80, 30));
                        break;
                    case 18:
                    case 19:
                        bricks.Add(new Brick(55 + i * 30 - 540, 110, 30));
                        break;
                    case 20:
                    case 21:
                        bricks.Add(new Brick(55 + i * 30 - 480, 110, 30));
                        break;
                    case 22:
                    case 23:
                        bricks.Add(new Brick(55 + i * 30 - 420, 110, 30));
                        break;
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                        bricks.Add(new Brick(55 + i * 30 - 660, 140, 30));
                        break;
                    case 30:
                    case 31:
                        bricks.Add(new Brick(55 + i * 30 - 900, 170, 30));
                        break;
                    case 32:
                    case 33:
                        bricks.Add(new Brick(55 + i * 30 - 840, 170, 30));
                        break;
                    case 34:
                    case 35:
                        bricks.Add(new Brick(55 + i * 30 - 780, 170, 30));
                        break;
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                        bricks.Add(new Brick(55 + i * 30 - 1080, 200, 30));
                        break;
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                        bricks.Add(new Brick(55 + i * 30 - 1020, 200, 30));
                        break;
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                        bricks.Add(new Brick(55 + i * 30 - 1320, 230, 30));
                        break;
                    default:
                        break;
                }
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            platform.Draw();
        }

        public void Reflection() // отражения
        {
            if (ball.X == walls[0].Width || ball.X == walls[2].X - ball.Width) // отражение от левой и правой стены
            {
                ball.Angle = -ball.Angle;
            }
            if (ball.Y == walls[1].Height) // отражение от верхней стены
            {
                if (ball.Angle == 45)
                    ball.Angle = ball.Angle + 90;
                else
                    ball.Angle = ball.Angle - 90;
            }
            if (ball.Y == platform.Y-ball.Height && ball.X >= platform.X && ball.X <= platform.X + platform.Width) // отражение от верхнего края платформы
            {
                if (ball.Angle == 135)
                    ball.Angle = ball.Angle - 90;
                else
                    ball.Angle = ball.Angle + 90;
            }
            if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height - ball.Height && ball.X == platform.X - ball.Width) // отражение от левого края платформы
            {
                ball.Angle = -ball.Angle;
            }
            if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height - ball.Height && ball.X == platform.X + platform.Width) // отражение от правого края платформы
            {
                ball.Angle = -ball.Angle;
            }
        }

        public void GameOver() // конец игры
        {
            if (ball.Y == 520)
            {
                MessageBox.Show(
                    "You lose",
                    "Game over",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // управление платформой
        {
            if (e.KeyData == Keys.Left)
            {
                platform.MoveLeft();
                DrawEpisode();
            }
            if (e.KeyData == Keys.Right)
            {
                platform.MoveRight();
                DrawEpisode();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
            Reflection();
            GameOver();
            DrawEpisode();
        }
    }
}
