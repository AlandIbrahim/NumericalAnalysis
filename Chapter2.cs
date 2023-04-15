namespace NumericalAnalysis
{
    static class Chapter2
    {
        // Short and easy Trapezoidal method:
        public static double Trapezo(double a, double b,int n)
        {
            double h = (b - a)/n;// n is the number of intervals, the higher the n the more accurate the result.
            double sum = 0;
            for (int i = 1; i < n; i++)// we start from 1 because we don't want to add the first and last values twice.
                sum += Util.Func(a + i * h);
            return (h / 2) * (Util.Func(a) + 2 * sum + Util.Func(b));// the formula for the trapezoidal method.
        }
        // Fully functional Simpson's method:
        public static double Simpson(double a,double b, int n)
        {
            if (n <= 0) throw new Exception("value of n must be bigger than 0");// if n is zero or negative, this method cannot work and it'll throw an exception.
            double sum = 0;
            double[] fx = new double[n + 1];
            double h= (b - a) / n;
            for (int i = 0; i <= n; i++)
                fx[i] = Util.Func(a + i * h);
            if (n % 2 == 0)
            {
                //if divisible by 2:
                for (int i = 1; i < n; i += 2) sum += 4 * fx[i];
                for (int i = 2; i < n; i += 2) sum += 2 * fx[i];
                return (h / 3) * (fx[0] + sum + fx[n]);
            }
            else if (n % 3 == 0)
            {
                //if divisible by 3:
                for (int i = 1; i < n; i += 3) sum += 3 * fx[i];
                for (int i = 2; i < n; i += 3) sum += 3 * fx[i];
                for (int i = 3; i < n; i += 3) sum += 2 * fx[i];
                return (3 * h / 8) * (fx[0] + fx[n] + sum);
            }
            else
            {
                //if neither divisible by 2 nor 3:

                //calculate first half using 3h/8 method:
                sum = 3 * (fx[1] + fx[2]);
                double firstHalf = (3 * h / 8) * (fx[0] + sum + fx[3]);
                //end of first half;

                //calculate second half using h/3 method:
                sum = 0;
                for (int i = 4; i < n; i += 2) sum += 4 * fx[i];
                for (int i = 5; i < n; i += 2) sum += 2 * fx[i];
                double secondHalf = (h / 3) * (fx[3] + sum + fx[n]);
                //combine the two halves and return the result:
                return firstHalf + secondHalf;
            }
        }
    }
}
