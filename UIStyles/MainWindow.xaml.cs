using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIStyles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}
public partial class MainWindow : Window
{

    public ObservableCollection<Employee> Employees { get; set; }
    public MainWindow()
    {
        InitializeComponent();

        Employees = new ObservableCollection<Employee>
        {
            new Employee { Id = 1, Name = "Nguyễn Văn A", Age = 25, Position = "Developer" },
                new Employee { Id = 2, Name = "Trần Thị B", Age = 30, Position = "Designer" },
                new Employee { Id = 3, Name = "Phạm Văn C", Age = 28, Position = "Tester" }
        };
        customDataGrid.ItemsSource = Employees;
    }
}
