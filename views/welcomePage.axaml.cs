using Avalonia.Controls;
using Avalonia.Interactivity;

namespace projectManager.views
{
    public partial class welcomePage : UserControl
    {
        private readonly mainWindow _mainWindow;

        public welcomePage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Login_Click(object? sender, RoutedEventArgs e)
        {
            _mainWindow.Navigate(new loginPage(_mainWindow));
        }

        private void Register_Click(object? sender, RoutedEventArgs e)
        {
            _mainWindow.Navigate(new registerPage(_mainWindow));
        }
    }
}
