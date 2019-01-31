namespace InternshipGame
{
    class Ball : IBall
    {
        private float x;
        private float y;
        const int width = 10; // ширина
        const int height = 10; // высота
        private float angle; // угол движения
        private float speed; // скорость движения

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
    }
}
