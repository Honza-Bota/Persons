﻿using System;
using System.Collections.Generic;
using System.Text;
using Persons.Model.Interfaces;

namespace Persons.Model.Validators
{
    class NameValidator : IStringValidator
    {
        public bool IsValid(string s) { return s.Length > 1; }
    }
}
