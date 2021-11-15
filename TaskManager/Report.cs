using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Report
    {
        public string text;
        DateTime dueDate;
        Performer performer;
        public Report(string text, Performer performer)
        {
            dueDate = DateTime.Now;
            this.text = text;
            this.performer = performer;
        }
    }
}
