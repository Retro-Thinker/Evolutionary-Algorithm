using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem
{
    public class Configuration
    {
        public string ProblemName { get; set; }
        public string DataType { get; set; }
        public int Dimensions { get; set; }
        public int NumberOfItems { get; set; }
        public int CapacityOfKnapsack { get; set; }
        public double MinimumSpeed { get; set; }
        public double MaximumSpeed { get; set; }
        public double RentingRatio { get; set; }
        public string EdgeWeightType { get; set; }
        public List<Node> Nodes { get; set; }
        public Dictionary<(Node, Node), double> NodeDistance { get; set; }
    }
}
