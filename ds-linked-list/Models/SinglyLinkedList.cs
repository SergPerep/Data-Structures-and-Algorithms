namespace dsLinkedList.Models;

public class SinglyLinkedList
{
    public SinglyNode? Head { get; set; } = null;
    private int count = 0;

    public void Append(string value)
    {
        var node = new SinglyNode(value);
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            var lastNode = GetLastNode();
            lastNode.Next = node;
        }
        count++;
    }

    public int Count() => count;

    public void Prepend(string value)
    {
        var node = new SinglyNode(value);
        SinglyNode? temp = Head;
        Head = node;
        Head.Next = temp;
        count++;
    }

    private SinglyNode GetLastNode()
    {
        var currNode = Head;
        while (currNode?.Next != null)
        {
            currNode = currNode.Next;
        }
        return currNode!;
    }

    public SinglyNode? GetNodeAt(int index)
    {
        if (index < 0 || index >= count)
        {
            return null;
        }

        var currNode = Head;
        for (int i = 0; i < index; i++)
        {
            currNode = currNode?.Next;
        }
        return currNode;
    }

    public override string ToString()
    {
        var currNode = Head;
        string result = "";
        while (currNode != null)
        {
            result += currNode.Value + " -> ";
            currNode = currNode.Next;
        }
        return result + "null";
    }

    public void InsertAfter(SinglyNode node, string value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        var newNode = new SinglyNode(value);
        newNode.Next = node.Next;
        node.Next = newNode;
        count++;
    }
}

public class SinglyNode
{
    public string Value { get; set; }
    public SinglyNode? Next { get; set; } = null;

    public SinglyNode(string value)
    {
        Value = value;
    }
}