using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Heap<T> : IEnumerable<T> where T : Student
{
    private List<T> elements = new List<T>();
    private SortBy sortBy;

    public Heap(SortBy sortBy)
    {
        this.sortBy = sortBy;
    }

    public Heap(IEnumerable<T> collection, SortBy sortBy)
    {
        this.sortBy = sortBy;
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        elements.Add(item);
        HeapifyUp(elements.Count - 1);
    }

    public T RemoveMin()
    {
        if (elements.Count == 0)
            throw new InvalidOperationException("The heap is empty.");

        T min = elements[0];
        elements[0] = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        HeapifyDown(0);
        return min;
    }

    public int Count => elements.Count;

    private void HeapifyUp(int index)
    {
        while (index > 0 && Compare(elements[index], elements[Parent(index)]) < 0)
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void HeapifyDown(int index)
    {
        int smallest = index;
        int left = LeftChild(index);
        int right = RightChild(index);

        if (left < elements.Count && Compare(elements[left], elements[smallest]) < 0)
            smallest = left;

        if (right < elements.Count && Compare(elements[right], elements[smallest]) < 0)
            smallest = right;

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int index1, int index2)
    {
        var temp = elements[index1];
        elements[index1] = elements[index2];
        elements[index2] = temp;
    }

    private int Compare(T x, T y)
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

    private int Parent(int index) => (index - 1) / 2;
    private int LeftChild(int index) => 2 * index + 1;
    private int RightChild(int index) => 2 * index + 2;

    public void QuickSort(SortBy sortBy)
    {
        var array = elements.ToArray();
        QuickSort(array, 0, array.Length - 1, sortBy);
        elements = new List<T>(array);
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
        var array = elements.ToArray();
        MergeSort(array, 0, array.Length - 1, sortBy);
        elements = new List<T>(array);
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
        var array = elements.ToArray();
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
        DepthFirstSearch(0, searchTerm, results);
        return results;
    }

    private void DepthFirstSearch(int index, string searchTerm, List<Student> results)
    {
        if (index >= elements.Count) return;

        if (elements[index].Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        {
            results.Add(elements[index]);
        }

        DepthFirstSearch(LeftChild(index), searchTerm, results);
        DepthFirstSearch(RightChild(index), searchTerm, results);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

