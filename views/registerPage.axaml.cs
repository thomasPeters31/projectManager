using Avalonia.Controls;
using Avalonia.Interactivity;

namespace projectManager.views
{
    public partial class registerPage : UserControl
    {
        private readonly mainWindow _mainWindow;

        public registerPage(mainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void RegisterButton_Click(object? sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameBox.Text) &&
                !string.IsNullOrWhiteSpace(PasswordBox.Text) &&
                PasswordBox.Text == ConfirmBox.Text)
            {
                _mainWindow.NavigateToHome(new homePage(_mainWindow));
            }
            else
            {
                var dlg = new Window
                {
                    Title = "Error",
                    Content = new TextBlock { Text = "Check your input", Margin = new Avalonia.Thickness(10) },
                    Width = 300,
                    Height = 150
                };
                dlg.ShowDialog(_mainWindow);
            }
        }
    }
}
