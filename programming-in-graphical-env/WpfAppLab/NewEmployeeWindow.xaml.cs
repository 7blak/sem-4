using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppLab;

namespace WpfAppLab
{
    /// <summary>
    /// Interaction logic for NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        public ObservableCollection<Employee> employees { get; set; }
        private Employee? _employee;
        private bool isMale = true;
        public NewEmployeeWindow(ObservableCollection<Employee> _employees)
        {
            employees = _employees;
            _employee = new Employee();
            DataContext = _employee;
            InitializeComponent();
        }

        private void MaleSex_Checked(object sender, RoutedEventArgs e)
        {
            isMale = true;
        }

        private void FemaleSex_Checked(object sender, RoutedEventArgs e)
        {
            isMale = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _employee.Sex = isMale ? "Male" : "Female";
            employees.Add( _employee );
            _employee = new Employee();
        }
    }
}
