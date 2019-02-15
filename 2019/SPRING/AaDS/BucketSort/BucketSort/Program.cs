using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    public class ListElement<T>
    {
        public readonly T Value;
        public ListElement<T> Next { get; set; }
        public ListElement<T> Previous { get; set; }

        public ListElement(T value, ListElement<T> prev, ListElement<T> next)
        {
            Value = value;
            Previous = prev;
            Next = next;
        }
    }

    public class MyList<T>
    {
        public ListElement<T> Head { get; private set; }
        public ListElement<T> Tail { get; private set; }

        public MyList() : this(null, null) { }

        public MyList(ListElement<T> head, ListElement<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public void PushFront(T value)
        {
            var newItem = new ListElement<T>(value, Head, null);
            if (Head != null) Head.Next = newItem;
            Head = newItem;
            if (Tail == null) Tail = newItem;
        }

        public void PushBack(T value)
        {
            var newItem = new ListElement<T>(value, null, Tail);
            Tail = newItem;
            if (Head == null) Head = newItem;
        }

        public T PopFront()
        {
            T value = Head.Value;
            Head = Head.Previous;
            if (Head == null) Tail = null;
            return value;
        }

        public T PopBack()
        {
            T value = Tail.Value;
            Tail = Tail.Next;
            if (Tail == null) Head = null;
            return value;
        }

        public static void Insert(T value, ListElement<T> previous, ListElement<T> next)
        {
            var newItem = new ListElement<T>(value, previous, next);
            previous.Next = newItem;
            next.Previous = newItem;
        }
    }

    class Program
    {
        public static void BucketSort(MyList<string> arr)
        {
            
        }

        static void Main(string[] args)
        {
            var array = new MyList<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                array.PushFront(Console.ReadLine());
            BucketSort(array);
            
        }
    }
}
