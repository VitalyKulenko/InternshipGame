namespace InternshipGame
{
    class Platform : ILocation, ISize
    {
        private float x;
        private float y;
        private float width; // ширина
        const int height = 15; // высота

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
            width = sizeOfPlatform;
        }
    }
}
