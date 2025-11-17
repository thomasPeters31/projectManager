using Avalonia.Controls;
using Avalonia.Interactivity;
using projectManager.views;
using System.Collections.Generic;

namespace projectManager
{
    public partial class mainWindow : Window
    {
        private Stack<UserControl> navigationStack = new Stack<UserControl>();

        public mainWindow()
        {
            InitializeComponent();

            // Start with Welcome Page
            MainContent.Content = new welcomePage(this);
        }

        public void Navigate(UserControl nextPage)
        {
            if (MainContent.Content is UserControl current)
                navigationStack.Push(current);

            MainContent.Content = nextPage;
        }

        public void NavigateToHome(UserControl homePage)
        {
            navigationStack.Clear();
            MainContent.Content = homePage;
        }

        private void BackButton_Click(object? sender, RoutedEventArgs e)
        {
            if (navigationStack.Count > 0)
                MainContent.Content = navigationStack.Pop();
        }
    }
}
