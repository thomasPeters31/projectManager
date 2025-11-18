using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ProjectManager
{
    // User model
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; } // "Student" or "Teacher"
    }

    // Task model
    public class taskItem
    {
        public int iD { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; } // Homework, Gym, Chores, etc.
        public string assignedTo { get; set; }
        public string assignedBy { get; set; }
        public DateTime dueDate { get; set; }
        public string status { get; set; } // Pending, InProgress, Completed
        public int progress { get; set; } // 0-100
    }

    public class csvCommands
    {
        private readonly string usersFile = "/csvFiles/users.csv";
        private readonly string tasksFile = "/csvFiles/tasks.csv";

        // ---------------- USERS ----------------
        public List<User> loadUsers()
        {
            if (!File.Exists(usersFile))
            {
                File.WriteAllText(usersFile, "id,username,password,role\n");
            }

            using var reader = new StreamReader(usersFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<User>().ToList();
        }

        public void addUser(User user)
        {
            var users = loadUsers();
            user.id = users.Count > 0 ? users.Max(u => u.id) + 1 : 1;
            users.Add(user);

            using var writer = new StreamWriter(usersFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(users);
        }

        // ---------------- TASKS ----------------
        public List<taskItem> loadTasks()
        {
            if (!File.Exists(tasksFile))
            {
                File.WriteAllText(tasksFile, "id,title,description,category,assignedTo,assignedBy,dueDate,status,progress\n");
            }

            using var reader = new StreamReader(tasksFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<taskItem>().ToList();
        }

        public void addTask(taskItem task)
        {
            var tasks = loadTasks();
            task.iD = tasks.Count > 0 ? tasks.Max(t => t.iD) + 1 : 1;
            tasks.Add(task);

            using var writer = new StreamWriter(tasksFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(tasks);
        }

        public void updateTaskStatus(int taskId, string newStatus)
        {
            var tasks = loadTasks();
            var task = tasks.FirstOrDefault(t => t.iD == taskId);
            if (task != null)
            {
                task.status = newStatus;

                using var writer = new StreamWriter(tasksFile);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(tasks);
            }
        }

        public void updateTaskProgress(int taskId, int progress)
        {
            var tasks = loadTasks();
            var task = tasks.FirstOrDefault(t => t.iD == taskId);
            if (task != null)
            {
                task.progress = progress;

                using var writer = new StreamWriter(tasksFile);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(tasks);
            }
        }
    }
}
