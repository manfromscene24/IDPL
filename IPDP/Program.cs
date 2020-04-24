using IPDP.Resources;
using IPDP.Resources.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ImageBuilder();
            var test = builder.GetImage("test.bmp");
            var writer = new BmpWriter();
            writer.WriteImage(test, "written.bmp");
        }
    }
}
