using System.Collections.ObjectModel;

public class MainViewModel
{
    private LogManager logManager;
    public LogManager LogManager => logManager;

    public ObservableCollection<LogMessage> Messages { get; set; }

    public MainViewModel()
    {
        logManager = new LogManager();
        Messages = new ObservableCollection<LogMessage>();
    }

    public void AddMessage(MessageType type, string text)
    {
        var message = new LogMessage(type, DateTime.Now, text);

        logManager.AddMessage(message);
        Messages.Add(message);
    }
}