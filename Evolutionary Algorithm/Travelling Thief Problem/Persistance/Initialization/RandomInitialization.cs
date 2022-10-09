using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using Evolutionary_Algorithm.TTP_Problem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Initialization
{
    public class RandomInitialization : ISpecimenInitializator
    {
        private Random random = new Random();
        private double _choosingOdds;

        public RandomInitialization(double chosingOdds)
        {
            _choosingOdds = chosingOdds;
        }

        public void Initialize(Specimen specimen)
        {
            var nodes = specimen.Configuration.Nodes;


            for (int i = 0; i < nodes.Count; i++)
            {
                Node chosenNode = NodeToChoose(nodes, specimen);
                DecideToTakeItems(chosenNode, specimen);
            }
            specimen.Eval();
        }

        private Node NodeToChoose(List<Node> nodes, Specimen specimen)
        {
            while (true)
            {
                var nodeToVisit =  nodes[random.Next(0, nodes.Count)];
                if (!specimen.Nodes.Contains(nodeToVisit))
                {
                    specimen.Nodes.Add(nodeToVisit);
                    return nodeToVisit;
                }
            }

        }

        private bool DecideToTakeItems(Node currentNode, Specimen specimen)
        {
            if (currentNode._items.Count() == 0) return false;

            else if (random.NextDouble() <= _choosingOdds)
            {
               int itemsCount = random.Next(1, currentNode._items.Count());

               for (int i = 0; i < itemsCount; i++)
               {
                   specimen.AddToInventory(currentNode._items[random.Next(0, currentNode._items.Count())]);
               }
               return true;
            }
            return false;
        }
    }
}
