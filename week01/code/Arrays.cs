public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// Example: MultiplesOf(7, 5) -> {7, 14, 21, 28, 35}
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of doubles with size equal to 'length'
        double[] result = new double[length];

        // Step 2: Use a loop to fill the array
        // Each position will contain a multiple of 'number'
        // The first element should be number * 1
        // The second element number * 2 and so on
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 3: Return the completed array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// Example:
    /// {1,2,3,4,5,6,7,8,9} with amount = 3
    /// Result -> {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the total number of elements in the list
        int count = data.Count;

        // Step 2: Get the last 'amount' elements (these will move to the front)
        List<int> endPart = data.GetRange(count - amount, amount);

        // Step 3: Get the remaining elements at the beginning
        List<int> startPart = data.GetRange(0, count - amount);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add the rotated parts
        data.AddRange(endPart);
        data.AddRange(startPart);
    }
}