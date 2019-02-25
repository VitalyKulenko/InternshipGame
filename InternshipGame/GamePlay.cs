namespace InternshipGame
{
    class GamePlay
    {
        private int numberOfBricks; // количество кирпичей
        private int angleMoveOfBall; // угол движения шара
        private int sizeOfPlatform; // размер платформы

        public int NumberOfBricks
        {
            get { return numberOfBricks; }
            set { numberOfBricks = value; }
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

        public GamePlay(int numberOfBricks, int angleMoveOfBall, int sizeOfPlatform)
        {
            this.numberOfBricks = numberOfBricks;
            this.sizeOfPlatform = sizeOfPlatform;
            this.angleMoveOfBall = angleMoveOfBall;
        }
    }
}
