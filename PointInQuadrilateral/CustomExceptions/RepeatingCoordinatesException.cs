using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral.CustomExceptions
{
    public class RepeatingCoordinatesException : Exception
    {
        public RepeatingCoordinatesException(string message) : base(message) { }
    }
}
