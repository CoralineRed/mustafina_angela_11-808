using System;
using System.Collections.Generic;

namespace Combsort
{
    public class Sorter<T> where T : IComparable, IComparable<T>
    {
        static double shrink = 1.2473309;

        public static int ArraySort(T[] array)
        {
            int iterationCount = 0;
            for (int step = array.Length; step > 1; step = (int)(step / shrink))
                for (int i = 0; i + step < array.Length; i++)
                {
                    iterationCount++;
                    if (array[i].CompareTo(array[i + step]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[i + step];
                        array[i + step] = temp;
                    }
                }
            for (int i = 0; i < array.Length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    iterationCount++;
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            return iterationCount;
        }

        public static int ListSort(LinkedList<T> list)
        {
            int iterationCount = 0;
            for (int step = list.Count; step > 1; step = (int)(step / shrink))
            {
                var first = list.First;
                var last = first;
                for (int i = 0; i < step; i++)
                {
                    iterationCount++;
                    last = last.Next;
                }
                for (int i = 0; i + step < list.Count; i++)
                {
                    iterationCount++;
                    if (first.Value.CompareTo(last.Value) > 0)
                    {
                        var temp = first.Value;
                        first.Value = last.Value;
                        last.Value = temp;
                        iterationCount++;
                    }
                    first = first.Next;
                    last = last.Next;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                var current = list.First;
                bool swapped = false;
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    iterationCount++;
                    if (current.Value.CompareTo(current.Next.Value) > 0)
                    {
                        var temp = current.Value;
                        current.Value = current.Next.Value;
                        current.Next.Value = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            return iterationCount;
        }
    }
}
