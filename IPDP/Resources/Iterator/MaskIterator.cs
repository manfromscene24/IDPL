using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Iterator
{
    public class MaskIterator : ImageIterator
    {
        protected List<PositionedPixel> _maskedPixels;

        public IEnumerable<PositionedPixel> MaskedPixels 
        {
            get { return _maskedPixels.AsEnumerable(); }
        }
        public int MaskSize { get; protected set; }

        public MaskIterator(Image image, int maskSize) : base(image)
        {
            if (image == null || maskSize <= 0)
            {
                throw new Exception("Bad parameters.");
            }
            if (maskSize % 2 == 0)
            {
                maskSize += 1;
            }
            MaskSize = maskSize;
            _maskedPixels = new List<PositionedPixel>();
            for (var iRow = CurrentPixel.Y - MaskSize / 2; iRow <= CurrentPixel.Y + MaskSize / 2; iRow += 1)
            {
                for (var iCol = CurrentPixel.X - MaskSize / 2; iCol <= CurrentPixel.X + MaskSize / 2; iCol += 1)
                {
                    try
                    {
                        var temp = new PositionedPixel(TraversingImage[iRow, iCol], iCol, iCol);
                        _maskedPixels.Add(temp);
                    }
                    catch
                    {
                        // surpressing bad pixel access
                    }
                }
            }
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
            _maskedPixels.Clear();
            for (var iRow = CurrentPixel.Y - MaskSize / 2; iRow <= CurrentPixel.Y + MaskSize / 2; iRow += 1)
            {
                for (var iCol = CurrentPixel.X - MaskSize / 2; iCol <= CurrentPixel.X + MaskSize / 2; iCol += 1)
                {
                    try
                    {
                        var temp = new PositionedPixel(TraversingImage[iRow, iCol], iCol, iRow);
                        _maskedPixels.Add(temp);
                    }
                    catch
                    {
                        // surpressing bad pixel access
                    }
                }
            }
            return this;
        }

        public static MaskIterator operator +(MaskIterator iterator, int pixelsToJump)
        {
            return iterator.Add(pixelsToJump) as MaskIterator;
        }
    }
}
