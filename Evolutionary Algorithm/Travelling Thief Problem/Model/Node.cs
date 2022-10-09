using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Model
{
    public class Node
    {
        private double[,] _nodeGrid;
        private int _gridSize;

        public List<NodeItem> _items;

        public int Index { get; private set; }
        public double PosX { get; private set; }
        public double PosY { get; private set; }
        public Node(double[,] nodeGrid, int index, double posX, double posY)
        {
            _nodeGrid = nodeGrid;
            _gridSize = nodeGrid.Length;
            _items = new List<NodeItem>();
            
            Index = index;
            PosX = posX;
            PosY = posY;
        }

        public override string ToString()
        {
            return $"Id:{Index}, X:{PosX}, Y:{PosY}";
        }
    }
}
