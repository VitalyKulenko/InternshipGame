using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipGame
{
    class Platform : IDraw, ILocation, ISize
    {
        private float x;
        private float y;
        private float width;
        const int height = 15;

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

        public float Height
        {
            get { return height; }
        }

        public Platform(float x, float y, float sizeOfPlatform)
        {
            this.x = x;
            this.y = y;
            this.width = sizeOfPlatform;
        }

        public void Draw()
        {
            Form1.graph.DrawRectangle(Pens.Black, x, y, width, height);
        }

        public void MoveLeft() // ограничитель движения влево
        {
            Form1.graph.Clear(Color.White);
            if (x > 15)
            {
                x = x - 5;
                Draw();
            }
            else
                Draw();
        }

        public void MoveRight() // ограничитель движения вправо
        {
            Form1.graph.Clear(Color.White);
            if (x < 330)
            {
                x = x + 5;
                Draw();
            }
            else
                Draw();
        }
    }
}
