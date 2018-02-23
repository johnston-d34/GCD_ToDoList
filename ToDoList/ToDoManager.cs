using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    class ToDoManager
    {
        private List<ToDos> todos;

        //Constructor
        public ToDoManager()
        {
            todos = new List<ToDos>();
        }

        public void Add(ToDos t)
        {
            todos.Add(t);
        }

        public void Clear()
        {
            todos.Clear();
        }

        public int Count()
        {
            return todos.Count();
        }

        public List<ToDos> GetList()
        {
            return todos;
        }

        public void SaveToCSV(string fname)
        {
            List<string> lines = new List<string>();
            foreach(ToDos t in todos)
            {
                lines.Add(t.SaveToCSV());
            }
            File.WriteAllLines(fname, lines);
        }

        public void LoadFromCSV(string fname)
        {
            string[] lines = File.ReadAllLines(fname);
            foreach(string line in lines)
            {
                ToDos t = ToDos.LoadFromCSV(line);
                todos.Add(t);
            }
        }
    }
}
