using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Domain.Entities
{
        public struct LineSegment
        {
            public LineSegment(Point point1, Point point2)
            {
               p1 = point1;
               p2 = point2;
            }

            public Point p1 { get; set; }

            public Point p2 { get; set; }
        }
}
