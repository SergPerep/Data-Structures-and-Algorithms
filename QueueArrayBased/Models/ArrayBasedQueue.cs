namespace QueueArrayBased.Models;

public class ArrayBasedQueue
{
    private string[] elements = new string[4];
    private int front = 0; // Top element of the queue
    private int rear = 0; // Next vacant place
    private int count = 0;

    public void Enqueue(string element)
    {
        Console.WriteLine($"Enqueuing element: {element}");
        // If array is full -> double the size
        if (count + 1 == elements.Length)
            EnlargeArray();
        elements[rear] = element;
        rear = (rear + 1) % elements.Length;
        count++;
        PrintQueueState();
    }

    public string Dequeue()
    {
        Console.WriteLine($"Dequeuing element from front: {front}");
        if (count <= 0)
        {
            throw new Exception("Queue is empty");
        }
        var el = elements[front];
        elements[front] = "";
        front = (front + 1) % elements.Length;
        count--;
        PrintQueueState();
        return el;
    }

    private void EnlargeArray()
    {
        var newArray = new string[elements.Length * 2];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = elements[(front + i) % elements.Length];
        }
        elements = newArray;
        front = 0;
        rear = count;
    }

    private void PrintQueueState()
    {
        var arrayString = $"[{string.Join(", ", elements)}]";
        Console.WriteLine(arrayString);
        var pointers = Enumerable.Repeat(" ", elements.Length).ToArray();
        pointers[front] = "f";
        pointers[rear] = "r";
        var pointersString = $" {string.Join("  ", pointers)} ";
        Console.WriteLine(pointersString);
    }
}