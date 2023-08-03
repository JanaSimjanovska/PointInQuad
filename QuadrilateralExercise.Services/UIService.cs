using QuadrilateralExercise.Helpers;
using QuadrilateralExercise.Validators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Services
{
    public class UIService
    {
        public static void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===========================================================================\n");
            Console.WriteLine("Enter 4 coordinates, each containing an integer for the x and the y values,\n" +
                "and then then the coordinates for a point you wish to check whether it lies\n" +
                "inside the quadrilateral formed by the first 4 coordinates you entered");
            Console.WriteLine("\n===========================================================================");
            Console.ResetColor();
        }

        public static Point GetCoordinateInput()
        {
            Console.WriteLine("Enter x value:");

            bool isXNumber = int.TryParse(Console.ReadLine(), out int x);

            Console.WriteLine("Enter y value:");

            bool isYNumber = int.TryParse(Console.ReadLine(), out int y);

            if (!isXNumber || !isYNumber)
            {
                throw new Exception("Coordinate values can only be integers, please try again.");
            }
            else
            {
                return new Point(x, y);
            }
        }

        public static List<Point> GetCoordinateInputList()
        {
            List<Point> quadrilateralVerticesList = new List<Point>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter values for coordinate number {i + 1}:");
                Point point = GetCoordinateInput();
                quadrilateralVerticesList.Add(point);
            }

            List<Point> distinctCoords = ValidatorClass.ValidateDistinctCoordinates(quadrilateralVerticesList);
            return ValidatorClass.ValidateNoCollinearity(distinctCoords);
        }

        public static Point GetPointToCheck()
        {
            Console.Clear();
            Console.WriteLine($"Enter values for the coordinate you want to check if it lies within the quadrilateral:");
            Point point = GetCoordinateInput();

            return point;
        }

        public static void DisplayAnswer(bool isPointInside)
        {
            if (isPointInside) Console.WriteLine("The entered point lies within the quadrilateral.");
            else Console.WriteLine("The entered point does not lie within the quadrilateral.");
            EndMessage();
        }

        public static void DisplayAnswer()
        {
            Console.WriteLine("The entered point lies within the quadrilateral.");
            EndMessage();
        }

        public static void EndMessage()
        {
            Console.WriteLine("Thank you for using our application.\n" +
                "To check another point");
            HelperClass.PressAnyKey();
        }
    }
}
