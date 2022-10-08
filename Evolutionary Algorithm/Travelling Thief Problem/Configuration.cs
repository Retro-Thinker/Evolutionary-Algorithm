using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem
{
    public class Configuration
    {
        public string ProblemName { get; }
        public string DataType { get; }
        public int NumberOfDimmensions { get; }
        public int CapacityOfKnapsack { get; }
        public int KnapsackCapcaity { get; }
        public double MinimumSpeed { get; }
        public double MaximumSpeed { get; }
        public double RentingRatio { get; }
        public string EdgeWeightType { get; }
    }
}
