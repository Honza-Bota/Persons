using System;
using System.Collections.Generic;
using System.Text;

namespace Persons.Model.Interfaces
{
    public interface IDateTimeValidator
    {
        bool IsValid(DateTime d);

    }
}
