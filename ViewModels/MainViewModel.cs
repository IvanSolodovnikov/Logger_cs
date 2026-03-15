using System;
using System.Collections.ObjectModel;
using LogManagerApp.Models;

namespace LogManagerApp.ViewModels
{
    public class MainViewModel
    {
        private LogManager manager = new LogManager();

        public ObservableCollection<LogMessage> Logs { get; set; }
            = new ObservableCollection<LogMessage>();

        public void AddMessage(MessageType type)
        {
            LogMessage message = new LogMessage(type, DateTime.Now, type.ToString());

            manager.Add(message);
            Logs.Add(message);
        }

        public void SaveLogs()
        {
            manager.Save("logs.txt");
        }
    }
}