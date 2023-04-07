using MSScriptControl;
using System.Text.RegularExpressions;

namespace NumericalAnalysis
{
    static class Util
    {
        static readonly ScriptControl sc = new() { Language = "javascript" };
        public static string scrpt="";
        public static void InitializeFunction()
        {
            Console.WriteLine("Enter your equation:\n");
        init:
            try
            {
                scrpt = Console.ReadLine();
                if (scrpt.Contains('^'))
                {
                    scrpt = scrpt.Replace("^", "**");
                }
            }
            catch
            {
                Console.WriteLine("please enter a valid equation:\n");
                goto init;
            }
        }
        public static string Derivative(string fx)
        {
            Regex derivePow = new Regex(@"(?'multiplier'\d+)?\*?x\*?\*?(?'exponent'\d+)?");
            string fxdx = fx;
            string[] sections = fx.Split('+');
            for (int i = 0; i < sections.Length; i++)
            {
                string subSection = "";
                if (sections[i].Contains('x'))
                {
                    var mtch = derivePow.Match(sections[i]);
                    int multiplier = 1, exponent = 1;
                    if (mtch.Groups["multiplier"].Success)
                        multiplier = int.Parse(mtch.Groups["multiplier"].Value);
                    if (mtch.Groups["exponent"].Success)
                        exponent = int.Parse(mtch.Groups["exponent"].Value);
                    subSection += multiplier * exponent;
                    if (exponent > 1)
                    {
                        subSection += "*x";
                        if (exponent > 2) subSection += "**" + (exponent - 1);
                    }
                    sections[i] = subSection;
                }
                else sections[i] = "0";
            }
            return string.Join('+',sections);
        }
        public static double func(double x)
        {
            if (scrpt == "") InitializeFunction();
            string nscript = scrpt.Replace("x", x.ToString());
            return sc.Eval(nscript);
        }
        public static double func(string scrpt,double x)
        {
            string nscript = scrpt.Replace("x", x.ToString());
            return sc.Eval(nscript);
        }
    }
}
