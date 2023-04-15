namespace NumericalAnalysis
{
    static class Util
    {
        // This is a helper function that outputs the changes in sign, from + to -, and it accomodates for 0 too.
        public static char[] CalculateSign(double[] range)
        {
            // Initialize signmap with the input range.
            char[] signMap = new char[range.Length];
            // Loop through the range array and find where the sign changes
            for (int i = 0; i < range.Length; i++)
                if (range[i] > 0) signMap[i] = '+';
                else if (range[i] < 0) signMap[i] = '-';
                else signMap[i] = '0';
            return signMap;
        }
        public static double Func(double x)
        {
            return Math.Pow(x, 4) - Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + 2 * x + 1;
        }
        public static double Derivative(double x)
        {
            return 12 * x * x - 6 * x + 2;
        }
    }
}
