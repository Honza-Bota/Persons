using System;
using System.Collections.Generic;
using System.Text;
using Persons.Model.Interfaces;

namespace Persons.Model
{
    class Person
    {
        readonly IStringValidator nameValidator;
        readonly IStringValidator surnameValidator;
        readonly IDateTimeValidator dateTimeValidator;
        readonly IStringValidator rcValidator;

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; private set; }
        public string PersonalIdentificationNumber { get; private set; }

        public Person(IStringValidator nameVal, IStringValidator surnameVal, IDateTimeValidator dateVal, IStringValidator rcVal)
        {
            nameValidator = nameVal;
            surnameValidator = surnameVal;
            dateTimeValidator = dateVal;
            rcValidator = rcVal;
        }

        private Person()
        {
            nameValidator = surnameValidator = rcValidator = null;
            dateTimeValidator = null;
        }

        public bool Input(string name, string surname, DateTime birthdate, string personalIdentificationNumber)
        {
            bool nameOk, surnameOk, dateOk, rcOk = false;

            if (nameOk = nameValidator.IsValid(name)) Name = name;
            if (surnameOk = surnameValidator.IsValid(surname)) Surname = surname;
            if (dateOk = dateTimeValidator.IsValid(birthdate)) Birthdate = birthdate;
            if (rcOk = rcValidator.IsValid(personalIdentificationNumber)) PersonalIdentificationNumber = personalIdentificationNumber;

            return (nameOk && surnameOk && dateOk && rcOk);
        }

        public override string ToString()
        {
            return $"{Name} {Surname} - {Birthdate.ToShortDateString()} - {PersonalIdentificationNumber}";
        }
    }
}
