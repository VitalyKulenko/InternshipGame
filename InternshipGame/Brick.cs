using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipGame
{
    class Brick : IDraw, ILocation, ISize, IDisappear
    {
        private float x;
        private float y;
        private float width;
        public const int height = 15;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public Brick(float x, float y, float width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
        }

        public void Draw()
        {
            Form1.graph.DrawRectangle(Pens.Black, x, y, width, height);
        }

        public void Disappear()
        {

        }
    }
}
