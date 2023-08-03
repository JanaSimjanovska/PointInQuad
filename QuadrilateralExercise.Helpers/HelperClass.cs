using QuadrilateralExercise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Helpers
{
    public class HelperClass
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue");
            char anyKey = Console.ReadKey(true).KeyChar;
        }

        public static bool IsPointEqualToAnotherPoint(Point pointP, List<Point> quadVertices)
        {
            return quadVertices.Any(point => Equals(point, pointP));
        }

        public static int IsInteger(string input)
        {
            bool isFirstInputInt = int.TryParse(input, out int coordinateValue);
            if (isFirstInputInt)
            {
                return coordinateValue;
            }
            else
            {
                throw new Exception("Please enter numerical values only");
            }
        }

        public static int GetOrientationOfPointTriplets(Point point1, Point point2, Point point3)
        {
            int value =
                (point2.Y - point1.Y) *
                (point3.X - point2.X) -
                (point2.X - point1.X) *
                (point3.Y - point2.Y);

            if (value == 0)
            {
                return 0;
            }

            return (value > 0) ? 1 : 2;
        }

        public static bool AreThreePointsCollinear(Point point1, Point point2, Point point3)
        {
            int x1 = point1.X;
            int y1 = point1.Y;
            int x2 = point2.X;
            int y2 = point2.Y;
            int x3 = point3.X;
            int y3 = point3.Y;

            int area = x1 * (y2 - y3) +
                       x2 * (y3 - y1) +
                       x3 * (y1 - y2);


            return area == 0;
        }

        public static bool DoesPointLieOnSegment(Point point, LineSegment edge)
        {
            int xp = point.X;
            int yp = point.Y;
            int xa = edge.p1.X;
            int ya = edge.p1.Y;
            int xb = edge.p2.X;
            int yb = edge.p2.Y;

            List<int> xList = new List<int>() { xa, xb };
            int x1 = xList.Max();
            int x2 = xList.Min();

            List<int> yList = new List<int>() { ya, yb };
            int y1 = yList.Max();
            int y2 = yList.Min();

            bool isXInRange = Enumerable.Range(x2, x1).Contains(xp);
            bool isYInRange = Enumerable.Range(y2, y1).Contains(yp);


            bool thirdCondition = ((x2 - x1) * (yp - y1) == (xp - x1) * (y2 - y1));

            if (isXInRange && isYInRange && thirdCondition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
