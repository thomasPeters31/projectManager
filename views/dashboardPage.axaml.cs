using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using projectManager.views;

namespace projectManager.views
{
    public partial class dashboardPage : UserControl
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }
        public string Category { get; set; }

        private readonly mainWindow _mainWindow;

        public dashboardPage(mainWindow mainWindow, List<TaskItem> tasks)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            Tasks = new ObservableCollection<TaskItem>(tasks);
            if (tasks.Count > 0)
                Category = tasks[0].Category;
            else
                Category = "No Tasks";

            DataContext = this;
        }
    }
}
