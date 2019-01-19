using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipGame
{
    class Ball : Center, IDraw, IBall
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public void Draw()
        {

        }

        public void Move()
        {

        }
    }

    class Center
    {
        private double centerBallX;
        private double centerBallY;

        public double CenterBallX
        {
            get { return centerBallX; }
            set { centerBallX = value; }
        }

        public double CenterBallY
        {
            get { return centerBallY; }
            set { centerBallY = value; }
        }
    }
}
