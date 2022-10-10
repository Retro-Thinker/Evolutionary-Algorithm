using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using Evolutionary_Algorithm.TTP_Problem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Initialization
{
    public class GreedyInitialization : ISpecimenInitializator
    {
        private Random random = new Random();

        public void Initialize(Specimen specimen)
        {
            var nodes = specimen.Configuration.Nodes;
            Node currentNode = nodes[random.Next(0, nodes.Count)];

            specimen.Nodes.Add(currentNode);



            while(specimen.Nodes.Count != nodes.Count)
            {
                var nextNode = GetNextNode(currentNode, nodes, specimen.Nodes, specimen.Configuration.NodeDistance);
                specimen.Nodes.Add(nextNode);

                DecideToTakeItems(specimen, nextNode._items);

                currentNode = nextNode;
            }

        }

        //TODO
        private void DecideToTakeItems(Specimen specimen, List<NodeItem> currentNodeItems)
        {
            throw new NotImplementedException();
        }

        private Node GetNextNode(Node currentNode, 
                                 List<Node> allNodes,
                                 List<Node> visitedNodes,
                                 Dictionary<(Node, Node), double> distances)
        {
            int bestNodeIndex = -1;
            double bestDistance = double.MaxValue;
            Node bestNode = null;

            var nodesToVisit = allNodes
                                             .Where(n => !visitedNodes.Contains(n))
                                             .ToList();

            for (int i = 0; i < nodesToVisit.Count(); i++)
            {
                var currentDistance = distances[(currentNode, nodesToVisit[i])];

                if (bestDistance > currentDistance)
                {
                    bestDistance = currentDistance;
                    bestNode = nodesToVisit[i];
                }
            }
            return bestNode;
        }
    }
}
