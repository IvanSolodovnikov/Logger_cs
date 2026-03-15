using System.Windows;
using LogManagerApp.ViewModels;
using LogManagerApp.Models;

namespace LogManagerApp
{
    public partial class MainWindow : Window
    {
        MainViewModel vm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            vm.AddMessage(MessageType.Info);
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {
            vm.AddMessage(MessageType.Warning);
        }

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            vm.AddMessage(MessageType.Error);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveLogs();
        }
    }
}