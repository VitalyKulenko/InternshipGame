using System.Drawing;

namespace InternshipGame
{
    class Brick : IBrick
    {
        private int x;
        private int y;
        private int width; // ширина
        public const int height = 15; // высота

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
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
        }

        public Brick(int x, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
        }

        public void Draw(Graphics graph) // рисование кирпичика
        {
            graph.DrawRectangle(Pens.Black, X, Y, Width, Height);
        }
    }
}
