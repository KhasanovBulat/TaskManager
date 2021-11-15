using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Project
    {
        string description;
        DateTime dueDate;
        Employee customer;
        TeamLeader teamLeader;
        public List<Task> tasks;
        public StatusProject status;
        public Project(string Description, DateTime time, Employee customer, TeamLeader Leader)
        {
            description = Description;
            dueDate = time;
            status = StatusProject.Project;
            this.customer = customer;
            teamLeader = Leader;
            tasks = new List<Task>(10);
            Console.WriteLine("Создан проект " + this);
        }
        public override string ToString()
        {
            return "\"" + description + "\", статус: \"" + status + "\" срок выполнения " + dueDate.ToString();
        }
        public static void StartProject()
        {
            Employee customer = new Employee("Имя заказчика");
            List<Performer> performers = new List<Performer>(10);
            TeamLeader teamLeader = new TeamLeader("Имя тимлидера", performers);
            Project project = new Project("Название проекта", new DateTime(2021, 11, 13), customer, teamLeader);
            performers.Add(new Performer("Сотрудник 1"));
            performers.Add(new Performer("Сотрудник 2"));
            performers.Add(new Performer("Сотрудник 3"));
            performers.Add(new Performer("Сотрудник 4"));
            performers.Add(new Performer("Сотрудник 5"));
            performers.Add(new Performer("Сотрудник 6"));
            performers.Add(new Performer("Сотрудник 7"));
            performers.Add(new Performer("Сотрудник 8"));
            performers.Add(new Performer("Сотрудник 9"));
            performers.Add(new Performer("Сотрудник 10"));
            int numberEmployees = 0;
            while (numberEmployees < 10)
            {
                Console.WriteLine("Введите задачу");
                string answer = Console.ReadLine();
                if (answer == "exit")
                    break;
                if (teamLeader.CreateTask(new Task(answer, DateTime.Now), project))
                {
                    Console.WriteLine("Задачу взяли");
                }
                else
                {
                    Console.WriteLine("Задача была отклонена");
                }
            }
            project.status = StatusProject.Execution;
            Console.WriteLine(project);
            for (int i = 0; i < teamLeader.subordinates.Count; i++)
            {
                for (int j = 0; j < teamLeader.subordinates[i].tasks.Count; j++)
                {
                    teamLeader.subordinates[i].CreateReport(teamLeader.subordinates[i].tasks[j]);
                }
            }
            project.status = StatusProject.Close;
            Console.WriteLine(project);
        }
    }
}
