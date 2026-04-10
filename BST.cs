using System;

class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        this.Value = value;
    }
}

class BST
{
    private Node root;

    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value);

        return node;
    }
    public bool Contains(int value)
{
    return ContainsRec(root, value);
}

private bool ContainsRec(Node node, int value)
{
    if (node == null)
        return false;

    if (value == node.Value)
        return true;

    if (value < node.Value)
        return ContainsRec(node.Left, value);
    else
        return ContainsRec(node.Right, value);
}

public void InOrder(Node node)
{
    if (node == null) return;

    InOrder(node.Left);
    Console.Write(node.Value + " ");
    InOrder(node.Right);
}

public void ReverseOrder(Node node)
{
    if (node == null) return;

    ReverseOrder(node.Right);
    Console.Write(node.Value + " ");
    ReverseOrder(node.Left);
}

public int Height(Node node)
{
    if (node == null)
        return -1;

    int leftHeight = Height(node.Left);
    int rightHeight = Height(node.Right);

    return Math.Max(leftHeight, rightHeight) + 1;
}

}

class Program
{
    static void Main()
    {
        BST tree = new BST();

        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);

        Console.WriteLine("Ça marche !");
    }

}

