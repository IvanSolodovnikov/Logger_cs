using System;
using System.Collections.Generic;
using System.IO;

namespace LogManagerApp.Models
{
    public class LogManager
    {
        private List<LogMessage> messages = new List<LogMessage>();

        public int Count => messages.Count;

        public LogMessage this[int index]
        {
            get => messages[index];
            set => messages[index] = value;
        }

        public void Add(LogMessage message)
        {
            messages.Add(message);
        }

        public List<LogMessage> GetByType(MessageType type)
        {
            List<LogMessage> result = new List<LogMessage>();

            foreach (var m in messages)
                if (m.Type == type)
                    result.Add(m);

            return result;
        }

        public List<LogMessage> GetByDateRange(DateTime start, DateTime end)
        {
            List<LogMessage> result = new List<LogMessage>();

            foreach (var m in messages)
                if (m.Time >= start && m.Time <= end)
                    result.Add(m);

            return result;
        }

        public void Save(string path)
        {
            using StreamWriter writer = new StreamWriter(path);

            foreach (var m in messages)
                writer.WriteLine(m.ToString());
        }

        public List<LogMessage> GetAll()
        {
            return messages;
        }
    }
}