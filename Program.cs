double Trapezo(double[] fx, double h)
{
    double sum = 0;
    for (int i = 1; i < fx.Length - 1; i++) sum += fx[i];
    return (h / 2) * (fx[0] + 2 * sum+ fx[fx.Length - 1]);
}
