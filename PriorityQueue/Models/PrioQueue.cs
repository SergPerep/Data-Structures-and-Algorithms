using PriorityQueue.Services;

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
        if (items.Count == 0)
            return;
        var currentIndex = 0;
        var (currEl, currPriority) = items[currentIndex];
        while (true)
        {
            // HeapPrinter.PrintHeap(items.Select(item => item.Item2).ToList());

            // Pick smalest child
            var leftChildIndex = (currentIndex * 2) + 1;
            var rightChildIndex = (currentIndex * 2) + 2;

            // If no children, break
            if (leftChildIndex >= items.Count && rightChildIndex >= items.Count)
                break;

            int targetChildIndex;

            if (rightChildIndex >= items.Count) // If right child does not exist, pick left child
                targetChildIndex = leftChildIndex;
            else if (items[leftChildIndex].Item2 < items[rightChildIndex].Item2) // If right child exists, pick the one with smaller priority
                targetChildIndex = leftChildIndex;
            else
                targetChildIndex = rightChildIndex;

            var targetChild = items[targetChildIndex];
            var (targetChildEl, targetChildPriority) = targetChild;

            if (currPriority > targetChildPriority)
            {
                // Swap with target child
                items[currentIndex] = (targetChildEl, targetChildPriority);
                items[targetChildIndex] = (currEl, currPriority);
                currentIndex = targetChildIndex;
                continue;
            }

            // If no swap
            break;
        }
    }

    private (int index, (string parentElement, int parentPriority)) GetParent(int i)
    {
        var parentIndex = (i - 1) / 2; // floored
        var parent = items[parentIndex];
        return (parentIndex, parent);
    }
}