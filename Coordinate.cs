using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool TryParseCoordinate(string? str, out Coordinate? result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            string[] values = str.Split(",");

            if (values.Length != 2)
            {
                return false;
            }

            string xValue = values[0];
            string yValue = values[1];

            if (!int.TryParse(xValue, out int intValueX) || !int.TryParse(yValue, out int intValueY))
            {
                return false;
            }

            result = new Coordinate(intValueX, intValueY);
            return true;
        }
    }
}
