using System.Drawing;

namespace InternshipGame
{
    class Platform : IPlatform
    {
        private int x;
        private int y;
        private int width; // ширина
        const int height = 15; // высота

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

        public Platform(int x, int y, int sizeOfPlatform)
        {
            this.x = x;
            this.y = y;
            width = sizeOfPlatform;
        }

        public void Draw(Graphics graph) // рисование платформы
        {
            graph.DrawRectangle(Pens.Black, X, Y, Width, Height);
        }
    }
}
