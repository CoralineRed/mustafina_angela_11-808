using System;
using System.Collections.Generic;
using System.Linq;

namespace SetPartition
{
    class Program
    {
        public static void PartitionSet(List<HashSet<int>> set, Func<int, int> func)
        {
            // Формируем словарь прообразов элементов.
            var preimage = new Dictionary<int, int>();
            foreach (var subset in set)
                foreach (var elem in subset)
                    preimage[func(elem)] = elem;
            // Хранит индекс подмножества, в котором лежит элемент.
            var indexOf = new Dictionary<int, int>();
            for (int i = 0; i < set.Count; i++)
                foreach (var elem in set[i])
                    indexOf[elem] = i;
            // Хранят индексы подмножеств, по которым еще нужно провести разбиение.
            var waiting = new Queue<int>(Enumerable.Range(0, set.Count));
            var inWaiting = new HashSet<int>(Enumerable.Range(0, set.Count));
            while (waiting.Count > 0)
            {
                // Вытаскиваем один индекс.
                var ind = waiting.Dequeue();
                inWaiting.Remove(ind);
                // Находим прообраз этого подмножества.
                var setPreimage = set[ind].Select(x => preimage[x]).ToList();
                // Храним индекс подмножества и его пересечение с прообразом.
                var newSubsets = new Dictionary<int, HashSet<int>>();
                foreach (var elem in setPreimage)
                {
                    // Добавляем по индексу элемент, который содержится в прообразе
                    if (!newSubsets.ContainsKey(indexOf[elem]))
                        newSubsets[indexOf[elem]] = new HashSet<int>();
                    newSubsets[indexOf[elem]].Add(elem);
                    // и удаляем его из оригинального подмножества.
                    set[indexOf[elem]].Remove(elem);
                    // Если какое-то подмножество целиком содержится в прообразе, возвращаем его и удаляем из словаря.
                    if (set[indexOf[elem]].Count == 0)
                    {
                        set[indexOf[elem]] = newSubsets[indexOf[elem]];
                        newSubsets.Remove(indexOf[elem]);
                    }
                }
                // Проходим по всем новым подмножествам.
                foreach (var subset in newSubsets)
                {
                    // Добавляем их в лист оригинального множества.
                    set.Add(subset.Value);
                    // Обновляем словарь индексов.
                    foreach (var elem in subset.Value)
                        indexOf[elem] = set.Count - 1;
                    // Если разбиваемое множество уже лежит в ожидании или его размер больше нового подмножества,
                    // кладем индекс нового в ожидание.
                    if (inWaiting.Contains(subset.Key) || set[subset.Key].Count > subset.Value.Count)
                    {
                        waiting.Enqueue(set.Count - 1);
                        inWaiting.Add(set.Count - 1);
                    }
                    // Иначе кладем в ожидание новое подмножество.
                    else
                    {
                        waiting.Enqueue(subset.Key);
                        inWaiting.Add(subset.Key);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var set = new List<HashSet<int>>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                set.Add(new HashSet<int>(Console.ReadLine().Split().Select(x => int.Parse(x))));
            PartitionSet(set, x => (x + 3) % 6);
            foreach (var subset in set)
            {
                foreach (var elem in subset)
                    Console.Write(elem + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
