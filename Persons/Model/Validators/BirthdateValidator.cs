using System;
using System.Collections.Generic;
using System.Text;
using Persons.Model.Interfaces;

namespace Persons.Model.Validators
{
    public class BirthdateValidator : IDateTimeValidator
    {
        public bool IsValid(DateTime d)
        {
            if (DateTime.Today - d < TimeSpan.FromDays(51_135) && d < DateTime.Today) 
            {
                return true;
            }

            return false;
        }
    }
}
