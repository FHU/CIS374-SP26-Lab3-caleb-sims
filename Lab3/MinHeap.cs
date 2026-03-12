using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3;

public class MinHeap<T> where T : IComparable<T>
{
    private T[] array;
    private const int initialSize = 8;

    public int Count { get; private set; }

    public int Capacity => array.Length;

    public bool IsEmpty => Count == 0;


    public MinHeap(T[] initialArray = null)
    {
        array = new T[initialSize];
        if (initialArray == null)
            return;
        foreach (var item in initialArray)
        {
            Add(item);
        }

    }

    /// <summary>
    /// Returns the min item but does NOT remove it.
    /// Time complexity: O( 1 )
    /// </summary>
    public T Peek()
    {
        return array[0];
    }

    // TODO
    /// <summary>
    /// Adds given item to the heap.
    /// Time complexity: O(log(n)) ***BUT*** it might be O(N) if we have to resize
    /// </summary>
    public void Add(T item)
    {
        array[Count] = item;
        TrickleUp(Count);
        Count++;

        if (Count == Capacity)
        {
            DoubleArrayCapacity();
        }
    }

    public T Extract()
    {
        return ExtractMax();
    }

    /// <summary>
    /// Removes and returns the max item in the min-heap.
    /// Time complexity: O( ? )
    /// </summary>
    public T ExtractMax()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        int maxIndex = 0;
        for (int i = 0; i < Count; i++)
        {
            if (array[i].CompareTo(array[maxIndex]) > 0)
            {
                maxIndex = i;
            }
        }
        T max = array[maxIndex];
        Remove(max);
        return max;
    }

    // TODO
    /// <summary>
    /// Removes and returns the min item in the min-heap.
    /// Time complexity: O( log(n) )
    /// </summary>
    public T ExtractMin()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        T min = array[0];

        array[0] = array[Count - 1];

        Count--;

        TrickleDown(0);

        return min;
    }


    /// <summary>
    /// Returns true if the heap contains the given value; otherwise false.
    /// Time complexity: O( n )
    /// </summary>
    public bool Contains(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (array[i].CompareTo(value) == 0)
            {
                return true;
            }
        }
        return false;
    }

    // TODO
    /// <summary>
    /// Updates the first element with the given value from the heap.
    /// Time complexity: O( n )
    /// </summary>
    public void Update(T oldValue, T newValue)
    {
        if (IsEmpty || !Contains(oldValue))
            throw new InvalidOperationException();

        // find the node to update - O(n)
        int oldIndex = GetIndex(oldValue);

        // update value - O(1)
        array[oldIndex] = newValue;

        // trickle up or trickle down - O( log(n) )
        if (oldValue.CompareTo(newValue) < 0)
        {
            TrickleDown(oldIndex);
        }
        else
        {
            TrickleUp(oldIndex);
        }

    }

    private int GetIndex(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (array[i].CompareTo(value) == 0)
                return i;
        }
        return -1;
    }

    // TODO
    /// <summary>
    /// Removes the first element with the given value from the heap.
    /// Time complexity: O( n )
    /// </summary>
    public void Remove(T value)
    {
        if (IsEmpty || !Contains(value))
            throw new InvalidOperationException();

        int index = GetIndex(value);

        // move last element into this spot
        Swap(index, Count - 1);

        Count--;

        // if we removed the last element, nothing left to fix
        if (index >= Count)
            return;

        // decide whether to trickle up or down
        int parent = Parent(index);

        if (index > 0 && array[index].CompareTo(array[parent]) < 0)
        {
            TrickleUp(index);
        }
        else
        {
            TrickleDown(index);
        }
    }

    // TODO
    // Time Complexity: O( log n )
    private void TrickleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = Parent(index);
            if (array[index].CompareTo(array[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    // TODO
    // Time Complexity: O( log n )
    private void TrickleDown(int index)
    {
        while (index < Count)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            int smallest = index;

            if (left < Count && array[left].CompareTo(array[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < Count && array[right].CompareTo(array[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest == index)
            {
                break;
            }

            Swap(index, smallest);
            index = smallest;
        }
    }

    // TODO
    /// <summary>
    /// Gives the position of a node's parent, the node's position in the heap.
    /// </summary>
    private static int Parent(int position)
    {
        return (position - 1) / 2;
    }

    // TODO
    /// <summary>
    /// Returns the position of a node's left child, given the node's position.
    /// </summary>
    private static int LeftChild(int position)
    {
        return 2 * position + 1;
    }

    // TODO
    /// <summary>
    /// Returns the position of a node's right child, given the node's position.
    /// </summary>
    private static int RightChild(int position)
    {
        return 2 * position + 2;
    }

    private void Swap(int index1, int index2)
    {
        var temp = array[index1];

        array[index1] = array[index2];
        array[index2] = temp;
    }

    private void DoubleArrayCapacity()
    {
        Array.Resize(ref array, array.Length * 2);
    }
}