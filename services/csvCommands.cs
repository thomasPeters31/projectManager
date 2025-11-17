using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ProjectManager.services
{
    // User model
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Student" or "Teacher"
    }

    // Task model
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // Homework, Gym, Chores, etc.
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } // Pending, InProgress, Completed
        public int Progress { get; set; } // 0-100
    }

    public class CsvService
    {
        private readonly string usersFile = "users.csv";
        private readonly string tasksFile = "tasks.csv";

        // ---------------- USERS ----------------
        public List<User> LoadUsers()
        {
            if (!File.Exists(usersFile))
            {
                File.WriteAllText(usersFile, "Id,Username,Password,Role\n");
            }

            using var reader = new StreamReader(usersFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<User>().ToList();
        }

        public void AddUser(User user)
        {
            var users = LoadUsers();
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);

            using var writer = new StreamWriter(usersFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(users);
        }

        // ---------------- TASKS ----------------
        public List<TaskItem> LoadTasks()
        {
            if (!File.Exists(tasksFile))
            {
                File.WriteAllText(tasksFile, "Id,Title,Description,Category,AssignedTo,AssignedBy,DueDate,Status,Progress\n");
            }

            using var reader = new StreamReader(tasksFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<TaskItem>().ToList();
        }

        public void AddTask(TaskItem task)
        {
            var tasks = LoadTasks();
            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);

            using var writer = new StreamWriter(tasksFile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(tasks);
        }

        public void UpdateTaskStatus(int taskId, string newStatus)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Status = newStatus;

                using var writer = new StreamWriter(tasksFile);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(tasks);
            }
        }

        public void UpdateTaskProgress(int taskId, int progress)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Progress = progress;

                using var writer = new StreamWriter(tasksFile);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(tasks);
            }
        }
    }
}
