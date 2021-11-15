using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Task
    {
        public StatusTask status;
        public string description;
        DateTime time;
        public TeamLeader leader;
        public Performer performer;
        public Report report;
        public Task(string description, DateTime time)
        {
            this.description = description;
            this.time = time;
            Console.WriteLine("Создана задача \"" + description + "\"");
        }
        public override string ToString()
        {
            return "\"" + description + "\"";
        }
    }
}
