using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three people to the queue with different priorities.
    // Bob has priority 1, Tim has priority 5, and Sue has priority 3.
    // Expected Result: Tim should be returned first because he has the highest priority.
    // Defect(s) Found: The loop in Dequeue did not check the last element and the item was not removed from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", result);
    }

    [TestMethod]
    // Scenario: Add two people to the queue with different priorities.
    // Tim has the highest priority and should be removed first.
    // Expected Result: After removing Tim, Bob should be the next value returned.
    // Defect(s) Found: The Dequeue method did not remove the item from the queue after returning it.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);

        priorityQueue.Dequeue();
        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Bob", result);
    }
}