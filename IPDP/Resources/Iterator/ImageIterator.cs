using IPDP.Resources.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
