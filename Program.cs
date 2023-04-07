#region CH1
double Bisection(double x1, double x2, double tol)
{
    double x3 = (x1 + x2) / 2;
    double fx1 = func(x1);
    double fx2 = func(x2);
    double fx3 = func(x3);
    if (Math.Abs(fx3) < tol) return x3;
    if (fx1 * fx3 < 0) return Bisection(x1, x3, tol);
    else return Bisection(x3, x2, tol);
}
void FindRoots(double x1, double x2)
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
        range[i] = func(x1 + i);
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
#endregion
#region CH2
double Trapezo(double[] fx, double h)
{
    double sum = 0;
    for (int i = 1; i < fx.Length - 1; i++) sum += fx[i];
    return (h / 2) * (fx[0] + 2 * sum+ fx[fx.Length - 1]);
}
double Simpson(double[] fx, double h)
{
    double sum = 0;
    int n=fx.Length-1;
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
        //if not divisible by 2 nor 3:

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
#endregion
double func(double x)
{
    return 0.35*Math.Pow(x,4)-5*Math.Pow(x,2)+5;
}

FindRoots(-5, 5);
