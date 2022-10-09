using Evolutionary_Algorithm.DataProcessing.Logs;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Model;
using Evolutionary_Algorithm.TTP_Problem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance
{
    public class WorkflowManager : IWorkflowManager<Specimen>
    {
        public List<Specimen> CurrentSpecimens { get; set; }
        public IMutator<Specimen> Mutator { get; set;}
        public ICrossover<Specimen> Crossover { get; set; }
        public ISelector<Specimen> Selector { get; set; }
        public ISpecimenInitializator Initializator { get; }
        public ILogger Logger { get; set; }
        public int PopulationSize { get; set; }

        public Configuration Configuration { get; set; }


        public WorkflowManager(int populationSize,
                               Configuration configuration,
                               IMutator<Specimen> mutator, 
                               ICrossover<Specimen> crossover, 
                               ISelector<Specimen> selector,
                               ISpecimenInitializator specimenInitializator,
                               ILogger logger)
        {
            CurrentSpecimens = new List<Specimen>();
            Mutator = mutator;
            Crossover = crossover;
            Selector = selector;
            Logger = logger;
            PopulationSize = populationSize;
            Configuration = configuration;
            Initializator = specimenInitializator;
        }

        public void InitializeSpecimens()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                var specimen = new Specimen(Configuration);
                Initializator.Initialize(specimen);

                CurrentSpecimens.Add(specimen);
            }
        }

        public void RunNextEpoch()
        {
            throw new NotImplementedException();
        }
    }
}
