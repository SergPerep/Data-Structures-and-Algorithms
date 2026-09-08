namespace PriorityQueue.Models;

public class PrioQueue
{
    public List<(string, int)> items = new List<(string, int)>();

    public int Count => items.Count;

    public void Enqueue(string element, int priority)
    {
        items.Add((element, priority));
        HeapifyUp();
    }

    public (string, int) Dequeue()
    {
        var traget = items[0];
        items[0] = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        HeapifyDown();
        return traget;
    }

    private void HeapifyUp()
    {
        var currentIndex = items.Count - 1;
        var (currElement, currPriority) = items[currentIndex];

        // First round
        var (parentIndex, (parentElement, parentPriority)) = GetParent(currentIndex);
        while (parentPriority > currPriority)
        {
            items[parentIndex] = (currElement, currPriority);
            items[currentIndex] = (parentElement, parentPriority);
            currentIndex = parentIndex;
            (parentIndex, (parentElement, parentPriority)) = GetParent(currentIndex);
        }
    }

    private void HeapifyDown()
    {
        var currentIndex = 0;
        var compare = true;
        var (currEl, currPriority) = items[currentIndex];
        while (compare)
        {

            // Compare
            var leftChildIndex = (currentIndex * 2) + 1;
            var rightChildIndex = (currentIndex * 2) + 2;
            var leftChild = items[leftChildIndex];
            var (_, leftChildPriority) = leftChild;
            var rightChild = items[rightChildIndex];
            var (_, rightChildPriority) = rightChild;


            if (currPriority > leftChildPriority)
            {
                // Swap with left child
                items[currentIndex] = leftChild;
                items[leftChildIndex] = (currEl, currPriority);
                currentIndex = leftChildIndex;
                (currEl, currPriority) = leftChild;
                continue;

            }

            if (currPriority > rightChildPriority)
            {
                // Swap with right child
                items[currentIndex] = rightChild;
                items[rightChildIndex] = (currEl, currPriority);
                currentIndex = rightChildIndex;
                (currEl, currPriority) = rightChild;
                continue;
            }

            // If no swap
            compare = false;
        }
    }

    private (int index, (string parentElement, int parentPriority)) GetParent(int i)
    {
        var parentIndex = (i - 1) / 2; // floored
        var parent = items[parentIndex];
        return (parentIndex, parent);
    }

    public void PrintHeap()
    {
        foreach (var element in items)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}