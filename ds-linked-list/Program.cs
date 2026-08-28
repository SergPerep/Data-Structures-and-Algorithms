using dsLinkedList.Models;

var singlyLinkedList = new SinglyLinkedList();

singlyLinkedList.Append("Apple");
singlyLinkedList.Append("Banana");
singlyLinkedList.Append("Cherry");
singlyLinkedList.Prepend("Orange");

var node = singlyLinkedList.GetNodeAt(2);
singlyLinkedList.InsertAfter(node, "Grapes");

Console.WriteLine(singlyLinkedList.ToString());
Console.WriteLine("Length: " + singlyLinkedList.Count());