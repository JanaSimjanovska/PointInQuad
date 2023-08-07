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

            while(!Coordinate.TryParseCoordinate(input, out newCoordinate))
            {
                DisplayColoredMessage("Invalid input.", ConsoleColor.Magenta);
                DisplayColoredMessage("Enter comma separated x and y integer values:", ConsoleColor.Blue);
                input = Console.ReadLine();
            }

            //while (ValidatorClass.IsEmpty(input) || !ValidatorClass.AreXAndYCommaSeparatedIntegers(input))
            //{
            //    if (ValidatorClass.IsEmpty(input))
            //    {
            //        DisplayColoredMessage("Input must not be empty", ConsoleColor.Magenta);
            //    }
            //    if (!ValidatorClass.AreXAndYCommaSeparatedIntegers(input))
            //    {
            //        DisplayColoredMessage("Invalid input.", ConsoleColor.Magenta);
            //    }

            //    DisplayColoredMessage("Enter comma separated x and y integer values:", ConsoleColor.Blue);
            //    input = Console.ReadLine();
            //}

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
                EndMessage();
            };
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
            List<Coordinate> coordinateList = new List<Coordinate>();

            for (int i = 0; i < 4; i++)
            {
                DisplayColoredMessage($"Enter coordinate number {i + 1}", ConsoleColor.Cyan);

                Coordinate newCoordinate = GetCoordinateInput();

                if (i == 0)
                {
                    coordinateList.Add(newCoordinate);
                }
                else
                {
                    while (coordinateList.Any(coordinate => coordinate.X == newCoordinate.X && coordinate.Y == newCoordinate.Y))
                    {
                        DisplayColoredMessage("No two coordinates can be the same, please try a different value.", ConsoleColor.Magenta);
                        newCoordinate = GetCoordinateInput();
                    }

                    coordinateList.Add(newCoordinate);
                }
            }
            Quadrilateral quadrilateral = new Quadrilateral(coordinateList[0], coordinateList[1], coordinateList[2], coordinateList[3]);
            return quadrilateral;
        }

        public static void UIFlow()
        {
            Console.Clear();

            DisplayInstructions();
            Quadrilateral quadrilateral = GetQuadrilateral();
            //bool isACLosedPolygon = ValidatorClass.IsAClosedPolygon(quadrilateral.GetVerticesList());

            //while (!isACLosedPolygon)
            //{
            //    DisplayColoredMessage("The coordinates you entered do not form a closed polygon. Please try again.", ConsoleColor.Magenta);
            //    quadrilateral = GetQuadrilateral();
            //}

            Coordinate pointToCheck = GetPointToCheck();

            if (WindingNumberAlgorithm.PointLiesOnEdge(pointToCheck, quadrilateral.GetVerticesList()))
            {
                DisplayAnswer();
            }

            //bool isPointWithin = WindingNumberAlgorithm.IsPointWithin(pointToCheck, quadrilateral.GetVerticesList());

            //DisplayAnswer(isPointWithin);
        }
    }
}
