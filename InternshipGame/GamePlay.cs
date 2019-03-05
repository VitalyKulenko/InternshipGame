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
        }

        public int AngleMoveOfBall
        {
            get { return angleMoveOfBall; }
        }

        public int SizeOfPlatform
        {
            get { return sizeOfPlatform; }
        }

        public GamePlay(int numberOfBricks, int angleMoveOfBall, int sizeOfPlatform)
        {
            this.numberOfBricks = numberOfBricks;
            this.sizeOfPlatform = sizeOfPlatform;
            this.angleMoveOfBall = angleMoveOfBall;
        }
    }
}
