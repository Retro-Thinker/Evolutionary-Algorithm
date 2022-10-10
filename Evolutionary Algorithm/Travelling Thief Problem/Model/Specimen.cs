using Evolutionary_Algorithm.TTP_Problem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Model
{
    public class Specimen : ISpecimen
    {
        public Configuration Configuration { get; set; }

        public List<Node> Nodes { get; set; }
        public Dictionary<NodeItem, bool> Inventory { get; set; }
        public int InventoryWeight { get; set; }
        public int Profit { get; set; } = 0;
        public double Score { get; set; } = 0d;


        public Specimen(Configuration configuration)
        {
            Configuration = configuration;
            Nodes = new List<Node>();
            Inventory = new Dictionary<NodeItem, bool>();
            InventoryWeight = 0;
        }

        public bool AddToInventory(NodeItem item)
        {
            if (CheckIfEnoughCapacity(item))
            {
                Inventory[item] = true;
                InventoryWeight += item.Weight;
                Profit += item.Profit;

                return true;
            }
            else return false;
        }

        private bool CheckIfEnoughCapacity(NodeItem item)
        {
            if (InventoryWeight + item.Weight <= Configuration.CapacityOfKnapsack)
            {
                return true;
            }
            else return false;
        }

        public void Eval()
        {
            Score = (double)KPScoreEvaluation() - (double)TSPScoreEvaluation();
        }

        private double TSPScoreEvaluation()
        {
            var distances = Configuration.NodeDistance;

            double maxSpeed = Configuration.MaximumSpeed;
            double minSpeed = Configuration.MinimumSpeed;

            int inventoryWeight = InventoryWeight;
            int maxWeight = Configuration.CapacityOfKnapsack;

            double velocity = maxSpeed - ((double)inventoryWeight * (double)((double)(maxSpeed - minSpeed) / (double)maxWeight));
            double journeyTime = 0d;

            for (int i = 0; i < Nodes.Count(); i++)
            {
                var fst = Nodes[i];
                var snd = i + 1 != Nodes.Count() ? Nodes[i + 1] : Nodes[0];


                journeyTime += (double)((double)Configuration.NodeDistance[(fst, snd)] / (double)velocity);
            }
            return journeyTime;
        }

        private double KPScoreEvaluation()
        {
            return Profit;
        }

        public void Fix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Inventory weight: {InventoryWeight}, Inventory Limit : {Configuration.CapacityOfKnapsack}";
        }
    }
}
