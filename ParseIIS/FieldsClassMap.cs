using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseIIS
{
   public class FieldsClass
    {
        public string IP { get; set; }
        public int IPCount { get; set; }
    }
    public sealed class LogClassMap : ClassMap<FieldsClass>
    {
        public LogClassMap()
        {
            Map(d => d.IPCount);
            Map(d => d.IP).ConvertUsing(m => $"\"{m.IP}\"");

        }
    }
}
