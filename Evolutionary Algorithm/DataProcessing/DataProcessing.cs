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

namespace Evolutionary_Algorithm.DataProcessing
{
    public class DataProcessing : IDataProcessing
    {
        private ILogger _logger;
        private string _filePath;
        private int _configLines;
        private string[] _dataLines;
        public Configuration Configuration { get; private set; }

        public DataProcessing(string filePath, ILogger logger, int configLines)
        {
            _logger = logger;
            _filePath = filePath;
            _configLines = configLines;
            _dataLines = File.ReadAllLines(_filePath);
            Configuration = new Configuration();

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

        public Node[,] LoadAndSeedData()
        {
            

            return null;
        }
    }
}
