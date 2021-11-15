using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class TeamLeader : Employee
    {
        public List<Performer> subordinates;
        public TeamLeader(string name, List<Performer> subordinates) : base(name)
        {
            this.subordinates = subordinates;
        }
        public bool CreateTask(Task task, Project project)
        {
            if (project.status == StatusProject.Project)
            {
                foreach (Performer performer in subordinates)
                {
                    switch (performer.GetTask(this))
                    {
                        case TakeTask.Да:
                            project.tasks.Add(task);
                            performer.AddTask(task);
                            task.leader = this;
                            task.performer = performer;
                            return true;
                        case TakeTask.Нет:
                            return false;
                        case TakeTask.Делегировано:
                            Console.WriteLine("Задачу пытаются отдать другому сотруднику");
                            break;
                        case TakeTask.Занят:
                            Console.WriteLine("Сотрудник уже загружен работой");
                            break;
                    }
                }
            }
            return false;
        }
        public bool AcceptReport(Report report)
        {
            Console.WriteLine("Принять отчёт?");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "Да":
                    return true;
                case "Нет":
                    return false;
                default:
                    Console.WriteLine("Отчёт не был принят");
                    return false;
            }
        }
    }
}
