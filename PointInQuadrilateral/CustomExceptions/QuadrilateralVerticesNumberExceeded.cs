using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral.CustomExceptions
{
    public class QuadrilateralVerticesNumberExceeded : Exception
    {
        public QuadrilateralVerticesNumberExceeded(string message) : base(message) { }
    }
}
