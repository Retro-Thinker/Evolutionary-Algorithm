using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Model
{
    public class NodeItem
    {
        public int Index { get; private set; }
        public int Profit { get; private set; }
        public int Weight { get; private set; }
        public int AssignedNodeId { get; private set; }
    }
}
