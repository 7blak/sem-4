using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLab
{

    public enum Currency { PLN, USD, EUR, GBP, NOK}
    public enum Role { Worker, SeniorWorker, IT, Manager, Director, Ceo}
    public class Employee : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string sex;
        private DateTime birthDate;
        private string birthCountry;
        private int salary;
        private Currency salaryCurrency;
        private Role companyRole;
        public string FirstName { get => firstName; set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName { get => lastName; set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            } 
        }
        public string Sex { get => sex; set
            {
                sex = value;
                OnPropertyChanged(nameof(Sex));
            } 
        }
        public DateTime BirthDate { get => birthDate; set
            {birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public string BirthCountry { get => birthCountry; set
            {birthCountry = value;
                OnPropertyChanged(nameof(BirthCountry));
            }
        }
        public int Salary { get => salary; set
            {salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
        public Currency SalaryCurrency
        {
            get => salaryCurrency; set
            {salaryCurrency = value;
                OnPropertyChanged(nameof(SalaryCurrency));
            }
        }
        public Role CompanyRole
        {
            get => companyRole; set
            {companyRole = value;
                OnPropertyChanged(nameof(CompanyRole));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        public Employee()
        {
            BirthDate = DateTime.Now.AddYears(-30);
            Salary = 5000;
        }

        public Employee(string firstName, string lastName, string sex, DateTime birthDate, string birthCountry, int salary, Currency salaryCurrency, Role companyRole)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            BirthDate = birthDate;
            BirthCountry = birthCountry;
            Salary = salary;
            SalaryCurrency = salaryCurrency;
            CompanyRole = companyRole;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
