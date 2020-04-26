using IPDP.Resources.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IPDP.Resources.Iterator
{
    public class MaskIterator : ImageIterator
    {
        protected List<PositionedPixel> _maskedPixels;
        protected List<InMaskPixel> _inMaskPixels;

        public IEnumerable<PositionedPixel> MaskedPixels 
        {
            get { return _maskedPixels.AsEnumerable(); }
        }
        public IEnumerable<InMaskPixel> InMaskPixels
        {
            get { return _inMaskPixels.AsEnumerable(); }
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
            _inMaskPixels = new List<InMaskPixel>();
            CollectPixels();
        }

        protected void CollectPixels()
        {
            _maskedPixels.Clear();
            _inMaskPixels.Clear();
            var topX = CurrentPixel.X - MaskSize / 2;
            var topY = CurrentPixel.Y - MaskSize / 2;
            for (var iRow = CurrentPixel.Y - MaskSize / 2; iRow <= CurrentPixel.Y + MaskSize / 2; iRow += 1)
            {
                for (var iCol = CurrentPixel.X - MaskSize / 2; iCol <= CurrentPixel.X + MaskSize / 2; iCol += 1)
                {
                    try
                    {
                        var positionedPixel = new PositionedPixel(TraversingImage[iRow, iCol], iCol, iRow);
                        var inMaskPixel = new InMaskPixel(TraversingImage[iRow, iCol], iCol - topX, iRow - topY);
                        _maskedPixels.Add(positionedPixel);
                        _inMaskPixels.Add(inMaskPixel);
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
            CollectPixels();
            return this;
        }

        public static MaskIterator operator +(MaskIterator iterator, int pixelsToJump)
        {
            return iterator.Add(pixelsToJump) as MaskIterator;
        }
    }
}
