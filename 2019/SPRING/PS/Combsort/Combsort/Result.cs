namespace Combsort
{
    public class Result
    {
        public readonly int IterationAmount;
        public readonly int Size;
        public readonly double Time;

        public Result(int size, int itAmount, double time)
        {
            Size = size;
            IterationAmount = itAmount;
            Time = time;
        }
    }
}
