using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral
{
    public class ValidatorClass
    {
        public static Coordinate ParseCommaSeparatedValuesInput(string input)
        {
            string[] values = input.Split(",");

            string xValue = values[0];
            string yValue = values[1];

            return new Coordinate(int.Parse(xValue), int.Parse(yValue));
        }

        //public static bool IsEmpty(string input)
        //{
        //    return input.Length == 0;
        //}

        //public static bool AreXAndYCommaSeparatedIntegers (string input) {
        //    string[] values = input.Split(",");
           
        //    if(values.Length != 2)
        //    {
        //        return false;
        //    }

        //    string xValue = values[0];
        //    string yValue = values[1];
        //    if (!IsInteger(xValue) || !IsInteger(yValue))
        //    {
        //        return false;
        //    }
            
        //    return true;
        //}

        //public static bool IsInteger(string input)
        //{
        //    bool isInputInt = int.TryParse(input, out int coordinateValue);
        //    if (isInputInt)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public static bool IsAClosedPolygon(List<Coordinate> coordinates)
        //{
        //    List<int> areaOfThreePointsList = new List<int>();
        //    for (int i = 0; i < coordinates.Count - 2; i++)
        //    {
        //        Coordinate point1 = coordinates[i];
        //        Coordinate point2 = coordinates[i + 1];
        //        Coordinate point3 = coordinates[i + 2];

        //        int x1 = point1.X;
        //        int y1 = point1.Y;
        //        int x2 = point2.X;
        //        int y2 = point2.Y;
        //        int x3 = point3.X;
        //        int y3 = point3.Y;

        //        int area = x1 * (y2 - y3) +
        //               x2 * (y3 - y1) +
        //               x3 * (y1 - y2);

        //        areaOfThreePointsList.Add(area);
        //    }

        //    return !areaOfThreePointsList.All(area => area == 0);
        //}
    }
}
