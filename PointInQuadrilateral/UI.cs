using PointInQuadrilateral.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInQuadrilateral
{
    public class UI
    {
        public static void DisplayColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===========================================================================\n");
            Console.WriteLine("Enter 4 coordinates, 4 comma separated x and y integer values,\n" +
                "and then then the coordinates for a point you wish to check whether it lies\n" +
                "inside the quadrilateral formed by the first 4 coordinates you entered");
            Console.WriteLine("\n===========================================================================");
            Console.ResetColor();
        }

        public static Coordinate GetCoordinateInput()
        {
            DisplayColoredMessage("Enter comma separated x and y integer values:", ConsoleColor.Blue);
            string input = Console.ReadLine();
            Coordinate? newCoordinate = null;

            while (!Coordinate.TryParse(input, out newCoordinate))
            {
                DisplayColoredMessage("Invalid input.", ConsoleColor.Magenta);
                DisplayColoredMessage("Enter comma separated x and y integer values:", ConsoleColor.Blue);
                input = Console.ReadLine();
            }

            return newCoordinate;
        }

        public static Coordinate GetPointToCheck()
        {
            Console.Clear();
            DisplayColoredMessage($"Enter values for the coordinate you want to check if it lies within the quadrilateral:", ConsoleColor.Cyan);
            Coordinate point = GetCoordinateInput();

            return point;
        }

        public static void DisplayAnswer(bool isPointInside)
        {
            if (isPointInside)
            {
                DisplayColoredMessage("The entered point lies within the quadrilateral.", ConsoleColor.Green);
            }
            else
            {
                DisplayColoredMessage("The entered point does not lie within the quadrilateral.", ConsoleColor.Magenta);
            };
            EndMessage();
        }

        public static void DisplayAnswer()
        {
            DisplayColoredMessage("The entered point lies within the quadrilateral.", ConsoleColor.Green);
            EndMessage();
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue");
            char anyKey = Console.ReadKey(true).KeyChar;
        }
        public static void EndMessage()
        {
            Console.WriteLine("Thank you for using our application.\n" +
                "To check another point");
            PressAnyKey();
        }

        public static Quadrilateral GetQuadrilateral()
        {
            Quadrilateral quadrilateral = new Quadrilateral();
            while (quadrilateral.GetVerticesList().Count != 4)
            {
                DisplayColoredMessage($"Enter coordinate number {quadrilateral.GetVerticesList().Count + 1}", ConsoleColor.Cyan);

                Coordinate newCoordinate = GetCoordinateInput();

                try
                {
                    quadrilateral.AddVertex(newCoordinate);
                }
                catch (RepeatingCoordinatesException e)
                {
                    DisplayColoredMessage(e.Message, ConsoleColor.Magenta);
                }
                catch (CollinearPointsException e)
                {
                    DisplayColoredMessage(e.Message, ConsoleColor.Magenta);
                    GetQuadrilateral();
                }

            }
            return quadrilateral;
        }

        public static void UIFlow()
        {
            Console.Clear();
            DisplayInstructions();
            Quadrilateral quadrilateral = GetQuadrilateral();
            Coordinate pointToCheck = GetPointToCheck();
            if (WindingNumberAlgorithm.PointLiesOnEdge(pointToCheck, quadrilateral))
            {
                DisplayAnswer();
            }
            else
            {
                bool isPointWithin = WindingNumberAlgorithm.IsPointWithin(pointToCheck, quadrilateral);
                DisplayAnswer(isPointWithin);
            }
        }
    }
}
