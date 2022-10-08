using Evolutionary_Algorithm.DataLoader;
using Evolutionary_Algorithm.DataProcessing.Logs;
using Evolutionary_Algorithm.Travelling_Thief_Problem;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.DataProcessing
{
    public class DataProcessing : IDataProcessing
    {
        private ILogger _logger;
        private string _filePath;
        public Configuration Configuration { get; private set; }

        public DataProcessing(string filePath, ILogger logger)
        {
            _logger = logger;
            _filePath = filePath;
            Configuration = new Configuration();

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {

        }

        public Node[,] LoadAndSeedData()
        {
            throw new NotImplementedException();
        }
    }
}
