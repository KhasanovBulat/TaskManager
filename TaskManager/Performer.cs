using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Performer : Employee
    {
        public List<Task> tasks = new List<Task>();
        TeamLeader leader;
        public Performer(string name) : base(name) { }
        public void AddTask(Task task)
        {
            tasks.Add(task);
            task.status = StatusTask.Work;
            Console.WriteLine(task + " " + task.status);
        }
        public TakeTask GetTask(TeamLeader TeamLeader)
        {
            if (tasks.Count > 3)
            {
                return TakeTask.Занят;
            }
            else
            {
                Console.WriteLine("Взять " + Name + " задачу?");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "Нет":
                        return TakeTask.Нет;
                    case "Да":
                        leader = TeamLeader;
                        return TakeTask.Да;
                    default:
                        return TakeTask.Делегировано;
                }
            }
        }
        public void CreateReport(Task task)
        {
            task.status = StatusTask.Inspection;
            string text = "Текст отчёта";
            Console.WriteLine(task + " " + task.status);
            Report report = new Report(text, this);
            task.report = report;
            Console.WriteLine("создан отчёт по задаче " + task);
            while (!leader.AcceptReport(report))
            {
                Console.WriteLine("создан отчёт по задаче " + task);
            }
            task.status = StatusTask.Assigned;
            Console.WriteLine(task + " " + task.status);
        }
    }
}
