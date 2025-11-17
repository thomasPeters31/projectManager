using Avalonia.Controls;
using Avalonia.Interactivity;

namespace projectManager.views
{
    public partial class loginPage : UserControl
    {
        private readonly mainWindow _mainWindow;

        public loginPage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void LoginButton_Click(object? sender, RoutedEventArgs e)
        {
            // Dummy login validation
            if (!string.IsNullOrWhiteSpace(UsernameBox.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                _mainWindow.NavigateToHome(new homePage(_mainWindow));
            }
            else
            {
                var dlg = new Window
                {
                    Title = "Error",
                    Content = new TextBlock { Text = "Enter username and password", Margin = new Avalonia.Thickness(10) },
                    Width = 300,
                    Height = 150
                };
                dlg.ShowDialog(_mainWindow);
            }
        }
    }
}
