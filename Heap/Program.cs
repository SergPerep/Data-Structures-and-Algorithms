using Heap.Models;
using Heap.Services;
var heap = new MinHeap();

foreach (var num in new int[] {8, 9, 1, 5 ,10, 2, 4, 3, 10, 1 })
{
    heap.Insert(num);
}

HeapPrinter.PrintHeap(heap.elements);
