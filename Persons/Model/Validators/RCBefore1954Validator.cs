using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Persons.Model.Interfaces;

namespace Persons.Model.Validators
{
    class RCBefore1954Validator : IStringValidator
    {
        Regex r = new Regex("^[0-9]{6}/[0-9]{3}$");

        public bool IsValid(string s)
        {
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
