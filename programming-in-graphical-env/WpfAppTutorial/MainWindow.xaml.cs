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

namespace WpfAppTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> Contacts {  get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Contacts = new ObservableCollection<Contact>();

            DataContext = Contacts;
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_AddContact(object sender, RoutedEventArgs e)
        {
            Opacity = 0.5;

            var addContactWindow = new AddContactWindow();
            if (addContactWindow.ShowDialog().Value)
            {
                Contacts.Add(addContactWindow.NewContact);
            }

            Opacity = 1;
        }

        private void MenuItem_ClearContacts(object sender, RoutedEventArgs e)
        {
            Contacts.Clear();
        }

        private void MenuItem_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple contact manager.",
                "Contact Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public class Contact
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Gender gender { get; set; }
        public Contact()
        {

        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}