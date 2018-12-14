using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class EquationSolutionInformation
    {

        public bool Solveable { get; set; }

        public string SimplifiedEquation { get; set; }

        public List<EquationSolutionStep> Steps { get; set; }
    }
}
