using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InternshipGame
{
    public partial class Form1 : Form
    {
        private GamePlay game = new GamePlay(54, 45, 70); // создание игры (кол-во кирпичиков, 
                                                             // стартовый угол движения шара,
                                                             // длина платформы)
        private Bitmap bmp;
        private Graphics graph;
        private List<Wall> walls = new List<Wall>(3);
        private Ball ball;
        private int limitOverrun; // насколько шар превысил границу объекта
        private int limitOverrun2;
        private Platform platform;
        private List<Brick> bricks;
        const int angleUpRight = 45; // угол движения вверх вправо
        const int angleUpLeft = -45; // угол движения вверх влево
        const int angleDownRight = 135; // угол движения вниз вправо
        const int angleDownLeft = -135; // угол движения вниз влево
        const int loseLevelPx = 520; // уровень проигрыша
        const int widthOfBrick = 30; // ширина кирпичей
        const int borderLeft = 15; // левая граница для платформы
        const int borderRight = 330; // правая граница для платформы

        public Form1()
        {
            InitializeComponent();
            CreateLevel();
            DrawEpisode();
            timer1.Interval = 27; // скорость игры, любое целое число
            timer1.Start();
        }

        private void DrawEpisode() // прорисовка каждого кадра
        {
            for (int i = 0; i < bricks.Count; i++)
                bricks[i].Draw(graph);
            for (int i = 0; i <= 2; i++)
                walls[i].Draw(graph);
            ball.Draw(graph);
            platform.Draw(graph);
            pictureBox1.Image = bmp;
        }

        private void CreateLevel() // создание объектов для уровня, можно менять расположение кирпичиков, 
        {                         // их количество задается выше
            walls.Add(new Wall(0, 0, 15, 500));
            walls.Add(new Wall(0, 0, 400, 15));
            walls.Add(new Wall(400, 0, 15, 500));
            ball = new Ball(200, 350, game.AngleMoveOfBall);
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
                        bricks.Add(new Brick(55 + i * 30, 50, widthOfBrick));
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        bricks.Add(new Brick(55 + i * 30 - 300, 80, widthOfBrick));
                        break;
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                        bricks.Add(new Brick(55 + i * 30 - 240, 80, widthOfBrick));
                        break;
                    case 18:
                    case 19:
                        bricks.Add(new Brick(55 + i * 30 - 540, 110, widthOfBrick));
                        break;
                    case 20:
                    case 21:
                        bricks.Add(new Brick(55 + i * 30 - 480, 110, widthOfBrick));
                        break;
                    case 22:
                    case 23:
                        bricks.Add(new Brick(55 + i * 30 - 420, 110, widthOfBrick));
                        break;
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                        bricks.Add(new Brick(55 + i * 30 - 660, 140, widthOfBrick));
                        break;
                    case 30:
                    case 31:
                        bricks.Add(new Brick(55 + i * 30 - 900, 170, widthOfBrick));
                        break;
                    case 32:
                    case 33:
                        bricks.Add(new Brick(55 + i * 30 - 840, 170, widthOfBrick));
                        break;
                    case 34:
                    case 35:
                        bricks.Add(new Brick(55 + i * 30 - 780, 170, widthOfBrick));
                        break;
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                        bricks.Add(new Brick(55 + i * 30 - 1080, 200, widthOfBrick));
                        break;
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                        bricks.Add(new Brick(55 + i * 30 - 1020, 200, widthOfBrick));
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
                        bricks.Add(new Brick(55 + i * 30 - 1320, 230, widthOfBrick));
                        break;
                    default:
                        break;
                }
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            platform.Draw(graph);
        }

        private void BallMovement() // движение шара
        {
            graph.Clear(Color.White);
            switch (ball.Angle)
            {
                case angleUpRight:
                    ball.X = ball.X + ball.Speed;
                    ball.Y = ball.Y - ball.Speed;
                    break;
                case angleUpLeft:
                    ball.X = ball.X - ball.Speed;
                    ball.Y = ball.Y - ball.Speed;
                    break;
                case angleDownLeft:
                    ball.X = ball.X - ball.Speed;
                    ball.Y = ball.Y + ball.Speed;
                    break;
                case angleDownRight:
                    ball.X = ball.X + ball.Speed;
                    ball.Y = ball.Y + ball.Speed;
                    break;
            }
            ball.Draw(graph);
        }

        private void PlatformMovementLeft() // ограничитель движения платформы влево
        {
            graph.Clear(Color.White);
            if (platform.X > borderLeft)
            {
                platform.X = platform.X - 10;
                platform.Draw(graph);
            }
            else
                platform.Draw(graph);
        }

        private void PlatformMovementRight() // ограничитель движения вправо
        {
            graph.Clear(Color.White);
            if (platform.X < borderRight)
            {
                platform.X = platform.X + 10;
                platform.Draw(graph);
            }
            else
                platform.Draw(graph);
        }

        private void Crash() // столкновение
        {
            limitOverrun = 0;
            // столкновение с левой стеной
            if (ball.X < walls[0].Width)
            {
                limitOverrun = walls[0].Width - ball.X;
                ball.X = ball.X + limitOverrun;
                ball.Y = ball.Y + limitOverrun;
            }
            // столкновение с правой стеной
            if (ball.X > walls[2].X - ball.Width)
            {
                limitOverrun = ball.X - walls[2].X + ball.Width;
                ball.X = ball.X - limitOverrun;
                ball.Y = ball.Y - limitOverrun;
            }
            // столкновение с верхней стеной
            if (ball.Y < walls[1].Height)
            {
                limitOverrun = walls[1].Height - ball.Y;
                ball.X = ball.X + limitOverrun;
                ball.Y = ball.Y + limitOverrun;
            }
            // столкновение с платформой
            if (ball.X >= platform.X - ball.Width && ball.X <= platform.X + platform.Width && ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height)
            {
                if (ball.Angle == angleDownRight)
                {
                    if (ball.X + ball.Width - platform.X == ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = platform.Y - ball.Y - ball.Height;
                        limitOverrun2 = platform.X - ball.X - ball.Width;
                        ball.X = ball.X + limitOverrun;
                        ball.Y = ball.Y + limitOverrun2;
                    }
                    if (ball.X + ball.Width - platform.X > ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = platform.Y - ball.Y - ball.Height;
                        ball.X = ball.X + limitOverrun;
                        ball.Y = ball.Y + limitOverrun;
                    }
                    if (ball.X + ball.Width - platform.X < ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = platform.X - ball.X - ball.Width;
                        ball.X = ball.X + limitOverrun;
                        ball.Y = ball.Y + limitOverrun;
                    }
                }
                if (ball.Angle == angleDownLeft)
                {
                    if (platform.X + platform.Width - ball.X == ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = platform.Y - ball.Y - ball.Height;
                        limitOverrun2 = ball.X - platform.X - platform.Width;
                        ball.X = ball.X - limitOverrun;
                        ball.Y = ball.Y + limitOverrun2;
                    }
                    if (platform.X + platform.Width - ball.X > ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = platform.Y - ball.Y - ball.Height;
                        ball.X = ball.X + limitOverrun;
                        ball.Y = ball.Y + limitOverrun;
                    }
                    if (platform.X + platform.Width - ball.X < ball.Y + ball.Height - platform.Y)
                    {
                        limitOverrun = ball.X - platform.X - platform.Width;
                        ball.X = ball.X - limitOverrun;
                        ball.Y = ball.Y - limitOverrun;
                    }
                }
            }
            // столкновение с кирпичиком
            for (int i = 0; i < bricks.Count; i++)
            {
                if (ball.X >= bricks[i].X - ball.Width && ball.X <= bricks[i].X + bricks[i].Width && ball.Y >= bricks[i].Y - ball.Height && ball.Y <= bricks[i].Y + bricks[i].Height)
                {
                    if (ball.Angle == angleDownRight)
                    {
                        if (ball.X + ball.Width - bricks[i].X == ball.Y + ball.Height - bricks[i].Y)
                        {
                            limitOverrun = bricks[i].Y - ball.Y - ball.Height;
                            limitOverrun2 = bricks[i].X - ball.X - ball.Width;
                            ball.X = ball.X + limitOverrun;
                            ball.Y = ball.Y + limitOverrun2;
                        }
                        if (ball.X - bricks[i].X > ball.Y + ball.Height - bricks[i].Y)
                        {
                            limitOverrun = bricks[i].Y - ball.Y - ball.Height;
                            ball.X = ball.X + limitOverrun;
                            ball.Y = ball.Y + limitOverrun;
                        }
                        if (ball.X + ball.Width - bricks[i].X < ball.Y - bricks[i].Y)
                        {
                            limitOverrun = bricks[i].X - ball.X - ball.Width;
                            ball.X = ball.X + limitOverrun;
                            ball.Y = ball.Y + limitOverrun;
                        }
                    }
                    if (ball.Angle == angleDownLeft)
                    {
                        if (platform.X + platform.Width - ball.X == ball.Y + ball.Height - platform.Y)
                        {
                            limitOverrun = bricks[i].Y - ball.Y - ball.Height;
                            limitOverrun2 = ball.X - bricks[i].X - platform.Width;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y + limitOverrun2;
                        }
                        if (bricks[i].X + bricks[i].Width - ball.X > ball.Y + ball.Height - bricks[i].Y)
                        {
                            limitOverrun = bricks[i].Y - ball.Y - ball.Height;
                            ball.X = ball.X + limitOverrun;
                            ball.Y = ball.Y + limitOverrun;
                        }
                        if (bricks[i].X + bricks[i].Width - ball.X < ball.Y - bricks[i].Y)
                        {
                            limitOverrun = ball.X - bricks[i].X - bricks[i].Width;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y - limitOverrun;
                        }
                    }
                    if (ball.Angle == angleUpRight)
                    {
                        if (ball.X + ball.Width - bricks[i].X == ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = bricks[i].Y + bricks[i].Height - ball.Y;
                            limitOverrun2 = bricks[i].X - ball.Width - ball.X;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y + limitOverrun2;
                        }
                        if (ball.X - bricks[i].X > ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = bricks[i].Y + bricks[i].Height - ball.Y;
                            if (ball.X - limitOverrun >= bricks[i].X || ball.Y - limitOverrun >= bricks[i].Y)
                            {
                                ball.X = ball.X - limitOverrun;
                                ball.Y = ball.Y - limitOverrun;
                            }
                        }
                        if (ball.X + ball.Width - bricks[i].X < ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = bricks[i].X - ball.Width - ball.X;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y - limitOverrun;
                        }
                    }
                    if (ball.Angle == angleUpLeft)
                    {
                        if (bricks[i].X + bricks[i].Width - ball.X == ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = bricks[i].Y + bricks[i].Height - ball.Y;
                            limitOverrun2 = ball.X - bricks[i].X - bricks[i].Width;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y + limitOverrun2;
                        }
                        if (bricks[i].X + bricks[i].Width - ball.X > ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = bricks[i].Y + bricks[i].Height - ball.Y;
                            if (ball.X + limitOverrun <= bricks[i].X || ball.Y + limitOverrun >= bricks[i].Y)
                            {
                                ball.X = ball.X + limitOverrun;
                                ball.Y = ball.Y + limitOverrun;
                            }
                        }
                        if (bricks[i].X + bricks[i].Width - ball.X < ball.Y - bricks[i].Y - bricks[i].Height)
                        {
                            limitOverrun = ball.X - bricks[i].X - bricks[i].Width;
                            ball.X = ball.X - limitOverrun;
                            ball.Y = ball.Y - limitOverrun;
                        }
                    }
                }
            }
            Reflection();
        }

        private void Reflection() // отражения
        {
            // отражение от левой и правой стены
            if (ball.X == walls[0].Width || ball.X == walls[2].X - ball.Width)
                ball.Angle = -ball.Angle;
            // отражение от верхней стены
            if (ball.Y == walls[1].Height)
            {
                if (ball.Angle == angleUpRight)
                    ball.Angle = ball.Angle + 90;
                else
                    ball.Angle = ball.Angle - 90;
            }
            // отражение от верхнего края платформы
            if (ball.Y == platform.Y - ball.Height && ball.X >= platform.X - ball.Width && ball.X <= platform.X + platform.Width)
            {
                if (ball.Angle == angleDownRight && ball.X != platform.X + platform.Width)
                    ball.Angle = ball.Angle - 90;
                else
                    ball.Angle = ball.Angle + 90;
            }
            // отражение от левого края платформы
            if (ball.Angle == angleUpRight || ball.Angle == angleDownRight)
                if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height && ball.X == platform.X - ball.Width)
                    ball.Angle = -ball.Angle;
            // отражение от правого края платформы
            if (ball.Angle == angleUpLeft || ball.Angle == angleDownLeft)
                if (ball.Y >= platform.Y - ball.Height && ball.Y <= platform.Y + platform.Height && ball.X == platform.X + platform.Width)
                    ball.Angle = -ball.Angle;
            for (int i = 0; i < bricks.Count; i++)
            {
                int flag = 0;
                // отражение от верхнего края кирпичика
                if (ball.Y == bricks[i].Y - ball.Height && ball.X >= bricks[i].X - ball.Width && ball.X <= bricks[i].X + bricks[i].Width)
                    if (ball.Angle == angleDownRight && ball.X != bricks[i].X + bricks[i].Width)
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
                    else if (ball.Angle == angleDownLeft && ball.X != bricks[i].X - ball.Width)
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
                    if (ball.Angle == angleUpRight && ball.X != bricks[i].X + bricks[i].Width)
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
                    else if (ball.Angle == angleUpLeft && ball.X != bricks[i].X - ball.Width)
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
                    if (ball.Angle == angleUpRight && (ball.Y != bricks[i].Y - ball.Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                    if (ball.Angle == angleDownRight && (ball.Y != bricks[i].Y + bricks[i].Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                }
                // отражение от правого края кирпичика
                if (ball.Y >= bricks[i].Y - ball.Height && ball.Y <= bricks[i].Y + bricks[i].Height && ball.X == bricks[i].X + bricks[i].Width)
                {
                    if (ball.Angle == angleUpLeft && (ball.Y != bricks[i].Y - ball.Height || flag == 1))
                    {
                        ball.Angle = -ball.Angle;
                        flag++;
                    }
                    if (ball.Angle == angleDownLeft && (ball.Y != bricks[i].Y + bricks[i].Height || flag == 1))
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
            if (ball.Y > loseLevelPx)
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
            Crash();
            Lose();
            Win();
            DrawEpisode();
        }
    }
}
