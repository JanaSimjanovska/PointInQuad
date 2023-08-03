using QuadrilateralExercise.Domain.Entities;
using QuadrilateralExercise.Helpers;
using QuadrilateralExercise.Services;
using System.Drawing;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {

        Point pointA = new Point(10, 4);
        Point pointB = new Point(6, 4);
        Point pointC = new Point(8, 6);
        Point pointD = new Point(8, 4);
        Point pointE = new Point(8, 4);
        Point pointF = new Point(10, 6);

        LineSegment line = new LineSegment(pointB, pointA);
        LineSegment line2 = new LineSegment(pointE, pointF);


        while (true)
        {
            List<Point> points = new List<Point>() { pointA, pointB, pointF, pointE };
            Point pointP = new Point(3, 4);
            try
            {
                Console.Clear();
                UIService.DisplayInstructions();
                List<Point> quadrilateralVertices = UIService.GetCoordinateInputList();
                Point pointToCheck = UIService.GetPointToCheck();
                LineSegment referenceHorizontalLine = PointCheckerService.GetReferenceHorizontalLineSegment(pointToCheck, quadrilateralVertices);
                Quadrilateral quadrilateral = new Quadrilateral(quadrilateralVertices);
                List<LineSegment> edges = new List<LineSegment>() { quadrilateral.AB, quadrilateral.BC, quadrilateral.CD, quadrilateral.DA };

                bool isOnAVertex = PointCheckerService.DoesPointLieOnAVertex(pointToCheck, quadrilateralVertices);
                bool isOnEdge = PointCheckerService.DoesPointLieOnOneOfTheEdges(pointToCheck, edges);

                if (isOnAVertex || isOnEdge)
                {
                    UIService.DisplayAnswer();
                }
                else
                {
                    int windingNumber = PointCheckerService.CalculateWindingNumber(referenceHorizontalLine, quadrilateral);
                    bool isPointInsideQuad = PointCheckerService.IsPointInsideQuadrilateral(windingNumber);
                    UIService.DisplayAnswer(isPointInsideQuad);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("\nOops, something went wrong :( Let's see what...");
                Console.WriteLine($"\n{ex.Message}");
                HelperClass.PressAnyKey();
            }
        }

    }
}