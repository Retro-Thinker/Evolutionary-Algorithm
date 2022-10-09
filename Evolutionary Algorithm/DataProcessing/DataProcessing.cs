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
        private ILogger _logger;
        private string _filePath;
        private int _configLines;
        private string[] _dataLines;
        private double[,] nodeDataGrid;
        public Configuration Configuration { get; private set; }
        public Dictionary<(Node, Node), double> nodeDistanceStats;

        public DataProcessing(string filePath, ILogger logger, int configLines)
        {
            _logger = logger;
            _filePath = filePath;
            _configLines = configLines;
            _dataLines = File.ReadAllLines(_filePath);
            Configuration = new Configuration();
            nodeDistanceStats = new Dictionary<(Node, Node), double>();

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
            double[,] nodes = new double[Configuration.Dimensions, Configuration.Dimensions];

            for (int i = 0; i < nodes.GetLength(0); i++)
            {

                int nodeTableIndex = _configLines + i + 1;
                var readedNodeData = _dataLines[nodeTableIndex].Split("\t");

                var procededNode = CreateNode(nodes, readedNodeData);


                for (int j = 0; j < nodes.GetLength(0); j++)
                {
                    nodeTableIndex = _configLines + j + 1;
                    if (i == j) nodes[i, j] = 0d;
                    else
                    {
                        readedNodeData = _dataLines[nodeTableIndex].Split("\t");
                        var nextNode = CreateNode(nodes, readedNodeData);

                        double distance = Math.Sqrt(Math.Pow(procededNode.PosX - nextNode.PosX, 2) + Math.Pow(procededNode.PosY - nextNode.PosY, 2));

                        nodeDistanceStats.Add((procededNode, nextNode), distance);
                        nodes[i, j] = distance;
                    }
                }
            }
        }

        public double[,] LoadAndSeedData()
        {
            if (_dataLines == null)
            {
                _dataLines = File.ReadAllLines(_filePath);                
                LoadConfiguration();
            }

            SeedNodeData();


            return nodes;
        }
    }
}
