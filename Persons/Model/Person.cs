using System;
using System.Collections.Generic;
using System.Text;

namespace Persons.Model
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; private set; }
        public string PersonalIdentificationNumber { get; private set; }

        public Person(string name, string surname, DateTime birthdate, string personalIdentificationNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Birthdate = birthdate;
            PersonalIdentificationNumber = personalIdentificationNumber ?? throw new ArgumentNullException(nameof(personalIdentificationNumber));
        }

        public Person()
        {

        }
    }
}
