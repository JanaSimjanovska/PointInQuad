using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral.CustomExceptions
{
    public class CollinearPointsException : Exception
    {
        public CollinearPointsException(string message) : base(message) { }

    }
}
