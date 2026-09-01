namespace StackInfixPostFix.Services;

public class PostFixCalculator
{
    private readonly string[] operators = new[] { "+", "-", "*", "/" };
    public int Calculate(string expression)
    {
        var symbols = expression.Split(' ');
        var stack = new Stack<int>();

        for (int i =0; i < symbols.Length; i++)
        {
            var current = symbols[i];
            if (IsOperator(current))
            {
                // If is operator, calculate the two top members of the stack
                var head = stack.Pop();
                var tail = stack.Pop();
                switch (current)
                {
                    case "+":
                        stack.Push(tail + head);
                        break;
                    case "-":
                        stack.Push(tail - head);
                        break;
                    case "*":
                        stack.Push(tail * head);
                        break;
                    case "/":
                        stack.Push(tail / head);
                        break;
                }
            }
            else
            {
                // If number, store it in the stack
                stack.Push(int.Parse(current));
            }
        }
        return stack.Pop();
    }

    private bool IsOperator(string value)
    {
        return operators.Contains(value);
    }
}