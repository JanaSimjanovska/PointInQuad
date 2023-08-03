using QuadrilateralExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralExercise.Validators
{
    public class ValidatorClass
    {
        public static List<Point> ValidateNoCollinearity(List<Point> verticesList)
        {
            Point a = verticesList[0];
            Point b = verticesList[1];
            Point c = verticesList[2];
            Point d = verticesList[3];

            bool isFirstTripletCollinear = HelperClass.AreThreePointsCollinear(a, b, c);
            bool isSecondTripletCollinear = HelperClass.AreThreePointsCollinear(b, c, d);
            bool isThirdTripletCollinear = HelperClass.AreThreePointsCollinear(c, d, a);
            bool isFourthTripletCollinear = HelperClass.AreThreePointsCollinear(d, a, b);

            if (isFirstTripletCollinear
                || isSecondTripletCollinear
                || isThirdTripletCollinear
                || isFourthTripletCollinear)
            {
                throw new Exception("No three vertices of a quadrilateral can be collinear, please try again.");
            }
            else
            {
                return verticesList;
            }
        }

        public static List<Point> ValidateDistinctCoordinates(List<Point> verticesList)
        {
            if(verticesList.Distinct().Count() != verticesList.Count())
            {
                throw new Exception("All 4 points must be distinct from one another, please try again.");
            } else
            {
                return verticesList;
            }
        }
    }
}
