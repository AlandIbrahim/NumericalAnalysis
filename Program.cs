double Trapezo(double[] fx, double h)
{
    double sum = 0;
    for (int i = 1; i < fx.Length - 1; i++) sum += fx[i];
    return (h / 2) * (fx[0] + 2 * sum+ fx[fx.Length - 1]);
}
double Simpson(double[] fx, double h)
{
    double sum = 0;
    if (fx.Length % 2 == 0)
    {
        //if divisible by 2:
        for (int i = 1; i < fx.Length - 1; i += 2) sum += 4 * fx[i];
        for (int i = 2; i < fx.Length - 1; i += 2) sum += 2 * fx[i];
        return (h / 3) * (fx[0] + sum + fx[fx.Length - 1]);
    }
    else if (fx.Length % 3 == 0)
    {
        //if divisible by 3:
        for (int i = 1; i < fx.Length - 1; i += 3) sum += 3 * fx[i];
        for (int i = 2; i < fx.Length - 1; i += 3) sum += 3 * fx[i];
        for (int i = 3; i < fx.Length - 1; i += 3) sum += 2 * fx[i];
        return (8 * h / 3) * (fx[0] + fx[fx.Length - 1] + sum);
    }
    else
    {
        //if not divisible by 2 nor 3:

        //calculate first half using 3h/8 method:
        sum = 3 * (fx[1] + fx[2]);
        double firstHalf = (8 * h / 3) * (fx[0] + sum + fx[3]);
        //end of first half;

        //calculate second half using h/3 method:
        sum = 0;
        for (int i = 3; i < fx.Length - 1; i += 2) sum += 4 * fx[i];
        for (int i = 4; i < fx.Length - 1; i += 2) sum += 2 * fx[i];
        double secondHalf = (h / 3) * (fx[3] + sum + fx[fx.Length - 1]);
        //combine the two halves and return the result:
        return firstHalf + secondHalf;
    }
}