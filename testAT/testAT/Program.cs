using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace testAT
{
    class Program
    {
        public static IList<string> enumerableAminals = new List<string>();
        static void Main(string[] args)
        {
            ReadTxtFile($"{Environment.CurrentDirectory}/AnimalList.txt");
            GetDisctinctNames();
            Console.ReadKey();
        }
        static void GetPercentageDuplicated(string name )
        {
            var query = enumerableAminals.GroupBy(x => x== name)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            decimal percentage = (decimal)((decimal)query.Count  / (decimal)enumerableAminals.Count) * 100m;
            Console.WriteLine($"Animal {name} percetage: {percentage}%");
        }

        static void GetDisctinctNames()
        {
            var listDistinct = enumerableAminals.Select(x=>x).Distinct();
            foreach (var item in listDistinct)
            {
                Console.WriteLine(item);
                GetPercentageDuplicated(item);
            }
        }
        static void ReadTxtFile(string fileName)
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    enumerableAminals.Add(line.ToLower().Trim());
                }
  }
        }
    }
}
