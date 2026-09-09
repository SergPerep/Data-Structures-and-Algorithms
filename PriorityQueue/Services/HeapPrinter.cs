namespace PriorityQueue.Services;
public class HeapPrinter
{
    public static void PrintHeap(List<int> heap)
    {
        if (heap.Count == 0)
        {
            Console.WriteLine("(empty heap)");
            return;
        }

        int totalLevels = (int)Math.Floor(Math.Log2(heap.Count)) + 1;
        int index = 0;

        for (int level = 0; level < totalLevels; level++)
        {
            int nodesInLevel = (int)Math.Pow(2, level);
            int levelWidth = (int)Math.Pow(2, totalLevels - level) * 2; // spacing shrinks each level down

            // Print the values for this level, centered
            PrintLevelValues(heap, ref index, nodesInLevel, levelWidth);

            // Print the connecting branches (skip after last level)
            if (level < totalLevels - 1)
            {
                PrintBranches(nodesInLevel, levelWidth);
            }
        }
    }

    private static void PrintLevelValues(List<int> heap, ref int index, int nodesInLevel, int levelWidth)
    {
        int padding = levelWidth / 2 - 1;
        var line = new System.Text.StringBuilder();
        line.Append(new string(' ', Math.Max(padding, 0)));

        for (int i = 0; i < nodesInLevel && index < heap.Count; i++)
        {
            line.Append(heap[index]);
            index++;
            line.Append(new string(' ', Math.Max(levelWidth - 1, 1)));
        }

        Console.WriteLine(line.ToString());
    }

    private static void PrintBranches(int nodesInLevel, int levelWidth)
    {
        int padding = levelWidth / 2 - 2;
        var line = new System.Text.StringBuilder();
        line.Append(new string(' ', Math.Max(padding, 0)));

        for (int i = 0; i < nodesInLevel; i++)
        {
            line.Append("/ \\");
            line.Append(new string(' ', Math.Max(levelWidth - 3, 1)));
        }

        Console.WriteLine(line.ToString());
    }
}