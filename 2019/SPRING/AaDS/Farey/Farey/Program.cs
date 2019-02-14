using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
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

        public T Pop()
        {
            T value = Head.Value;
            Head = Head.Previous;
            if (Head == null) Tail = null;
            return value;
        }

        public void Insert(T value, ListElement<T> previous, ListElement<T> next)
        {
            var newItem = new ListElement<T>(value, previous, next);
            previous.Next = newItem;
            next.Previous = newItem;
        }
    }

    public class Rational
    {
        public readonly int Numerator;
        public readonly int Denominator;

        public Rational(int num, int den)
        {
            Numerator = num;
            Denominator = den;
        }
    }

    class Program
    {
        public static MyList<Rational> Farey(int n)
        {
            var fareyNumbers = new MyList<Rational>();
            fareyNumbers.PushFront(new Rational(0, 1));
            fareyNumbers.PushFront(new Rational(1, 1));
            Insert(fareyNumbers.Tail, fareyNumbers.Head, n);
            return fareyNumbers;
        }

        public static void Insert(ListElement<Rational> prev, ListElement<Rational> next, int n)
        {
            if (prev.Value.Denominator + next.Value.Denominator <= n)
            {
                var newValue = new Rational(prev.Value.Numerator + next.Value.Numerator, prev.Value.Denominator + next.Value.Denominator);
                var newItem = new ListElement<Rational>(newValue, prev, next);
                prev.Next = newItem;
                next.Previous = newItem;
                Insert(prev, newItem, n);
                Insert(newItem, next, n);
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var fareyNums = Farey(n);
            var currentNum = fareyNums.Tail;
            while (currentNum != null)
            {
                Console.WriteLine(currentNum.Value.Numerator + "/" + currentNum.Value.Denominator);
                currentNum = currentNum.Next;
            }
            Console.ReadKey();
        }
    }
}
