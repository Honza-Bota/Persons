using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Persons.Model;
using Persons.Model.Validators;

namespace Persons.ViewModel
{
    class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        #region Binding propertyes
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }
        private DateTime birthdate = new DateTime(2000,1,1);
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Birthdate)));
            }
        }

        private string personalIdentificationNumber;
        public string PersonalIdentificationNumber
        {
            get { return personalIdentificationNumber; }
            set
            {
                personalIdentificationNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonalIdentificationNumber)));
            }
        }
        #endregion

        private Person GetPerson() 
        {
            Person p;

            if (Birthdate < new DateTime(1954,1,1))
            {
                p = new Person(new NameValidator(), new SurnameValidator(), new BirthdateValidator(), new RCBefore1954Validator());
            }
            else
            {
                p = new Person(new NameValidator(), new SurnameValidator(), new BirthdateValidator(), new RCAfter1955Validator());
            }

            bool succes = p.Input(Name,Surname,Birthdate,PersonalIdentificationNumber);

            if (succes)
                return p;
            else return null;

        }

        private static ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand(
                        () =>
                        {
                            Person p = GetPerson();

                            if (p != null)
                            {
                                Debug.WriteLine(p);

                                PersonDatabase.Instance.Add(p);

                                SetValuesToDefault();
                            }

                            else MessageBox.Show("Byl zadán neplatný vstup!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                }
                return _clickCommand;
            }
        }


        private void SetValuesToDefault()
        {
            Name = "";
            Surname = "";
            Birthdate = new DateTime(2000, 1, 1);
            PersonalIdentificationNumber = "";
        }

        public string ShowPersons()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string,Person> z in PersonDatabase.Instance.GetDatabase())
            {
                sb.Append("- " + z.Value + "\n");
            }

            return sb.ToString();
        }
    }
}
