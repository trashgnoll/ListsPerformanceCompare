using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace ListsPerformanceCompare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load file from SLN folder:
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Text1.txt");
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine($"Lines loaded, {lines.Length} total");
            
            // Check for List<T>:
            List<string> list = new();
            var timer = new Stopwatch();
            timer.Start();
            foreach (string line in lines)
                list.Add(line);
            timer.Stop();
            TimeSpan result = timer.Elapsed;
            Console.WriteLine($"List<T> time: {result}");

            // Check for LinkedList<T>:
            LinkedList<string> linkedList = new();
            timer.Start();
            foreach (string line in lines)
                linkedList.AddLast(line);
            timer.Stop();
            TimeSpan result2 = timer.Elapsed;
            Console.WriteLine($"LinkedList<T> time: {result}");

            // Difference:
            StringBuilder sb = new();
            sb.Append(result2.TotalMilliseconds > result.TotalMilliseconds ? "List<T>" : "LinkedList <T>");
            sb.Append(" is faster\n" );
            sb.Append($"Difference): " +
                $"{Math.Max(result.TotalMilliseconds, result2.TotalMilliseconds)- Math.Min(result.TotalMilliseconds, result2.TotalMilliseconds)} (msec)");
            Console.WriteLine(sb);
        }
    }
}