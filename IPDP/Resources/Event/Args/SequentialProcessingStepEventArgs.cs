using IPDP.Resources.Decorator;
using System;

namespace IPDP.Resources.Event.Args
{
    public class SequentialProcessingStepEventArgs : EventArgs
    {
        public Image ProcessingImage { get; protected set; }
        public PositionedPixel CurrentPixel { get; protected set; }

        public SequentialProcessingStepEventArgs(Image image, PositionedPixel pixel)
        {
            ProcessingImage = image;
            CurrentPixel = pixel;
        }
    }
}
