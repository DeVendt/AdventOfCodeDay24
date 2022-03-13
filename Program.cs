using AdventOfCodeDay24;
// Lets start with day 24

Console.WriteLine("Day 24 of AdventOfCode has arrrived!!!");

// Lets build helper class
var monad = new MonadService(new MonadCalculator());
var lines = monad.GetDataFromFile(AppDomain.CurrentDomain.BaseDirectory + "input24.txt");

List<MonadAction> listOfMonadActions = monad.BuildMonadTasks(lines);
monad.LoopMonadActions(listOfMonadActions);

foreach (var monadVal in monad.MonadValues)
{
    Console.WriteLine($"Key: {monadVal.Key}, Value: {monadVal.Value}");
}