using IPDP.Resources.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources
{
    public class ImageBuilder
    {
        protected Dictionary<String, IImageReader> Readers { get; set; }

        public ImageBuilder()
        {
            Readers = new Dictionary<String, IImageReader>();
            Readers.Add("bmp", new BmpReader());
            Readers.Add("png", new PngReader());
        }

        public Image GetImage(String filename)
        {
            var extension = Path.GetExtension(filename).ToLower().Substring(1);
            if (Readers.ContainsKey(extension))
            {
                try
                {
                    return new Image(Readers[extension].ReadImage(filename));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            throw new Exception("Image type not supported.");
        }
    }
}
