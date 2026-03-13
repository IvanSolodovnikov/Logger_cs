using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LogManager
{
    private List<LogMessage> messages;

    public LogManager()
    {
        messages = new List<LogMessage>();
    }

    public int Count => messages.Count;

    public LogMessage this[int index]
    {
        get { return messages[index]; }
        set { messages[index] = value; }
    }

    public void AddMessage(LogMessage message)
    {
        messages.Add(message);
    }

    public List<LogMessage> GetMessagesByType(MessageType type)
    {
        return messages.Where(m => m.Type == type).ToList();
    }

    public List<LogMessage> GetMessagesByTimeRange(DateTime start, DateTime end)
    {
        return messages
            .Where(m => m.DateTime >= start && m.DateTime <= end)
            .ToList();
    }

    public void SaveToFile(string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var msg in messages)
            {
                writer.WriteLine($"{msg.DateTime} [{msg.Type}] {msg.Text}");
            }
        }
    }

    public List<LogMessage> GetAll()
    {
        return new List<LogMessage>(messages);
    }
}