using Avalonia.Controls;
using Avalonia.Interactivity;
using ProjectManager;
using System.Linq;

namespace projectManager.views
{
    public partial class homePage : UserControl
    {
        private readonly mainWindow _mainWindow;
        private readonly csvCommands _csvService; // <-- updated to match your class

        public homePage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _csvService = new csvCommands(); // <-- updated to match your class

            // Hook up button clicks
            PersonalButton.Click += personalButton_Click;
            SchoolButton.Click += schoolButton_Click;
        }

        private void personalButton_Click(object? sender, RoutedEventArgs e)
        {
            openDashboard("Personal");
        }

        private void schoolButton_Click(object? sender, RoutedEventArgs e)
        {
            openDashboard("School");
        }

        private void openDashboard(string category)
        {
            // Load tasks filtered by category
            var allTasks = _csvService.loadTasks();
            var filteredTasks = allTasks
                .Where(t => t.category.Equals(category, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Create a new dashboard page and pass tasks
            var dashboard = new dashboardPage(_mainWindow, filteredTasks);
            _mainWindow.MainContent.Content = dashboard; // Assuming MainContent is a ContentControl in mainWindow
        }
    }
}
