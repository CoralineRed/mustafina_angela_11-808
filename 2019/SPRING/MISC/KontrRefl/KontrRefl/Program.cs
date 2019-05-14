using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KontrRefl
{
    class Program
    {
        public static bool CheckAnswer()
        {
            return false;
        }

        public static void ShowResults(string path)
        {
            var directory = new DirectoryInfo(path);
            var taskInfos = directory.EnumerateFiles().OrderBy(x => x.Name).ToList();
            var results = new Dictionary<string, int>();
            foreach (var studentDirectory in directory.EnumerateDirectories())
            {
                var studentResults = studentDirectory.EnumerateFiles().OrderBy(x => x.Name).ToList();
                for (int i = 0; i < taskInfos.Count; i++)
                {
                    var taskInfo = File.ReadAllLines(taskInfos[i].FullName).First().Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    var studentResult = File.ReadAllLines(studentResults[i].FullName).First();
                    var myClass = Type.GetType("KontrRefl." + taskInfo[0]);
                    var method = myClass.GetMethod(taskInfo[1]);
                    var args = new Expression[taskInfo.Count() - 2];
                    for (int j = 2; j < taskInfo.Count(); j++)
                    {
                        var arg = taskInfo[j].Split();
                        args[j - 2] = Expression.Parameter(Type.GetType());
                    }
                    var f = Expression.Lambda(
                        Expression.Call(method, args));
                    
                }
            }
        }

        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            ShowResults(path);
        }
    }
}
