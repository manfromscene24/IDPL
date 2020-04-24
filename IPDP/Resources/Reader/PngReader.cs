using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Reader
{
    public class PngReader : IImageReader
    {
        // de importat o alta biblioteca, precum emguCV, DotImaging. foloseste nuget
        protected class PngReaderAdapter
        {

        }

        public Pixel[,] ReadImage(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
