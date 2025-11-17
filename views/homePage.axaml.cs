using Avalonia.Controls;

namespace projectManager.views
{
    public partial class homePage : UserControl
    {
        private readonly mainWindow _mainWindow;

        public homePage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
    }
}
