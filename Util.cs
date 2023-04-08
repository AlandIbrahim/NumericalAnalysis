using MSScriptControl;
using System.Text.RegularExpressions;

namespace NumericalAnalysis
{
    static class Util
    {
        static readonly ScriptControl sc = new ScriptControl() { Language = "javascript" };
        public static string scrpt="";
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
        public static string Derivative(string fx)
        {
            Regex derivePow = new Regex(@"(?'multiplier'\d+\.?\d*)?\*?x\^?(?'exponent'\d+)?");
            string fxdx = fx;
            string[] sections = fx.Split('+','-');
            for (int i = 0; i < sections.Length; i++)
            {
                string subSection = "";
                if (sections[i].Contains('x'))
                {
                    var mtch = derivePow.Match(sections[i]);
                    double multiplier = 1, exponent = 1;
                    if (mtch.Groups["multiplier"].Success)
                        multiplier = double.Parse(mtch.Groups["multiplier"].Value);
                    if (mtch.Groups["exponent"].Success)
                        exponent = double.Parse(mtch.Groups["exponent"].Value);
                    subSection += multiplier * exponent;
                    if (exponent > 1)
                    {
                        subSection += "x";
                        if (exponent > 2) subSection += "^" + (exponent - 1);
                    }
                    sections[i] = subSection;
                }
                else sections[i] = "";
            }
            string[] result=sections.Where(sec=>sec.Length>0).ToArray();
            return string.Join('+',result);
        }
        static string ConvertFunc(string script)
        {
            string[] sections = script.Split("+");
            //multiplier conversion
            Regex multiplier = new Regex(@"(?'multiplier'\d+\.?\d*)x");
            for (int i = 0; i < sections.Length; i++)
            {
                var mtch = multiplier.Match(sections[i]);
                if (mtch.Success)
                {
                    sections[i] = sections[i].Replace(mtch.Groups["multiplier"].Value, $"{mtch.Groups["multiplier"].Value}*");
                }
            }
            //exponent conversion
            Regex pow = new Regex(@"\^(?'pow'\d+)");
            for (int i = 0; i < sections.Length; i++)
            {
                var mtch= pow.Match(sections[i]);
                if (mtch.Success)
                {
                    sections[i] = sections[i].Replace("x^" + mtch.Groups["pow"], $"Math.pow(x,{mtch.Groups["pow"].Value})");
                }
            }
            return string.Join("+",sections);
        }
        public static double Func(double x)
        {
            if (scrpt == "") InitializeFunction();
            string nscript = ConvertFunc(scrpt);
            nscript = nscript.Replace("x", $"({x})");
            return sc.Eval(nscript);
        }
        public static double Func(string scrpt,double x)
        {
            string nscript= ConvertFunc(scrpt);
            nscript = nscript.Replace("x", $"({x})");
            return sc.Eval(nscript);
        }
    }
}
