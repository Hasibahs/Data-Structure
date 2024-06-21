using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LinkedList<T> : IEnumerable<T> where T : Student
{
    private Node head;

    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public void AddFirst(T value)
    {
        var node = new Node(value) { Next = head };
        head = node;
    }

    public void AddLast(T value)
    {
        var node = new Node(value);
        if (head == null)
        {
            head = node;
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
        }
    }

    public bool Remove(T value)
    {
        if (head == null) return false;
        if (head.Value.Equals(value))
        {
            head = head.Next;
            return true;
        }

        var current = head;
        while (current.Next != null && !current.Next.Value.Equals(value))
        {
            current = current.Next;
        }

        if (current.Next == null) return false;
        current.Next = current.Next.Next;
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void QuickSort(SortBy sortBy)
    {
        var array = this.ToArray();
        QuickSort(array, 0, array.Length - 1, sortBy);
        head = null;
        foreach (var item in array)
        {
            AddLast(item);
        }
    }

    private void QuickSort(T[] array, int low, int high, SortBy sortBy)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high, sortBy);
            QuickSort(array, low, pi - 1, sortBy);
            QuickSort(array, pi + 1, high, sortBy);
        }
    }

    private int Partition(T[] array, int low, int high, SortBy sortBy)
    {
        var pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (Compare(array[j], pivot, sortBy) <= 0)
            {
                i++;
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        var temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;
        return i + 1;
    }

    private int Compare(T x, T y, SortBy sortBy)
    {
        switch (sortBy)
        {
            case SortBy.Name:
                return x.Name.CompareTo(y.Name);
            case SortBy.Age:
                return x.Age.CompareTo(y.Age);
            case SortBy.GPA:
                return x.GPA.CompareTo(y.GPA);
            case SortBy.Major:
                return x.Major.CompareTo(y.Major);
            case SortBy.University:
                return x.University.CompareTo(y.University);
            default:
                throw new ArgumentException("Invalid sort criteria.");
        }
    }

    public void MergeSort(SortBy sortBy)
    {
        var array = this.ToArray();
        MergeSort(array, 0, array.Length - 1, sortBy);
        head = null;
        foreach (var item in array)
        {
            AddLast(item);
        }
    }

    private void MergeSort(T[] array, int left, int right, SortBy sortBy)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(array, left, middle, sortBy);
            MergeSort(array, middle + 1, right, sortBy);
            Merge(array, left, middle, right, sortBy);
        }
    }

    private void Merge(T[] array, int left, int middle, int right, SortBy sortBy)
    {
        int leftArrayLength = middle - left + 1;
        int rightArrayLength = right - middle;
        T[] leftArray = new T[leftArrayLength];
        T[] rightArray = new T[rightArrayLength];
        Array.Copy(array, left, leftArray, 0, leftArrayLength);
        Array.Copy(array, middle + 1, rightArray, 0, rightArrayLength);

        int i = 0, j = 0, k = left;
        while (i < leftArrayLength && j < rightArrayLength)
        {
            if (Compare(leftArray[i], rightArray[j], sortBy) <= 0)
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftArrayLength)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightArrayLength)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    public IEnumerable<Student> BinarySearch(SortBy sortBy, string searchTerm)
    {
        var array = this.ToArray();
        QuickSort(array, 0, array.Length - 1, sortBy);
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;
            var comparisonResult = CompareBySearchTerm(array[middle], searchTerm, sortBy);

            if (comparisonResult == 0)
            {
                return new List<Student> { array[middle] };
            }
            else if (comparisonResult < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return Enumerable.Empty<Student>();
    }

    private int CompareBySearchTerm(T item, string searchTerm, SortBy sortBy)
    {
        switch (sortBy)
        {
            case SortBy.Name:
                return item.Name.CompareTo(searchTerm);
            case SortBy.Age:
                return item.Age.ToString().CompareTo(searchTerm);
            case SortBy.GPA:
                return item.GPA.ToString().CompareTo(searchTerm);
            case SortBy.Major:
                return item.Major.CompareTo(searchTerm);
            case SortBy.University:
                return item.University.CompareTo(searchTerm);
            default:
                throw new ArgumentException("Invalid search criteria.");
        }
    }

    public IEnumerable<Student> DepthFirstSearch(SortBy sortBy, string searchTerm)
    {
        var results = new List<Student>();
        DepthFirstSearch(head, searchTerm, results);

        switch (sortBy)
        {
            case SortBy.Name:
                results = results.OrderBy(s => s.Name).ToList();
                break;
            case SortBy.Age:
                results = results.OrderBy(s => s.Age).ToList();
                break;
            case SortBy.GPA:
                results = results.OrderBy(s => s.GPA).ToList();
                break;
            case SortBy.Major:
                results = results.OrderBy(s => s.Major).ToList();
                break;
            case SortBy.University:
                results = results.OrderBy(s => s.University).ToList();
                break;
            default:
                throw new ArgumentException("Invalid sort criteria.");
        }

        return results;
    }

    private void DepthFirstSearch(Node node, string searchTerm, List<Student> results)
    {
        if (node == null) return;

        if (node.Value.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        {
            results.Add(node.Value);
        }

        DepthFirstSearch(node.Next, searchTerm, results);
    }
}
