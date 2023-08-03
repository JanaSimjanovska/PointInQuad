using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Domain.Entities
{
    public class Quadrilateral 
    {
        public Point vertexA; public Point vertexB; public Point vertexC; public Point vertexD;

        public LineSegment AB;
        public LineSegment BC;
        public LineSegment CD;
        public LineSegment DA;

        public Quadrilateral(List<Point> verticesList)
        {
            AB = new LineSegment(verticesList[0], verticesList[1]);
            BC = new LineSegment(verticesList[1], verticesList[2]);
            CD = new LineSegment(verticesList[2], verticesList[3]);
            DA = new LineSegment(verticesList[3], verticesList[0]);
        }
    }
}
