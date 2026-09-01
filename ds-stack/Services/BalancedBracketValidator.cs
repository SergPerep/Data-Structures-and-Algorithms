namespace ds_stack.Services;

public class BalancedBracketValidator
{
    private readonly Dictionary<char, char> closingCharsByOpenChars = new Dictionary<char, char>()
    {
        { '[', ']'}, { '(', ')'}, { '{', '}'}
    };
    private readonly HashSet<char> openChars;
    private readonly HashSet<char> closeChars;

    public BalancedBracketValidator()
    {
        openChars = new HashSet<char>(closingCharsByOpenChars.Keys);
        closeChars = new HashSet<char>(closingCharsByOpenChars.Values);
    }

    public void Validate(string input)
    {
    var stack = new Stack<char>();

    for (int i = 0; i < input.Length; i++)
    {
        var ch = input[i];
        if (openChars.Contains(ch))
        {
            stack.Push(ch);
        }

        if (closeChars.Contains(ch))
        {
            var lastOpenBracket = stack.Peek();
            var matchingClosedBracket = closingCharsByOpenChars[lastOpenBracket];
            if (matchingClosedBracket == ch)
            {
                stack.Pop();
            }
            else
            {
                Console.WriteLine($"{input} Mismatched closing bracket '{ch}' at index {i}");
                return;
            }
        }
    }
    if (stack.Count > 0)
    {
        Console.WriteLine($"{input} Unmatched opening bracket '{stack.Peek()}' at the end of input");
        return;
    }
    Console.WriteLine($"{input} All brackets are matched correctly");
}
}