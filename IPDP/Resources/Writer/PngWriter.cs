using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace IPDP.Resources.Writer
{
    public class PngWriter : IImageWriter
    {
        protected static class PngWriterAdapter
        {
            public static void WriteImage(Image image, string filename)
            {

                using (Image<Bgr, Byte> img = new Image<Bgr, Byte>(filename))
                {
                    img.Save(filename);
                }
            }
        }
        public void WriteImage(Image image, string filename)
        {
            PngWriterAdapter.WriteImage(image, filename);
        }
    }
}
