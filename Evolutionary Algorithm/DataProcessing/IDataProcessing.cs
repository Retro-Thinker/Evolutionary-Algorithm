using Evolutionary_Algorithm.Travelling_Thief_Problem;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.DataLoader
{
    public interface IDataProcessing
    {
        void LoadAndSeedData();
    }
}
