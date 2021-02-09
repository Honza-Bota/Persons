using System;
using System.Collections.Generic;
using System.Text;
using Persons.Model.Interfaces;

namespace Persons.Model.Validators
{
    class SurnameValidator : IStringValidator
    {
        public bool IsValid(string s) { return (!string.IsNullOrEmpty(s) && s.Length > 1); }
    }
}
