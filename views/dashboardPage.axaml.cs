using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjectManager;

namespace projectManager.views
{
    public partial class dashboardPage : UserControl
    {
        public ObservableCollection<taskItem> tasks { get; set; }
        public string category { get; set; }

        private readonly mainWindow mainWindow;

        public dashboardPage(mainWindow mainWindow, List<taskItem> filteredTasks)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            tasks = new ObservableCollection<taskItem>(filteredTasks);
            category = filteredTasks.Count > 0 ? filteredTasks[0].category : "No Tasks";

            DataContext = this; // Required for binding
        }
    }
}
