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

    private void HeapifyDown()
    {
        var currentIndex = 0;
        var currentElement = elements[currentIndex];

        while (true)
        {
            var leftChildIndex = 2 * currentIndex + 1;
            var rightChildIndex = 2 * currentIndex + 2;
            var smallestIndex = currentIndex;

            if (leftChildIndex < elements.Count && elements[leftChildIndex] < elements[smallestIndex])
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < elements.Count && elements[rightChildIndex] < elements[smallestIndex])
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex == currentIndex) break;

            // Swap
            var temp = elements[smallestIndex];
            elements[smallestIndex] = currentElement;
            elements[currentIndex] = temp;
            currentIndex = smallestIndex;
        }
    }

    public void Delete()
    {
        if (elements.Count == 0) return;

        // Move the last element to the root
        elements[0] = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        HeapifyDown();
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