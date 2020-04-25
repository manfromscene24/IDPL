﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Writer
{
    public class BmpWriter : IImageWriter
    {
        public void WriteImage(Image image, string filename)
        {
            using (var bitmap = new Bitmap(image.Width, image.Height))
            {

                for (var iRow = 0; iRow < image.Height; iRow += 1)
                {
                    for (var iCol = 0; iCol < image.Width; iCol += 1)
                    {
                        var pixel = image[iRow, iCol];
                        bitmap.SetPixel(iCol, iRow, Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                    }
                }
                bitmap.Save(filename);
            }
        }
    }
}