using IPDP.Resources.Reader;
using IPDP.Resources.Writer;
using System;
using System.Collections.Generic;
using System.IO;

namespace IPDP.Resources
{
    public class ImageBuilder
    {
        protected Dictionary<String, IImageReader> Readers { get; set; }
        protected Dictionary<String, IImageWriter> Writers { get; set; }

        public ImageBuilder()
        {
            Readers = new Dictionary<String, IImageReader>();
            Readers.Add("bmp", new BmpReader());
            Readers.Add("png", new PngReader());
            Writers = new Dictionary<String, IImageWriter>();
            Writers.Add("bmp", new BmpWriter());
            Writers.Add("png", new PngWriter());
        }

        public Image GetImage(String filename)
        {
            var extension = Path.GetExtension(filename).ToLower();
            if (extension == "")
            {
                return null;
            }
            extension = extension.Substring(1);
            if (Readers.ContainsKey(extension))
            {
                try
                {
                    return new Image(Readers[extension].ReadImage(filename));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            throw new Exception("Image type not supported.");
        }

        public void WriteImage(Image image, String filename)
        {
            var extension = Path.GetExtension(filename).ToLower().Substring(1);
            if (Readers.ContainsKey(extension))
            {
                try
                {
                    Writers[extension].WriteImage(image, filename);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            throw new Exception("Image type not supported.");
        }
    }
}
