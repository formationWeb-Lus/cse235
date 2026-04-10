public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // 🛑 condition d’arrêt
        if (first > last)
            return;

        // 📌 trouver le milieu
        int mid = first + (last - first) / 2;

        // 🌳 insérer la valeur du milieu
        bst.Insert(sortedNumbers[mid]);

        // 🔁 construire la partie gauche
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // 🔁 construire la partie droite
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}