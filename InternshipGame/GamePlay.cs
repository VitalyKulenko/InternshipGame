using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipGame
{
    class GamePlay
    {
        private int numberOfBricks;
        private float speedOfBall;
        private float sizeOfPlatform;

        public int NumberOfBricks
        {
            get { return numberOfBricks; }
            set { numberOfBricks = value; }
        }

        public float SpeedOfBall
        {
            get { return speedOfBall; }
            set { speedOfBall = value; }
        }

        public float SizeOfPlatform
        {
            get { return sizeOfPlatform; }
            set { sizeOfPlatform = value; }
        }

        public GamePlay(int numberOfBricks, float speedOfBall, float sizeOfPlatform)
        {
            this.numberOfBricks = numberOfBricks;
            this.speedOfBall = speedOfBall;
            this.sizeOfPlatform = sizeOfPlatform;
        }
    }
}
