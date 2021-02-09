﻿using Persons.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Persons.Model.Validators
{
    class RCAfter1955Validator : IStringValidator
    {
        Regex r = new Regex("^[0-9]{6}/[0-9]{4}$");

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
