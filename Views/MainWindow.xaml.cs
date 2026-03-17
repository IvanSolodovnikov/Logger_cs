using System.Windows;
using LogManagerApp.ViewModels;
using LogManagerApp.Models;

namespace LogManagerApp.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = DataContext as MainViewModel;
        }

        private void AddInfo_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddMessage(LogType.Info, "Новое информационное сообщение");
        }

        private void AddWarning_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddMessage(LogType.Warning, "Новое предупреждение");
        }

        private void AddError_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddMessage(LogType.Error, "Новая ошибка");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string path = "logs.txt";
            _vm.SaveLogs(path);
            MessageBox.Show($"Логи сохранены в {path}");
        }
    }
}