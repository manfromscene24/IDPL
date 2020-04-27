using IPDP.Resources.Decorator;

namespace IPDP.Resources.Iterator
{
    public abstract class ImageIterator
    {
        protected Image TraversingImage;

        public PositionedPixel CurrentPixel { get; set; }

        public ImageIterator(Image image)
        {
            TraversingImage = image;
            CurrentPixel = new PositionedPixel(image[0, 0], 0, 0);
        }

        protected abstract ImageIterator Add(int pixelsToJump);

        public static ImageIterator operator +(ImageIterator iterator, int pixelsToJump)
        {
            return iterator.Add(pixelsToJump);
        }
    }
}
