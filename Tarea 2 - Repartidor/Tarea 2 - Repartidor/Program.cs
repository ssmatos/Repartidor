using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Tarea_2___Repartidor
{
    public static class Program
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            Random shffl = new Random();

            while (n > 1)
            {
                n--;
                int k = shffl.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        static void Main(string[] args)
        {
            string studentsDir = "";
            string topicsDir = "";
            string[] students = File.ReadAllLines(studentsDir);
            string[] topics = File.ReadAllLines(topicsDir);

            Console.Write(" Insert # of groups: ");
            int groups = int.Parse(Console.ReadLine());
            int studentsLeft = students.Length % groups;
            int topicsLeft = topics.Length % groups;
            if (args.Length == 2)
            {
                studentsDir = $@"{args[0]}";
                topicsDir = $@"{args[1]}";
            }
            List<string> listStudents = students.ToList();
            List<string> listTopics = topics.ToList();
            listStudents.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            listTopics.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            listStudents.Shuffle();
            listTopics.Shuffle();

            if (students.Length != 0 && topics.Length >= groups)
            {
                for (int i = 1; i <= groups; i++)
                {
                    Console.WriteLine($"\n Group {i}: ");

                    for (int j = 0; j < students.Length/groups; j++)
                    {
                        Console.WriteLine($" {j + 1}. {listStudents[0]}");
                        listStudents.RemoveAt(0);
                    }
                }

                if (studentsLeft > 0)
                {
                    Console.WriteLine($" {students.Length / groups + 1}. {listStudents[0]}");
                    listStudents.RemoveAt(0);
                    studentsLeft--;
                }

                
                Console.WriteLine($"\n Topics: ");

                for (int k = 0; k < groups; k++)
                {
                    Console.WriteLine($"\n Group {k + 1} - {listTopics[0]}");
                    listTopics.RemoveAt(0);
                }

                if (topicsLeft > 0)
                {
                    Console.WriteLine($"           {listTopics[0]}");
                    listTopics.RemoveAt(0);
                    topicsLeft--;
                }

                Console.ReadLine();
            }
        }
    }
}
