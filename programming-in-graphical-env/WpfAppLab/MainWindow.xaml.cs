using Microsoft.Win32;
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
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Windows.Automation;

namespace WpfAppLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public string? saveFilePath;
        public bool changesSaved = true;
        public NewEmployeeWindow? employeeWindow;
        public MainWindow()
        {
            InitializeComponent();
            EmployeeListView.ItemsSource = Employees;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (!changesSaved)
            {
                switch (MessageBox.Show("Do you want to save changes before closing?", "Save changes", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        Save_Click(sender, e);
                        break;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                LoadEmployees(openFileDialog.FileName);
                foreach(var employee in Employees)
                {
                    employee.PropertyChanged += new PropertyChangedEventHandler(Employee_Changed);
                }
            }
        }

        private void Employee_Changed(object sender, PropertyChangedEventArgs e)
        {
            changesSaved = false;
        }

        private void LoadEmployees(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);
            foreach(var line in lines)
            {
                var parts = line.Split(';');
                var dateFormats = new[] { "dd.MM.yyyy" };
                if (DateTime.TryParseExact(parts[3], dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                {
                    var employee = new Employee(
                        parts[0],
                        parts[1],
                        parts[2],
                        birthDate,
                        parts[4],
                        int.Parse(parts[5]),
                        (Currency)Enum.Parse(typeof(Currency), parts[6]),
                        (Role)Enum.Parse(typeof(Role), parts[7])
                        );
                    Employees.Add(employee);
                }
            }
            saveFilePath = filePath;
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListView.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                int index = Employees.IndexOf(selectedEmployee);
                if (index > 0)
                {
                    Employees.Move(index, index - 1);
                }
                changesSaved = false;
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeListView.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                int index = Employees.IndexOf(selectedEmployee);
                if (index < Employees.Count - 1)
                {
                    Employees.Move(index, index + 1);
                }
                changesSaved = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (saveFilePath == null)
                SaveFile_Click(sender, e);
            SaveToFile(saveFilePath!);
            changesSaved = true;
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "CSV files (*.csv)|*.csv"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveToFile(saveFileDialog.FileName);
                saveFilePath = saveFileDialog.FileName;
                changesSaved = true;
            }
        }

        private void SaveToFile(string filePath)
        {
            var csvLines = new StringBuilder();

            csvLines.AppendLine("First Name;Last Name;Sex;Birth Date;Birth Country;Salary;SalaryCurrency;CompanyRole");
            foreach (var person in Employees)
            {
                var line = string.Format(CultureInfo.InvariantCulture,
                    "{0};{1};{2};{3:dd.MM.yyyy};{4};{5};{6};{7}",
                    person.FirstName,
                    person.LastName,
                    person.Sex,
                    person.BirthDate,
                    person.BirthCountry,
                    person.Salary,
                    (int)person.SalaryCurrency,
                    (int)person.CompanyRole);

                csvLines.AppendLine(line);
            }

            File.WriteAllText(filePath, csvLines.ToString());
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (!changesSaved)
            {
                switch (MessageBox.Show("Do you want to save changes before closing?", "Save changes", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        Save_Click(sender, e);
                        break;
                }
            }
            employeeWindow?.Close();
            Close();
        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (employeeWindow == null)
            {
                employeeWindow = new NewEmployeeWindow(Employees);
                employeeWindow.Closed += OnWindowClose;
                employeeWindow.Show();
            }
            else
            {
                employeeWindow.WindowState = WindowState.Normal;
            }
        }

        private void OnWindowClose(object? sender, EventArgs e)
        {
            employeeWindow = null;
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (this.Employees == null || this.EmployeeListView.SelectedIndex < 0 || this.EmployeeListView.SelectedIndex > Employees.Count - 1)
                return;
            Employees.RemoveAt(EmployeeListView.SelectedIndex);
        }
    }
    public class EnumToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Type enumType && enumType.IsEnum)
            {
                return Enum.GetValues(enumType).Cast<object>().ToList();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SalaryValidationRule : ValidationRule
    {
        public int MinSalary { get; set; } = 5000;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int salary))
            {
                if (salary >= MinSalary)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, $"Salary can not be less than {MinSalary}!");
            }
            return new ValidationResult(false, "Invalid salary value");
        }
    }
}