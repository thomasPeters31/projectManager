using Avalonia.Controls;
using ProjectManager;

namespace projectManager.views
{
    public partial class personalProjectsPage : UserControl
    {
        private readonly mainWindow _mainWindow;
        private readonly csvCommands _csvService;

        public personalProjectsPage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _csvService = new csvCommands();

            var tasks = _csvService.loadTasks(); // your CSV method
            projectsGrid.Items = tasks;
        }
    }
}
