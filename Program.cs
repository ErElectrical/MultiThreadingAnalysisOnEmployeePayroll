using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace TaskParllelLibraryAnalysis
{
    /// <summary>
    /// Multithreading in C# is a process in which multiple threads work simultaneously.
    /// It is a process to achieve multitasking.
    /// It saves time because multiple tasks are being executed at a time.
    /// To create multithreaded application in C#, we need to use System.Threding namespace.
    /// A process represents an application whereas a thread represents a module of the application.
    /// Process is heavyweight component whereas thread is lightweight.
    /// A thread can be termed as lightweight subprocess because it is executed inside a process.
    /// Whenever you create a process, a separate memory area is occupied.But threads share a common memory area.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Analysis of Task Parllel Library *****");


            string[] words = CreateWordArray(@" http://www.gutenberg.org/files/54700/54700-0.txt");

            #region TaskParllel
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Start First Task ");
                GetLongestWord(words);
            },
            () =>
            {
                Console.WriteLine("Start Second Task ");
                GetMostCommonWord(words);
            },
            () =>
            {
                Console.WriteLine("Start third task ");
                GetCountOfWord(words, "sleep");
            }
            );

            #endregion
        }

        /// <summary>
        /// Task parllel library is use when we have to efficiently use the cpu .
        /// as each time we do not depends upon the sequential compling of the program because if any task takes suppose 
        /// 1 min of time than it will provide a bad user experience and no body want to wait at this time
        /// Parallel Programming is a type of programming in which many calculations 
        /// or the execution of processes are carried out simultaneously. 
        /// The Points to Remember while working with Parallel Programming:

        ///The Tasks must be independent.
        ///The order of the execution does not matter
        ///C# Supports Two Types of Parallelism:
        ///Data parallelism:
        ///In the case of Data Parallelism, the operation is applied to each element of a collection.
        ///This means each process does the same work on unique and independent pieces of data.

        ///Example:

        ///Parallel.For
        ///Parallel.ForEach
        ///Task parallelism:
        ///In the case of Task Parallelism independent computations are executed in parallel.
        ///This means each process performs a different function or executes different code sections
        ///that are independent.


        /// </summary>
        /// <param name="words"></param>
        /// <param name="term"></param>
        private static void GetCountOfWord(string[] words, string term)
        {
            var findword = (from word in words
                            where word.ToUpper().Contains(term.ToUpper())
                            select word);
            Console.WriteLine($@"The word {term } occurs {findword.Count()} times");

        }

        private static string  GetLongestWord(string[] words)
        {
            var longesword = (from w in words
                              orderby w.Length descending
                              select w).First();
            Console.WriteLine("Task one longest word is " + longesword);
            return longesword;
        }

        private static void GetMostCommonWord(string[] words)
        {
            var frequencyOrder = (from word in words
                                  where word.Length > 6
                                  group word by word into g
                                  orderby g.Count() descending
                                  select g.Key);
            var commonWords = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 -- The most common words are : ");
            foreach(var v in commonWords)
            {
                Console.WriteLine("  " + v);
            }
            Console.WriteLine(sb.ToString());


           

        }

        private static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Retriving from {uri}");

            string blog = new WebClient().DownloadString(uri);

            return blog.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '|', '/','-','_' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
