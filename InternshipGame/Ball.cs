using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipGame
{
    class Ball : IDraw, IBall
    {
        private float x;
        private float y;
        const int width = 10;
        const int height = 10;
        private float angle;
        private float speed;

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
        }

        public float Height
        {
            get { return height; }
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Ball(float x, float y, float angle, float speed)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
            this.speed = speed;
        }

        public void Draw()
        {
            Form1.graph.DrawEllipse(Pens.Black, x, y, width, height);
        }

        public void Move() // движение шара
        {
            Form1.graph.Clear(Color.White);
            switch (angle)
            {
                case 45:
                    x = x + speed;
                    y = y - speed;
                    break;
                case -45:
                    x = x - speed;
                    y = y - speed;
                    break;
                case -135:
                    x = x - speed;
                    y = y + speed;
                    break;
                case 135:
                    x = x + speed;
                    y = y + speed;
                    break;
            }
            Draw();
        }
    }
}
