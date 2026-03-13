public partial class MainWindow : Window
{
    private MainViewModel vm;

    public MainWindow()
    {
        InitializeComponent();

        vm = new MainViewModel();
        DataContext = vm;

        vm.AddMessage(MessageType.Information, "Программа запущена");
        vm.AddMessage(MessageType.Warning, "Низкий уровень памяти");
        vm.AddMessage(MessageType.Error, "Ошибка подключения");
    }
    private void SaveButton_Click(object sender, RoutedEventArgs e)
{
    var dlg = new Microsoft.Win32.SaveFileDialog
    {
        FileName = "log",
        DefaultExt = ".txt",
        Filter = "Text documents (.txt)|*.txt"
    };

    bool? result = dlg.ShowDialog();

    if (result == true)
    {
        string filename = dlg.FileName;
        vm.LogManager.SaveToFile(filename);
        MessageBox.Show("Файл сохранён!");
    }
}
}