using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KontrRefl2
{
    public class Comment
    {
        public int postId;
        public int id;
        public string name;
        public string email;
        public string body;

    }

    class Program
    {
        public static void CountBody(Comment comment)
        {
            if (comment.id % 2 == 0)
                Console.WriteLine("id : " + comment.id + "\tletters count : "
                    + comment.body.Sum(x => char.IsLetter(x) ? 1 : 0));
        }

        static void Main(string[] args)
        {
            var json = File.ReadAllText("json.txt");
            var comments = JsonConvert.DeserializeObject<List<Comment>>(json);
            Parallel.ForEach(comments, CountBody);
            Console.ReadKey();
        }
    }
}
