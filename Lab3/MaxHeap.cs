using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3;

public class MaxHeap<T> where T : IComparable<T>
{
    private T[] array;
    private const int initialSize = 8;

    public int Count { get; private set; }

    public int Capacity => array.Length;

    public bool IsEmpty => Count == 0;
    public MaxHeap(T[] initialArray = null)
    {
        array = new T[initialSize];
        if (initialArray == null)
            return;
        foreach (var item in initialArray)
        {
            Add(item);
        }

    }

    public T Peek()
    {
        return array[0];
    }

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

    public T ExtractMax()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        T max = array[0];

        array[0] = array[Count - 1];

        Count--;

        TrickleDown(0);

        return max;
    }

    public T ExtractMin()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        int minIndex = 0;
        for (int i = 1; i < Count; i++)
        {
            if (array[i].CompareTo(array[minIndex]) < 0)
            {
                minIndex = i;
            }
        }
        T min = array[minIndex];
        Remove(min);

        return min;
    }

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

    public void Update(T oldValue, T newValue)
    {
        if (IsEmpty || !Contains(oldValue))
            throw new InvalidOperationException();

        // find the node to update - O(n)
        int oldIndex = GetIndex(oldValue);

        // update value - O(1)
        array[oldIndex] = newValue;

        // trickle up or trickle down - O( log(n) )
        if (oldValue.CompareTo(newValue) > 0)
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

    public void Remove(T value)
    {
        if (IsEmpty || !Contains(value))
            throw new InvalidOperationException();

        // find the node to remove
        int index = GetIndex(value);

        // move last element into removed position
        Swap(index, Count - 1);

        Count--;

        // if we removed the last element, nothing to fix
        if (index >= Count)
            return;

        int parent = Parent(index);

        if (index > 0 && array[index].CompareTo(array[parent]) > 0)
        {
            TrickleUp(index);
        }
        else
        {
            TrickleDown(index);
        }
    }

    private void TrickleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = Parent(index);
            if (array[index].CompareTo(array[parentIndex]) > 0)
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

    private void TrickleDown(int index)
    {
        while (index < Count)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            int greatest = index;

            if (left < Count && array[left].CompareTo(array[greatest]) > 0)
            {
                greatest = left;
            }
            if (right < Count && array[right].CompareTo(array[greatest]) > 0)
            {
                greatest = right;
            }
            if (greatest == index)
            {
                break;
            }

            Swap(index, greatest);
            index = greatest;
        }
    }

    private static int Parent(int position)
    {
        return (position - 1) / 2;
    }

    private static int LeftChild(int position)
    {
        return 2 * position + 1;
    }

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