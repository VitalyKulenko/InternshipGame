namespace InternshipGame
{
    class GamePlay
    {
        private int numberOfBricks; // количество кирпичей
        private float speedOfBall; // скорость шара
        private float angleMoveOfBall; // угол движения шара
        private float sizeOfPlatform; // размер платформы

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

        public float AngleMoveOfBall
        {
            get { return angleMoveOfBall; }
            set { angleMoveOfBall = value; }
        }

        public float SizeOfPlatform
        {
            get { return sizeOfPlatform; }
            set { sizeOfPlatform = value; }
        }

        public GamePlay(int numberOfBricks, float speedOfBall, float angleMoveOfBall, float sizeOfPlatform)
        {
            this.numberOfBricks = numberOfBricks;
            this.speedOfBall = speedOfBall;
            this.sizeOfPlatform = sizeOfPlatform;
            this.angleMoveOfBall = angleMoveOfBall;
        }
    }
}
