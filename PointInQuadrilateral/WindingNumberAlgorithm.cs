using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral
{
    public class WindingNumberAlgorithm
    {
        public static bool IsPointWithin(Coordinate point, Quadrilateral quadrilateral)
        {
            List<Coordinate> vertices = quadrilateral.GetVerticesList();
            int counter = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Y <= point.Y)
                {
                    if (i == vertices.Count - 1)
                    {
                        if (vertices[0].Y > point.Y)
                        {
                            if (IsLeft(vertices[i], vertices[0], point) > 0)
                            {
                                ++counter;
                            }
                        }
                    }
                    else
                    {
                        if (vertices[i + 1].Y > point.Y)
                        {
                            if (IsLeft(vertices[i], vertices[i + 1], point) > 0)
                            {
                                ++counter;
                            }
                        }
                    }
                }
                else
                {
                    if (i == vertices.Count - 1)
                    {
                        if (vertices[0].Y <= point.Y)
                        {
                            if (IsLeft(vertices[i], vertices[0], point) < 0)
                            {
                                --counter;
                            }
                        }

                    }
                    else
                    {
                        if (vertices[i + 1].Y <= point.Y)
                        {
                            if (IsLeft(vertices[i], vertices[i + 1], point) < 0)
                            {
                                --counter;
                            }
                        }
                    }
                }
            }
            return counter != 0;
        }

        private static int IsLeft(Coordinate pointA, Coordinate pointB, Coordinate pointToTest)
        {
            return ((pointB.X - pointA.X) * (pointToTest.Y - pointA.Y) - (pointToTest.X - pointA.X) * (pointB.Y - pointA.Y));
        }

        public static bool PointLiesOnEdge(Coordinate point, Quadrilateral quadrilateral)
        {
            List<Coordinate> coordinates = quadrilateral.GetVerticesList();

            int xp = point.X;
            int yp = point.Y;

            for (int i = 0; i < coordinates.Count; i++)
            {
                int xa = coordinates[i].X;
                int ya = coordinates[i].Y;

                int xb;
                int yb;

                if (i == coordinates.Count - 1)
                {
                    xb = coordinates[0].X;
                    yb = coordinates[0].Y;
                }
                else
                {
                    xb = coordinates[i + 1].X;
                    yb = coordinates[i + 1].Y;
                }

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
            }

            return false;
        }

    }
}
