using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    // Définition du Node correctement
    private class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (_tail == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else if (_head != null)
        {
            _head = _head.Next;
            if (_head != null)
                _head.Prev = null;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_tail == _head)
        {
            _head = _tail = null;
        }
        else if (_tail != null)
        {
            _tail = _tail.Prev;
            if (_tail != null)
                _tail.Next = null;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Next = curr.Next;
                    newNode.Prev = curr;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                    RemoveHead();
                else if (curr == _tail)
                    RemoveTail();
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr != null)
        {
            if (curr.Data == oldValue)
                curr.Data = newValue;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate forward through the linked list
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;
        while (curr != null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Iterate backward through the linked list
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? curr = _tail;
        while (curr != null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString() => "<LinkedList>{" + string.Join(", ", this) + "}";

    // Just for testing
    public bool HeadAndTailAreNull() => _head == null && _tail == null;
    public bool HeadAndTailAreNotNull() => _head != null && _tail != null;
}

// Extension method pour Reverse
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}