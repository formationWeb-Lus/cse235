public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // ❌ No duplicates allowed
        if (value == Data)
            return;

        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
        {
            if (Left == null)
                return false;
            return Left.Contains(value);
        }
        else
        {
            if (Right == null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
{
    int left = Left == null ? 0 : Left.GetHeight();
    int right = Right == null ? 0 : Right.GetHeight();

    return 1 + Math.Max(left, right);
}
}