using System;
using System.Windows;

namespace LogManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // лог при запуске
            AddLog("Приложение запущено");
        }

        private void AddLog(string message)
        {
            Logs.Items.Add($"{DateTime.Now:HH:mm:ss} - {message}");
        }

        private void AddLog_Click(object sender, RoutedEventArgs e)
        {
            AddLog("Добавлено новое сообщение");
        }
    }
}