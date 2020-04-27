using IPDP.Resources.Decorator;

namespace IPDP.Resources.Iterator
{
    public class PixelIterator : ImageIterator
    {
        public PixelIterator(Image image) : base(image)
        {

        }

        protected override ImageIterator Add(int pixelsToJump)
        {
            var newX = (CurrentPixel.X + pixelsToJump) % TraversingImage.Width;
            var newY = CurrentPixel.Y + (CurrentPixel.X + pixelsToJump) / TraversingImage.Width;
            if (newY >= TraversingImage.Height)
            {
                return null;
            }
            CurrentPixel = new PositionedPixel(TraversingImage[newY, newX], newX, newY);
            return this;
        }

        public static PixelIterator operator +(PixelIterator iterator, int pixelsToJump)
        {
            return iterator.Add(pixelsToJump) as PixelIterator;
        }
    }
}