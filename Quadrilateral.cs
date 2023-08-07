using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral
{
    public class Quadrilateral
    {
        public Coordinate VertexA;
        public Coordinate VertexB;
        public Coordinate VertexC;
        public Coordinate VertexD;

        public Quadrilateral(Coordinate a, Coordinate b, Coordinate c, Coordinate d)
        {
            VertexA = a;
            VertexB = b;
            VertexC = c;
            VertexD = d;

            if(!IsAClosedPolygon(GetVerticesList()))
            {
                throw new Exception("The entered points do not form a closed polygon. Please try again.");
            }
        }
        private static bool IsAClosedPolygon(List<Coordinate> coordinates)
        {
            List<int> areaOfThreePointsList = new List<int>();
            for (int i = 0; i < coordinates.Count - 2; i++)
            {
                Coordinate point1 = coordinates[i];
                Coordinate point2 = coordinates[i + 1];
                Coordinate point3 = coordinates[i + 2];

                int x1 = point1.X;
                int y1 = point1.Y;
                int x2 = point2.X;
                int y2 = point2.Y;
                int x3 = point3.X;
                int y3 = point3.Y;

                int area = x1 * (y2 - y3) +
                       x2 * (y3 - y1) +
                       x3 * (y1 - y2);

                areaOfThreePointsList.Add(area);
            }

            return !areaOfThreePointsList.All(area => area == 0);
        }
        public List<Coordinate> GetVerticesList()
        {
            return new List<Coordinate>() { VertexA, VertexB, VertexC, VertexD };
        }
    }
}
