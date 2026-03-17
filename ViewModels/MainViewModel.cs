using System;
using System.Collections.ObjectModel;
using LogManagerApp.Models;

namespace LogManagerApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<LogMessage> Messages { get; set; } = new ObservableCollection<LogMessage>();
        private LogManager _logManager = new LogManager();

        public MainViewModel()
        {
            _logManager.Add(LogType.Info, DateTime.Now, "Программа запущена.");

            foreach (var msg in _logManager.GetByType(LogType.Info))
                Messages.Add(msg);
        }

        public void AddMessage(LogType type, string text)
        {
            var msg = new LogMessage { Type = type, DateTime = DateTime.Now, Text = text };
            _logManager.Add(type, msg.DateTime, text);
            Messages.Add(msg);
        }

        public void SaveLogs(string path)
        {
            _logManager.SaveToFile(path);
        }
    }
}