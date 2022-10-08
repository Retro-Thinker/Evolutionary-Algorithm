using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Model
{
    public class Node
    {
        private Node[,] _nodeGrid;
        private int _gridSize;

        private List<NodeItem> _items;
        public Dictionary<int,int> ItemStatus { get; private set; }

        public int Index { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public bool Visited { get; set; } = false;
        public bool StartingNode { get; set; } = false;
        public Node(Node[,] nodeGrid, int index, int posX, int posY)
        {
            _nodeGrid = nodeGrid;
            _gridSize = nodeGrid.Length;
            _items = new List<NodeItem>();
            
            ItemStatus = new Dictionary<int,int>();
            Index = index;
            PosX = posX;
            PosY = posY;
        }

        public int NodeProfit()
        {
            int profit = 0;
            foreach (var elem in ItemStatus.Keys)
            {
                profit += ItemStatus[elem] == 1 ? _items[elem].Profit : 0;
            }

            return profit;
        }
    }
}
