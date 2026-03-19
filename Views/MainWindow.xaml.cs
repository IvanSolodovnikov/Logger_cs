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
            _vm.AddMessage(LogType.Info, "Новое сообщение Info");
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
            _vm.SaveLogs("logs.txt");
            MessageBox.Show("Сохранено!");
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            _vm.ApplyFilter();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _vm.ResetFilter();
        }
    }
}