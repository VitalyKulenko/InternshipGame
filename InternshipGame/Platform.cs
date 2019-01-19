using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipGame
{
    class Platform : IDraw, ILocation, ISize
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;
        private double x4;
        private double y4;
        private double length;
        private double width;

        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public double Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        public double Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public double X3
        {
            get { return x3; }
            set { x3 = value; }
        }

        public double Y3
        {
            get { return y3; }
            set { y3 = value; }
        }

        public double X4
        {
            get { return x4; }
            set { x4 = value; }
        }

        public double Y4
        {
            get { return y4; }
            set { y4 = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public void Draw()
        {

        }
    }
}
