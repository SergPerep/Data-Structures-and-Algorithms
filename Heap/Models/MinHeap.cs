namespace Heap.Models;

public class MinHeap
{
    public List<int> elements = new List<int>();

    public int Count => elements.Count;

    public void Insert(int element)
    {
        elements.Add(element);
        HeapifyUp();
    }

    private void HeapifyUp()
    {
        var currentIndex = elements.Count - 1;
        var currentElement = elements[currentIndex];

        // First round
        var (parentIndex, parent) = GetParent(currentIndex);
        while (parent > currentElement)
        {
            // Swap
            var _temp = parent;
            elements[parentIndex] = currentElement;
            elements[currentIndex] = _temp;
            currentIndex = parentIndex;
            (parentIndex, parent) = GetParent(currentIndex);
        }
    }

    private (int index, int value) GetParent(int i)
    {
        var parentIndex = (i - 1) / 2; // floored
        return (parentIndex, elements[parentIndex]);
    }

    public void PrintHeap()
    {
        foreach (var element in elements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}