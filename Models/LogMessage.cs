using System;

namespace LogManagerApp.Models
{
    public struct LogMessage
    {
        public MessageType Type { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public LogMessage(MessageType type, DateTime time, string text)
        {
            Type = type;
            Time = time;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Time:HH:mm:ss} [{Type}] {Text}";
        }
    }
}