using System.Drawing;

namespace InternshipGame
{
    class Ball : IBall
    {
        private int x;
        private int y;
        const int width = 10; // ширина
        const int height = 10; // высота
        private int angle; // угол движения
        const int speed = 5; // скорость движения

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public int Speed
        {
            get { return speed; }
        }

        public Ball(int x, int y, int angle)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
        }

        public void Draw(Graphics graph) // рисование шара
        {
            graph.DrawEllipse(Pens.Black, X, Y, Width, Height);
        }
    }
}
