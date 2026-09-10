namespace QueueLinkedListBased.Models;

public class LinkedListBasedQueue
{
    private LinkedList<string> elements = new LinkedList<string>();

    public void Enqueue(string item)
    {
        elements.AddLast(item);
    }

    public string Dequeue()
    {
        if (elements.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        string value = elements.First.Value;
        elements.RemoveFirst();
        return value;
    }
}