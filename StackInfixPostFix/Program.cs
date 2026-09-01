var tests = new Dictionary<string, int> 
{
    { "3 4 +", 7 },
    { "3 4 2 * +", 11 },
    { "5 1 2 + 4 * + 3 -", 14 }
};
var calculator = new StackInfixPostFix.Services.PostFixCalculator();
foreach (var test in tests)
{
    var result = calculator.Calculate(test.Key);
    Console.WriteLine($"Expression: {test.Key}, Expected: {test.Value}, Result: {result}");
}
