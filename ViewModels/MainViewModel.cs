using System.Collections.ObjectModel;
using LogManagerApp.Models;

namespace LogManagerApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<LogMessage> Messages { get; set; } = new ObservableCollection<LogMessage>();

        private LogManager _logManager = new LogManager();

        // Фильтры
        public LogType? SelectedType { get; set; } = null;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public MainViewModel()
        {
            _logManager.Add(LogType.Info, DateTime.Now.AddMinutes(-10), "Программа запущена");
            Refresh();
        }

        public void AddMessage(LogType type, string text)
        {
            _logManager.Add(type, DateTime.Now, text);
            Refresh();
        }

        public void SaveLogs(string path)
        {
            _logManager.SaveToFile(path);
        }

        public void ApplyFilter()
        {
            DateTime from = FromDate ?? DateTime.MinValue;

            DateTime to = ToDate.HasValue
                ? ToDate.Value.Date.AddDays(1).AddTicks(-1) // конец дня
                : DateTime.MaxValue;

            var result = _logManager.GetByDateRange(from, to);

            if (SelectedType != null)
                result = result.Where(m => m.Type == SelectedType).ToList();

            Messages.Clear();
            foreach (var msg in result)
                Messages.Add(msg);
        }

        public void ResetFilter()
        {
            SelectedType = null;
            FromDate = null;
            ToDate = null;
            Refresh();
        }

        private void Refresh()
        {
            Messages.Clear();
            foreach (var msg in _logManager.GetByDateRange(DateTime.MinValue, DateTime.MaxValue))
                Messages.Add(msg);
        }
    }
}