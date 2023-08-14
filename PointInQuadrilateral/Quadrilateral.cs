using PointInQuadrilateral.CustomExceptions;
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
        public Coordinate? VertexA;
        public Coordinate? VertexB;
        public Coordinate? VertexC;
        public Coordinate? VertexD;

        private List<Coordinate> _vertices = new List<Coordinate>();

        public Quadrilateral(Coordinate a, Coordinate b, Coordinate c, Coordinate d)
        {
            //VertexA = a;
            //VertexB = b;
            //VertexC = c;
            //VertexD = d;
            AddVertex(a);
            AddVertex(b);
            AddVertex(c);
            AddVertex(d);
        }

        public Quadrilateral()
        {

        }

        public void AddVertex(Coordinate newCoordinate)
        {
            if (_vertices.Count == 4)
            {
                throw new QuadrilateralVerticesNumberExceeded("The quadrilateral already has all of its vertices");
            }
            else
            {
                if (_vertices.Count > 0)
                {
                    if (_vertices.Any(coordinate => coordinate.X == newCoordinate.X && coordinate.Y == newCoordinate.Y))
                    {
                        throw new RepeatingCoordinatesException("No two coordinates can be the same.");
                    }

                    _vertices.Add(newCoordinate);

                    if (_vertices.Count == 4)
                    {
                        if (!IsAClosedPolygon(_vertices))
                        {
                            throw new CollinearPointsException("The entered coordinates do not form a closed polygon.");
                        }

                        VertexA = _vertices[0];
                        VertexB = _vertices[1];
                        VertexC = _vertices[2];
                        VertexD = _vertices[3];
                    }
                }
                else
                {
                    _vertices.Add(newCoordinate);
                }
            }
        }

        private bool IsAClosedPolygon(List<Coordinate> coordinates)
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

        public List<Coordinate> Vertices
        {
            get => _vertices; 
        }
        public List<Coordinate> GetVerticesList()
        {
            return _vertices;
        }
    }
}
