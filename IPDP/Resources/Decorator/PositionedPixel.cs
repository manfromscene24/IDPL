namespace IPDP.Resources.Decorator
{
    public class PositionedPixel
    {
        public Pixel DecoratedPixel { get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public PositionedPixel(Pixel pixel, int x, int y)
        {
            DecoratedPixel = pixel;
            X = x;
            Y = y;
        }
    }
}
