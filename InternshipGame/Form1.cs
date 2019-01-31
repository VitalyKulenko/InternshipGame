using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InternshipGame
{
    public partial class Form1 : Form
    {
        private GamePlay game = new GamePlay(54, 5, 45, 70); // создание игры (кол-во кирпичиков, 
                                                             // скорость шара (максимальная пока 5, еще варианты 2.5, 1.25, 1, 0.5), 
                                                             // стартовый угол полета (работает пока только -135, -45, 45 и 135),
                                                             // длина платформы)
        private Bitmap bmp;
        private Graphics graph;
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

        private void DrawEpisode() // прорисовка каждого кадра
        {
            for (int i = 0; i < bricks.Count; i++)
                BrickDrawing(i);
            for (int i = 0; i <= 2; i++)
                WallDrawing(i);
            BallDrawing();
            PlatformDrawing();
            pictureBox1.Image = bmp;
        }

        private void CreateLevel() // создание объектов для уровня, можно менять расположение кирпичиков, 
        {                         // их количество задается выше
            walls.Add(new Wall(0, 0, 15, 500));
            walls.Add(new Wall(0, 0, 400, 15));
            walls.Add(new Wall(400, 0, 15, 500));
            ball = new Ball(200, 350, game.AngleMoveOfBall, game.SpeedOfBall);
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
            PlatformDrawing();
        }

        private void BallMovement() // движение шара
        {
            graph.Clear(Color.White);
            switch (ball.Angle)
            {
                case 45:
                    ball.X = ball.X + ball.Speed;
                    ball.Y = ball.Y - ball.Speed;
                    break;
                case -45:
                    ball.X = ball.X - ball.Speed;
                    ball.Y = ball.Y - ball.Speed;
                    break;
                case -135:
                    ball.X = ball.X - ball.Speed;
                    ball.Y = ball.Y + ball.Speed;
                    break;
                case 135:
                    ball.X = ball.X + ball.Speed;
                    ball.Y = ball.Y + ball.Speed;
                    break;
            }
            BallDrawing();
        }

        private void PlatformMovementLeft() // ограничитель движения платформы влево
        {
            graph.Clear(Color.White);
            if (platform.X > 15)
            {
                platform.X = platform.X - 5;
                PlatformDrawing();
            }
            else
                PlatformDrawing();
        }

        private void PlatformMovementRight() // ограничитель движения вправо
        {
            graph.Clear(Color.White);
            if (platform.X < 330)
            {
                platform.X = platform.X + 5;
                PlatformDrawing();
            }
            else
                PlatformDrawing();
        }

        private void BallDrawing() // рисование шара
        {
            graph.DrawEllipse(Pens.Black, ball.X, ball.Y, ball.Width, ball.Height);
        }

        private void PlatformDrawing() // рисование платформы
        {
            graph.DrawRectangle(Pens.Black, platform.X, platform.Y, platform.Width, platform.Height);
        }

        private void BrickDrawing(int i) // рисование кирпичика
        {
            graph.DrawRectangle(Pens.Black, bricks[i].X, bricks[i].Y, bricks[i].Width, bricks[i].Height);
        }

        private void WallDrawing(int i) // рисование стены
        {
            graph.FillRectangle(Brushes.Black, walls[i].X, walls[i].Y, walls[i].Width, walls[i].Height);
        }

        private void Reflection() // отражения
        {
            // отражение от левой и правой стены
            if (ball.X == walls[0].Width || ball.X == walls[2].X - ball.Width)
                ball.Angle = -ball.Angle;
            // отражение от верхней стены
            if (ball.Y == walls[1].Height)
            {
                if (ball.Angle == 45)
                    ball.Angle = ball.Angle + 90;
                else
                    ball.Angle = ball.Angle - 90;
            }
            // отражение от верхнего края платформы
            if (ball.Y == platform.Y - ball.Height && ball.X >= platform.X - ball.Width && ball.X <= platform.X + platform.Width)
            {
                if (ball.Angle == 135 && ball.X != platform.X + platform.Width)
                    ball.Angle = ball.Angle - 90;
                else
                    ball.Angle = ball.Angle + 90;
            }
            // отражение от левого края платформы
            if (ball.Angle == 45 || ball.Angle == 135)
                if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height - ball.Height && ball.X == platform.X - ball.Width)
                    ball.Angle = -ball.Angle;
            // отражение от правого края платформы
            if (ball.Angle == -45 || ball.Angle == -135)
                if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height - ball.Height && ball.X == platform.X + platform.Width)
                    ball.Angle = -ball.Angle;
            for (int i = 0; i < bricks.Count; i++)
            {
                int flag = 0;
                // отражение от верхнего края кирпичика
                if (ball.Y == bricks[i].Y - ball.Height && ball.X >= bricks[i].X - ball.Width && ball.X <= bricks[i].X + bricks[i].Width)
                    if (ball.Angle == 135 && ball.X != bricks[i].X + bricks[i].Width)
                    {
                        if (i <= bricks.Count - 2)
                        {
                            if (ball.X + ball.Width != bricks[i + 1].X || ball.Y - ball.Height != bricks[i + 1].Y)
                            {
                                ball.Angle = ball.Angle - 90;
                                flag++;
                            }
                            else
                            {
                                ball.Angle = ball.Angle - 90;
                                bricks.RemoveAt(i);
                            }
                        }
                        else
                        {
                            ball.Angle = ball.Angle - 90;
                            flag++;
                        }
                    }
                    else if (ball.Angle == -135 && ball.X != bricks[i].X - ball.Width)
                    {
                        if (i <= bricks.Count - 2)
                        {
                            if (ball.X != bricks[i + 1].X || ball.Y - ball.Height != bricks[i + 1].Y)
                            {
                                ball.Angle = ball.Angle + 90;
                                flag++;
                            }
                            else
                            {
                                ball.Angle = ball.Angle + 90;
                                bricks.RemoveAt(i + 1);
                            }
                        }
                        else
                        {
                            ball.Angle = ball.Angle + 90;
                            flag++;
                        }
                    }
                // отражение от нижнего края кирпичика
                if (ball.Y == bricks[i].Y + bricks[i].Height && ball.X >= bricks[i].X - ball.Width && ball.X <= bricks[i].X + bricks[i].Width)
                    if (ball.Angle == 45 && ball.X != bricks[i].X + bricks[i].Width)
                    {
                        if (i <= bricks.Count - 2)
                        {
                            if (ball.X + ball.Width != bricks[i + 1].X || ball.Y != bricks[i + 1].Y + bricks[i + 1].Height)
                            {
                                ball.Angle = ball.Angle + 90;
                                flag++;
                            }
                            else
                            {
                                ball.Angle = ball.Angle + 90;
                                bricks.RemoveAt(i);
                            }
                        }
                        else
                        {
                            ball.Angle = ball.Angle + 90;
                            flag++;
                        }
                    }
                    else if (ball.Angle == -45 && ball.X != bricks[i].X - ball.Width)
                    {
                        if (i <= bricks.Count - 2)
                        {
                            if (ball.X != bricks[i + 1].X || ball.Y != bricks[i + 1].Y + bricks[i + 1].Height)
                            {
                                ball.Angle = ball.Angle - 90;
                                flag++;
                            }
                            else
                            {
                                ball.Angle = ball.Angle - 90;
                                bricks.RemoveAt(i + 1);
                            }
                        }
                        else
                        {
                            ball.Angle = ball.Angle - 90;
                            flag++;
                        }
                    }
                // отражение от левого края кирпичика
                if (ball.Y >= bricks[i].Y - ball.Height && ball.Y <= bricks[i].Y + bricks[i].Height && ball.X == bricks[i].X - ball.Width)
                {
                    if (ball.Angle == 45 && (ball.Y != bricks[i].Y - ball.Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                    if (ball.Angle == 135 && (ball.Y != bricks[i].Y + bricks[i].Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                }
                // отражение от правого края кирпичика
                if (ball.Y >= bricks[i].Y - ball.Height && ball.Y <= bricks[i].Y + bricks[i].Height && ball.X == bricks[i].X + bricks[i].Width)
                {
                    if (ball.Angle == -45 && (ball.Y != bricks[i].Y - ball.Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                    if (ball.Angle == -135 && (ball.Y != bricks[i].Y + bricks[i].Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                }
                if (flag > 0)
                    bricks.RemoveAt(i);
            }
        }

        private void Lose() // проигрыш
        {
            if (ball.Y == 520)
            {
                timer1.Stop();
                var result = MessageBox.Show(
                    "You lose. Do you want to play again?",
                    "Game over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        private void Win() // выигрыш
        {
            if (bricks.Count == 0)
            {
                timer1.Stop();
                var result = MessageBox.Show(
                    "You win. Do you want to play again?",
                    "Game over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // управление платформой
        {
            if (e.KeyData == Keys.Left)
            {
                PlatformMovementLeft();
                DrawEpisode();
            }
            if (e.KeyData == Keys.Right)
            {
                PlatformMovementRight();
                DrawEpisode();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) // таймер
        {
            BallMovement();
            Reflection();
            Lose();
            Win();
            DrawEpisode();
        }
    }
}
