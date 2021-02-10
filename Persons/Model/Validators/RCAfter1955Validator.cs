using Persons.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Persons.Model.Validators
{
    public class RCAfter1955Validator : IStringValidator
    {
        Regex r = new Regex("^[0-9]{6}/[0-9]{4}$");

        public bool IsValid(string s)
        {
            if (!string.IsNullOrEmpty(s) && r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
