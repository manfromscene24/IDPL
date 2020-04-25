using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDP.Resources.Iterator
{
    public class PixelIterator : ImageIterator
    {
        public PixelIterator(Image image) : base(image)
        {
        }

        protected override ImageIterator Add(int pixelsToJump)
        {
            throw new NotImplementedException();
        }
    }
}
