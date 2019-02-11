namespace InternshipGame
{
    class GamePlay
    {
        private int numberOfBricks; // количество кирпичей
        private int speedOfBall; // скорость шара
        private int angleMoveOfBall; // угол движения шара
        private int sizeOfPlatform; // размер платформы

        public int NumberOfBricks
        {
            get { return numberOfBricks; }
            set { numberOfBricks = value; }
        }

        public int SpeedOfBall
        {
            get { return speedOfBall; }
            set { speedOfBall = value; }
        }

        public int AngleMoveOfBall
        {
            get { return angleMoveOfBall; }
            set { angleMoveOfBall = value; }
        }

        public int SizeOfPlatform
        {
            get { return sizeOfPlatform; }
            set { sizeOfPlatform = value; }
        }

        public GamePlay(int numberOfBricks, int speedOfBall, int angleMoveOfBall, int sizeOfPlatform)
        {
            this.numberOfBricks = numberOfBricks;
            this.speedOfBall = speedOfBall;
            this.sizeOfPlatform = sizeOfPlatform;
            this.angleMoveOfBall = angleMoveOfBall;
        }
    }
}
