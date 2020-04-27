using System;

namespace IPDP.Resources.Writer
{
    public interface IImageWriter
    {
        void WriteImage(Image image, String filename);
    }
}
