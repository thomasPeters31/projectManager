using Avalonia.Controls;
using Avalonia.Interactivity;
using projectManager.services;
using System.Linq;

namespace projectManager.views
{
    public partial class homePage : UserControl
    {
        private readonly mainWindow _mainWindow;
        private readonly projectManager.csvCommands _csvService;

        public homePage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _csvService = new CsvService();

            // Hook up button clicks
            PersonalButton.Click += PersonalButton_Click;
            SchoolButton.Click += SchoolButton_Click;
        }

        private void PersonalButton_Click(object? sender, RoutedEventArgs e)
        {
            OpenDashboard("Personal");
        }

        private void SchoolButton_Click(object? sender, RoutedEventArgs e)
        {
            OpenDashboard("School");
        }

        private void OpenDashboard(string category)
        {
            // Load tasks filtered by category
            var allTasks = _csvService.LoadTasks();
            var filteredTasks = allTasks.Where(t => t.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase)).ToList();

            // Create a new dashboard page and pass tasks
            var dashboard = new dashboardPage(_mainWindow, filteredTasks);
            _mainWindow.MainContent.Content = dashboard; // Assuming MainContent is a ContentControl in mainWindow
        }
    }
}
