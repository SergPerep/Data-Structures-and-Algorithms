using PriorityQueue.Models;
using PriorityQueue.Services;
var prioQueue = new PrioQueue();

foreach (var num in new int[] { 8, 9, 1, 5, 10, 2, 4, 3, 10, 1 })
{
    prioQueue.Enqueue(num.ToString(), num);
}

var count = prioQueue.Count;

for (var i = 0; i < count; i++)
{
    HeapPrinter.PrintHeap(prioQueue.items.Select(item => item.Item2).ToList());
    var (element, priority) = prioQueue.Dequeue();
    Console.WriteLine($"Element: {element}, Priority: {priority}");
}