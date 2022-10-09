using Evolutionary_Algorithm.DataProcessing;
using Evolutionary_Algorithm.DataProcessing.Logs;

DataProcessing dp = new DataProcessing("data/easy_1.ttp", new Logger(), 9);
dp.LoadAndSeedData();
