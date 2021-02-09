using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Persons.Model;

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
        private DateTime birthdate;
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

        private Person Osoba 
        {
            get { return new Person(Name, Surname, Birthdate, PersonalIdentificationNumber); }
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

                            Debug.WriteLine(Osoba);

                            PersonDatabase.Instance.Add(Osoba);

                            SetValuesToDefault();
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
