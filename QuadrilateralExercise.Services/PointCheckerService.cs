using QuadrilateralExercise.Domain.Entities;
using QuadrilateralExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Services
{
    public class PointCheckerService
    {
        public static bool DoesPointLieOnAVertex(Point point, List<Point> vertices)
        {
            return HelperClass.IsPointEqualToAnotherPoint(point, vertices);
        }

        public static bool DoesPointLieOnAnEdge(Point point, LineSegment edge)
        {
            return HelperClass.DoesPointLieOnSegment(point, edge);
        }

        public static bool DoesPointLieOnOneOfTheEdges(Point point, List<LineSegment> edges) {
            return edges.Any(edge => DoesPointLieOnAnEdge(point, edge));
        }
        public static LineSegment GetReferenceHorizontalLineSegment(Point point, List<Point> vertices)
        {
            Point endPoint = new Point(GreatestXValue(vertices) + 1, point.Y);
            return new LineSegment(point, endPoint);
        }

        public static int GreatestXValue(List<Point> vertices)
        {
            List<int> allXValues = vertices.Select(point => point.X).ToList();
            return allXValues.Max();
        }

        public static bool DoLineSegmentsIntersect(LineSegment edge, LineSegment horizontalSegment)
        {
            int o1 = HelperClass.GetOrientationOfPointTriplets(edge.p1, edge.p2, horizontalSegment.p1);
            int o2 = HelperClass.GetOrientationOfPointTriplets(edge.p1, edge.p2, horizontalSegment.p2);
            int o3 = HelperClass.GetOrientationOfPointTriplets(horizontalSegment.p1, horizontalSegment.p2, edge.p1);
            int o4 = HelperClass.GetOrientationOfPointTriplets(horizontalSegment.p1, horizontalSegment.p2, edge.p2);

            if (o1 != o2 && o3 != o4)
            {
                return true;
            }

            return false;
        }

        public static int CalculateWindingNumber(LineSegment horizontalSegment, Quadrilateral quadrilateral)
        {
            int windingNumber = 0;

            LineSegment AB = quadrilateral.AB;
            LineSegment BC = quadrilateral.BC;
            LineSegment CD = quadrilateral.CD;
            LineSegment DA = quadrilateral.DA;

            bool ABIntersectsHorSeg = DoLineSegmentsIntersect(AB, horizontalSegment);
            bool BCIntersectsHorSeg = DoLineSegmentsIntersect(BC, horizontalSegment);
            bool CDIntersectsHorSeg = DoLineSegmentsIntersect(CD, horizontalSegment);
            bool DAIntersectsHorSeg = DoLineSegmentsIntersect(DA, horizontalSegment);

            if (ABIntersectsHorSeg)
            {
                windingNumber = CalculateWindingNumberPerIntersection(AB, horizontalSegment, windingNumber);
            }

            if (BCIntersectsHorSeg)
            {
                windingNumber = CalculateWindingNumberPerIntersection(BC, horizontalSegment, windingNumber);
            }

            if (CDIntersectsHorSeg)
            {
                windingNumber = CalculateWindingNumberPerIntersection(CD, horizontalSegment, windingNumber);
            }

            if (DAIntersectsHorSeg)
            {
                windingNumber = CalculateWindingNumberPerIntersection(DA, horizontalSegment, windingNumber);
            }

            return windingNumber;
        }

        public static int CalculateWindingNumberPerIntersection(LineSegment edge, LineSegment horizontalSegment, int windingNumber)
        {
            if (edge.p1.Y <= horizontalSegment.p1.Y)
            {
                windingNumber++;
            }
            else if (edge.p1.Y >= horizontalSegment.p1.Y)
            {
                windingNumber--;
            }
            return windingNumber;
        }

        public static bool IsPointInsideQuadrilateral (int windingNumber)
        {
            return Convert.ToBoolean(windingNumber);
        }

    }
}
