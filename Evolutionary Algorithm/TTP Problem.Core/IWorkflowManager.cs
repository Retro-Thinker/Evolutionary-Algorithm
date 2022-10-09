using Evolutionary_Algorithm.DataProcessing.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.TTP_Problem.Core
{
    public interface IWorkflowManager<T> where T : ISpecimen
    {
        List<T> CurrentSpecimens { get; set; }
        IMutator<T> Mutator { get; set; }
        ICrossover<T> Crossover { get; set;  }
        ISelector<T> Selector { get; set; }
        public ILogger Logger { get; set; }
        public int PopulationSize { get; set; }
        void InitializeSpecimens();
        void RunNextEpoch();
    }
}
