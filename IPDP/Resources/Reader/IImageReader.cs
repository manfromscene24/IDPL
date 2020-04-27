using System;

namespace IPDP.Resources.Reader
{
    public interface IImageReader
    {
        Pixel[,] ReadImage(String filename);
    }
}
