using Evolutionary_Algorithm.DataLoader;
using Evolutionary_Algorithm.DataProcessing.Logs;
using Evolutionary_Algorithm.Travelling_Thief_Problem;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Evolutionary_Algorithm.DataProcessing
{
    public class DataProcessing : IDataProcessing
    {
        private string _filePath;
        private string[] _dataLines;
        
        public ILogger _logger;
        public double[,] _nodeDataGrid;
        public List<Node> _nodes;
        
        private int _configLines;
        private int _nodeConfigStartIndex;
        private int _itemsConfigStartIndex;
        
        public Configuration Configuration { get; private set; }
        public Dictionary<(Node, Node), double> _nodeDistanceStats;

        public DataProcessing(string filePath, ILogger logger)
        {
            _logger = logger;
            _filePath = filePath;
            _dataLines = File.ReadAllLines(_filePath);
            Configuration = new Configuration();
            _nodeDistanceStats = new Dictionary<(Node, Node), double>();

            _nodeConfigStartIndex = Array.FindIndex(_dataLines, str => str.StartsWith("NODE_COORD_SECTION")) + 1;
            _itemsConfigStartIndex = Array.FindIndex(_dataLines, str => str.StartsWith("ITEMS SECTION")) + 1;
            _configLines = _nodeConfigStartIndex - 1;

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var prop = Configuration.GetType().GetProperties();
            for (int i = 0; i < _configLines; i++)
            {
                var value = Regex.Replace(_dataLines[i].Split(":")[1], @"[ \t\s]", "");
                value = value.Replace(".", ",");
                prop[i].SetValue(Configuration, Convert.ChangeType(value, prop[i].PropertyType), null);
            }
        }

        private Node CreateNode(double[,] nodes, string[] nodeData)
        {
            return new Node(nodes,
                            int.Parse(nodeData[0]),
                            double.Parse(nodeData[1].Replace(".", ",")),
                            double.Parse(nodeData[2].Replace(".", ","))
                            );
        }

        private void SeedNodeData()
        {
            _nodeDataGrid = new double[Configuration.Dimensions, Configuration.Dimensions];

            for (int i = 0; i < _nodeDataGrid.GetLength(0); i++)
            {

                int nodeTableIndex = _nodeConfigStartIndex + i;
                var readedNodeData = _dataLines[nodeTableIndex].Split("\t");

                var procededNode = CreateNode(_nodeDataGrid, readedNodeData);


                for (int j = 0; j < _nodeDataGrid.GetLength(0); j++)
                {
                    nodeTableIndex = _nodeConfigStartIndex + j;
                    if (i == j) _nodeDataGrid[i, j] = 0d;
                    else
                    {
                        readedNodeData = _dataLines[nodeTableIndex].Split("\t");
                        var nextNode = CreateNode(_nodeDataGrid, readedNodeData);

                        double distance = Math.Sqrt(Math.Pow(procededNode.PosX - nextNode.PosX, 2) + Math.Pow(procededNode.PosY - nextNode.PosY, 2));

                        _nodeDistanceStats.Add((procededNode, nextNode), distance);
                        _nodeDataGrid[i, j] = distance;
                    }
                }
            }
        }

        private void SeedItemsData()
        {
            var nodeList = _nodeDistanceStats.Keys
                .Select(k => k.Item1)
                .DistinctBy(k => k.Index)
                .ToList();

            _nodes = nodeList;

            for (int i = _itemsConfigStartIndex; i < _itemsConfigStartIndex + Configuration.NumberOfItems; i++)
            {
                var readedItemData = _dataLines[i].Split("\t");
                var nodeItem = new NodeItem();

                nodeItem.Index = int.Parse(readedItemData[0]);
                nodeItem.Profit = int.Parse(readedItemData[1]);
                nodeItem.Weight = int.Parse(readedItemData[2]);
                nodeItem.AssignedNodeId = int.Parse(readedItemData[3]);

                nodeList
                    .Find(n => n.Index == nodeItem.AssignedNodeId)
                    ._items.Add(nodeItem);
            }
        }

        public void LoadAndSeedData()
        {
            if (_dataLines == null)
            {
                _dataLines = File.ReadAllLines(_filePath);                
                LoadConfiguration();
            }
            SeedNodeData();
            SeedItemsData();

            Configuration.Nodes = _nodes;
            Configuration.NodeDistance = _nodeDistanceStats;
        }
    }
}
