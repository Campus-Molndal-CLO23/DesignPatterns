// Sorteringsalgoritmer

using System;
using System.Collections.Generic;

/* Gränssnitt för strategier */
public interface ISortStrategy
{
    void Sort(List<int> list);
}

/* Konkret strategi för bubbel sortering */
public class BubbleSortStrategy : ISortStrategy
{
    public void Sort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("List sorted using Bubble Sort");
    }
}

/* Konkret strategi för snabb sortering */
public class QuickSortStrategy : ISortStrategy
{
    public void Sort(List<int> list)
    {
        QuickSort(list, 0, list.Count - 1);
        Console.WriteLine("List sorted using Quick Sort");
    }

    private void QuickSort(List<int> list, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high);

            QuickSort(list, low, pi - 1);
            QuickSort(list, pi + 1, high);
        }
    }

    private int Partition(List<int> list, int low, int high)
    {
        int pivot = list[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        int temp1 = list[i + 1];
        list[i + 1] = list[high];
        list[high] = temp1;
        return i + 1;
    }
}

/* Klass för att hantera sortering */
public class Sorter
{
    private ISortStrategy _sortStrategy;

    public void SetStrategy(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }

    public void Sort(List<int> list)
    {
        _sortStrategy.Sort(list);
    }
}

/* Programklass för att demonstrera strategimönstret med sorteringsalgoritmer */
class Program
{
    static void Main()
    {
        Sorter sorter = new Sorter();
        List<int> list = new List<int> { 34, 7, 23, 32, 5, 62 };

        // Använda bubbel sortering
        sorter.SetStrategy(new BubbleSortStrategy());
        sorter.Sort(list);
        Console.WriteLine(string.Join(", ", list));

        list = new List<int> { 34, 7, 23, 32, 5, 62 };

        // Använda snabb sortering
        sorter.SetStrategy(new QuickSortStrategy());
        sorter.Sort(list);
        Console.WriteLine(string.Join(", ", list));
    }
}

/*
Förklaringar till koden
ISortStrategy: Gränssnitt för strategier som definierar metoden Sort.
BubbleSortStrategy: Konkret strategi för att utföra bubbel sortering.
QuickSortStrategy: Konkret strategi för att utföra snabb sortering.
Sorter: Klass för att hantera sortering och sätta strategin.
Program: Huvudklassen som demonstrerar hur strategimönstret fungerar med sorteringsalgoritmer.
*/
