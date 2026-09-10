using QueueLinkedListBased.Models;

var elements = new string[] { "item1", "item2", "item3", "item4", "item5" };
var queue = new LinkedListBasedQueue();

// Enqueue all
foreach (var element in elements)
{
    queue.Enqueue(element);
}

// Dequeue all
foreach (var _ in elements)
{
    var dequeued = queue.Dequeue();
    Console.WriteLine(dequeued);
}

