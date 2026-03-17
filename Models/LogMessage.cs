using System;

namespace LogManagerApp.Models
{
    public enum LogType
    {
        Error,
        Warning,
        Info
    }

    public struct LogMessage
    {
        public LogType Type { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }

        public string DisplayText => $"{DateTime:G} [{Type}] {Text}";
    }
}