using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Arithmatic
    {
        
        public string Solve(string input)
        {
            //Loop through to find parenthasis

            string pattern = @"\([\d\+\-\*\^\\]+\)";

            RegexOptions options = RegexOptions.None;

            while(Regex.IsMatch(input, pattern, options))
            {
                input = Regex.Replace(input, pattern, (m) => {

                    return CalculateInPars(m.Value);
                });
            }

            return input;
        }

        string CalculateInPars(string input)
        {
            string pattern = @"[\d\+\-\*\^\\]+";
            RegexOptions options = RegexOptions.None;

            string inside = Regex.Match(input, pattern, options).Value;

            string result = CalculateInside(inside);

            return result ;
        }



        string CalculateInside(string inside)
        {

            string pattern = @"(?<first>\d+)(?<operation>\^)(?<seccond>\d+)";

            while (Regex.IsMatch(inside, pattern))
            {
                inside = Regex.Replace(inside, pattern, (m) => {

                    string first = m.Groups["first"].Value;
                    string seccond = m.Groups["seccond"].Value;
                    string operation = m.Groups["operation"].Value;

                    int firstInt = int.Parse(first);
                    int seccondInt = int.Parse(seccond);
                    int resultInt = 0;

                    switch (operation)
                    {
                        case "^":
                            resultInt = (int)Math.Pow(firstInt, seccondInt);
                            break;
                    }



                    string result = resultInt.ToString();

                    return result;
                });
            }

            pattern = @"(?<first>\d+)(?<operation>[\*\\])(?<seccond>\d+)";

            while (Regex.IsMatch(inside, pattern))
            {
                inside = Regex.Replace(inside, pattern, (m) => {

                    string first = m.Groups["first"].Value;
                    string seccond = m.Groups["seccond"].Value;
                    string operation = m.Groups["operation"].Value;

                    int firstInt = int.Parse(first);
                    int seccondInt = int.Parse(seccond);
                    int resultInt = 0;

                    switch (operation)
                    {
                        case "*":
                            resultInt = firstInt * seccondInt;
                            break;
                        case "/":
                            resultInt = firstInt / seccondInt;
                            break;
                    }

                    

                    string result = resultInt.ToString();
                   
                    return result;
                });
            }

            pattern = @"(?<first>\d+)(?<operation>[\+\-])(?<seccond>\d+)";

            while (Regex.IsMatch(inside, pattern))
            {
                inside = Regex.Replace(inside, pattern, (m) => {

                    string first = m.Groups["first"].Value;
                    string seccond = m.Groups["seccond"].Value;
                    string operation = m.Groups["operation"].Value;

                    int firstInt = int.Parse(first);
                    int seccondInt = int.Parse(seccond);
                    int resultInt = 0;

                    switch (operation)
                    {
                        case "+":
                            resultInt = firstInt + seccondInt;
                            break;
                        case "-":
                            resultInt = firstInt - seccondInt;
                            break;
                    }



                    string result = resultInt.ToString();

                    return result;
                });
            }

            return inside;
        }

        void Operate()
        {

        }
    }
}
