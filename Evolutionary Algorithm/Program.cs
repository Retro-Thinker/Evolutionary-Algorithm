using Evolutionary_Algorithm.DataProcessing;
using Evolutionary_Algorithm.DataProcessing.Logs;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Crossover;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Initialization;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Mutation;
using Evolutionary_Algorithm.Travelling_Thief_Problem.Persistance.Selection;

DataProcessing dp = new DataProcessing("data/trivial_0.ttp", new Logger());
dp.LoadAndSeedData();

/*WorkflowManager workflowManager =
    new WorkflowManager(50,
                        dp.Configuration,
                        new InverseMutation(),
                        new OrderedCrossover(),
                        new TournamentSelection(),
                        new RandomInitialization(0.6),
                        dp._logger);*/


WorkflowManager workflowManager =
    new WorkflowManager(50,
                        dp.Configuration,
                        new InverseMutation(),
                        new OrderedCrossover(),
                        new TournamentSelection(),
                        new GreedyInitialization(),
                        dp._logger);

workflowManager.InitializeSpecimens();