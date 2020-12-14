namespace DayThree
{
    public class Toboggan : IToboggan
    {
        public Slope Slope { get; }

        public Toboggan(Slope slope)
        {
            Slope = slope;
        }

        public Position Next(Position currentPosition)
        {
            return default;
        }
    }
}