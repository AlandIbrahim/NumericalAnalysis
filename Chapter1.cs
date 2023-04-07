using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
    static class Chapter1
    {
        public static double Bisection(double x1, double x2, double tol)
        {
            double x3 = (x1 + x2) / 2;
            double fx1 = Util.func(x1);
            double fx3 = Util.func(x3);
            if (Math.Abs(fx3) < tol) return x3;
            if (fx1 * fx3 <= 0) return Bisection(x1, x3, tol);
            else return Bisection(x3, x2, tol);
        }
        public static void FindRoots(double x1, double x2)
        {
            // Calculate the length of the range array
            int rLength = (int)Math.Abs(x2 - x1);
            // Initialize the range and signShift arrays
            double[] range = new double[rLength];
            int[] signShift = new int[rLength];
            // Set all elements of signShift to -1
            for (int i = 0; i < rLength; i++)
                signShift[i] = -1;
            // Index to keep track of where to add elements to signShift
            int signShiftIndex = 0;
            // Fill the range array with values from the function
            for (int i = 0; i < rLength; i++)
                range[i] = Util.func(x1 + i);
            // Keep track of the previous sign of the function values
            bool previousSign = range[0] > 0;//true is positive, false is negative
                                             // Loop through the range array and find where the sign changes
            for (int i = 1; i < rLength; i++)
            {
                if (range[i] > 0 != previousSign)
                {
                    // Add the index where the sign change occurred to signShift
                    signShift[signShiftIndex] = i;
                    signShiftIndex++;
                }
                previousSign = range[i] > 0;
            }
            // Loop through signShift and print the roots found
            for (int i = 0; i < rLength; i++)
            {
                if (signShift[i] > 0)
                    Console.WriteLine($"found root at: x={x1 + signShift[i] - 1} to x={x1 + signShift[i]}");
                else
                    return;
            }
        }
        public static void BudensMethod(double x1, double x2)
        {

        }
    }
}
