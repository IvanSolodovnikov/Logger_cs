using System.IO;

namespace LogManagerApp.Models
{
    public class LogManager
    {
        private List<LogMessage> _messages = new List<LogMessage>();

        public LogMessage this[int index] => _messages[index];

        public int Count => _messages.Count;

        public void Add(LogType type, DateTime dateTime, string text)
        {
            _messages.Add(new LogMessage { Type = type, DateTime = dateTime, Text = text });
        }

        public List<LogMessage> GetByType(LogType type)
        {
            return _messages.Where(m => m.Type == type).ToList();
        }

        public List<LogMessage> GetByDateRange(DateTime from, DateTime to)
        {
            return _messages.Where(m => m.DateTime >= from && m.DateTime <= to).ToList();
        }

        public void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var msg in _messages)
                {
                    sw.WriteLine($"{msg.DateTime:G} [{msg.Type}] {msg.Text}");
                }
            }
        }
    }
}