namespace IPDP.Resources.Decorator
{
    public class InMaskPixel
    {
        public Pixel DecoratedPixel { get; set; }
        public int MaskX { get; protected set; }
        public int MaskY { get; protected set; }

        public InMaskPixel(Pixel pixel, int x, int y)
        {
            DecoratedPixel = pixel;
            MaskX = x;
            MaskY = y;
        }
    }
}
