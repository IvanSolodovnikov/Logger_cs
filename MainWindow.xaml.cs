using System;
using System.IO;
using System.Windows;

namespace LogManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddLog(string type, string message)
        {
            Logs.Items.Add($"{DateTime.Now:HH:mm:ss} [{type}] {message}");
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            AddLog("INFO", "Информационное сообщение");
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {
            AddLog("WARNING", "Предупреждение");
            MessageBox.Show("Это предупреждение", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            AddLog("ERROR", "Произошла ошибка");
            MessageBox.Show("Произошла ошибка!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter writer = new StreamWriter("logs.txt");

            foreach (var item in Logs.Items)
                writer.WriteLine(item);

            MessageBox.Show("Логи сохранены в logs.txt");
        }
    }
}