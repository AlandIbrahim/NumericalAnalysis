using MSScriptControl;

namespace NumericalAnalysis
{
    static class Util
    {
        static readonly ScriptControl sc = new() { Language = "javascript" };
        static string scrpt="";
        public static void InitializeFunction()
        {
            Console.WriteLine("Enter your equation:\n");
        init:
            try
            {
                scrpt = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("please enter a valid equation:\n");
                goto init;
            }
        }
        public static double func(double x)
        {
            if (scrpt == "") InitializeFunction();
            string nscript = scrpt.Replace("x", x.ToString());
            return sc.Eval(nscript);
        }
    }
}
