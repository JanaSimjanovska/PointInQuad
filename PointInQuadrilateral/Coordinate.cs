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

        public static bool TryParse(string? str, out Coordinate? result)
        {
            bool returnValue = false;
            result = null;


            if (!string.IsNullOrWhiteSpace(str))
            {
                string[] values = str.Split(",");

                if (values.Length == 2)
                {
                    string xValue = values[0];
                    string yValue = values[1];

                    if (int.TryParse(xValue, out int intValueX) && int.TryParse(yValue, out int intValueY))
                    {
                        result = new Coordinate(intValueX, intValueY);
                        returnValue = true;
                    }
                }
            }

            return returnValue;
        }
    }
}
