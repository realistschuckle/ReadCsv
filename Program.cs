using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataRecord> records = new List<DataRecord>();
            using (StreamReader input = File.OpenText("data.csv"))
            {
                for (string line = input.ReadLine(); line != null; line = input.ReadLine())
                {
                    records.Add(DataRecord.Parse(line));
                }
            }
            records = records.OrderBy(x => x.LastName).ToList();
            using (StreamWriter writer = File.CreateText("sorted.csv"))
            {
                writer.WriteLine("FirstName|LastName|Email|ChileanRutNumber");
                foreach (var r in records)
                {
                    writer.WriteLine($"{r.FirstName}|{r.LastName}|{r.Email}|{r.Rut}");
                }
            }

            Console.WriteLine();
        }
    }
}
