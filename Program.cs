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
            // Create a list in which to put my records
            List<DataRecord> records = new List<DataRecord>();

            // Open the file to read
            using (StreamReader input = File.OpenText("data.csv"))
            {
                // Ignore the header record
                input.ReadLine();

                // Read a line. If it's not null, do something with it.
                for (string line = input.ReadLine(); line != null; line = input.ReadLine())
                {
                    // Parse a data record and add it to records
                    records.Add(DataRecord.Parse(line));
                }
            }

            // Sort the records using LINQ
            records = records.OrderBy(x => x.LastName).ToList();

            // Open a file to write the results to
            using (StreamWriter writer = File.CreateText("sorted.csv"))
            {
                // Write the headers
                writer.WriteLine("FirstName|LastName|Email|ChileanRutNumber");

                // Loop over the sorted list
                foreach (DataRe r in records)
                {
                    // Write each row using the fancy $ string thing
                    writer.WriteLine($"{r.FirstName}|{r.LastName}|{r.Email}|{r.Rut}");
                }
            }

            Console.WriteLine();
        }
    }
}
