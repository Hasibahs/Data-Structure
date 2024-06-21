using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree<T> : IEnumerable<T> where T : Student
{
    private Node root;

    private class Node
    {
        public T Value;
        public Node Left;
        public Node Right;

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public BinarySearchTree()
    {
        root = null;
    }

    public void Add(T value)
    {
        root = AddRecursively(root, value);
    }

    private Node AddRecursively(Node node, T value)
    {
        if (node == null)
        {
            node = new Node(value);
        }
        else if (value.Name.CompareTo(node.Value.Name) < 0)
        {
            node.Left = AddRecursively(node.Left, value);
        }
        else
        {
            node.Right = AddRecursively(node.Right, value);
        }

        return node;
    }

    public bool Contains(T value)
    {
        return ContainsRecursively(root, value);
    }

    private bool ContainsRecursively(Node node, T value)
    {
        if (node == null) return false;
        if (node.Value.Equals(value)) return true;

        if (value.Name.CompareTo(node.Value.Name) < 0)
        {
            return ContainsRecursively(node.Left, value);
        }
        else
        {
            return ContainsRecursively(node.Right, value);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(Node node)
    {
        if (node != null)
        {
            foreach (var item in InOrderTraversal(node.Left))
            {
                yield return item;
            }

            yield return node.Value;

            foreach (var item in InOrderTraversal(node.Right))
            {
                yield return item;
            }
        }
    }

    public void QuickSort(SortBy sortBy)
    {
        var array = InOrderTraversal(root).ToArray();
        QuickSort(array, 0, array.Length - 1, sortBy);
        root = null;
        foreach (var item in array)
        {
            Add(item);
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
        var array = InOrderTraversal(root).ToArray();
        MergeSort(array, 0, array.Length - 1, sortBy);
        root = null;
        foreach (var item in array)
        {
            Add(item);
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

    public IEnumerable<T> BinarySearch(SortBy sortBy, string searchTerm)
    {
        var array = InOrderTraversal(root).ToArray();
        QuickSort(array, 0, array.Length - 1, sortBy);
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;
            var comparisonResult = CompareBySearchTerm(array[middle], searchTerm, sortBy);

            if (comparisonResult == 0)
            {
                return new List<T> { array[middle] };
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

        return Enumerable.Empty<T>();
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

    public IEnumerable<T> DepthFirstSearch(string searchTerm)
    {
        var results = new List<T>();
        DepthFirstSearch(root, searchTerm, results);
        return results;
    }

    private void DepthFirstSearch(Node node, string searchTerm, List<T> results)
    {
        if (node == null) return;

        if (node.Value.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        {
            results.Add(node.Value);
        }

        DepthFirstSearch(node.Left, searchTerm, results);
        DepthFirstSearch(node.Right, searchTerm, results);
    }

    internal IEnumerable<Student> DepthFirstSearch(SortBy sortBy, string searchTerm)
    {
        var results = new List<Student>();
        DepthFirstSearch(root, searchTerm, results);

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

        DepthFirstSearch(node.Left, searchTerm, results);
        DepthFirstSearch(node.Right, searchTerm, results);
    }
}
