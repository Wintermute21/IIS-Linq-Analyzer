using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tx.Core;
using Tx.Windows;
namespace ParseIIS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var txFile = W3CEnumerable.FromFile("access.log"); //assumes file is in the same directory as the exe
     
            var linqOutput = (from txresult in txFile where txresult.s_port == "80" && !txresult.s_ip.StartsWith("207.114") && txresult.cs_method == "GET" group txresult.c_ip by txresult.c_ip into h select new {Count = h.Count(), IP = h.Key});

            using (TextWriter writer = new StreamWriter(@"C:\Users\John\output.csv", false, System.Text.Encoding.UTF8)) //replace output path as desired. 
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.RegisterClassMap<LogClassMap>();
                csvWriter.WriteRecords(linqOutput);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
