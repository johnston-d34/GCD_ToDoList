using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDos
    {
        public string TDL { get; set; }

        public string SaveToCSV()
        {
            return this.TDL + ",";
        }

        public static ToDos LoadFromCSV(string csv)
        {
            String[] tokens = csv.Split(',');
            string todos = tokens[0];
            return new ToDos() { TDL = todos };
        }
    }
}
