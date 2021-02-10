using System;
using System.Collections.Generic;
using System.Text;
using Persons.Model.Interfaces;

namespace Persons.Model.Validators
{
    public class NameValidator : IStringValidator
    {
        public bool IsValid(string s) { return (!string.IsNullOrEmpty(s) && s.Length > 1); }
    }
}
