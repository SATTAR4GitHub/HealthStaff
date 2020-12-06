/**
 * Author: Abdus Sattar Mia
 * Date: Dec 05, 2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Staff.CustomFields
{
    /// <summary>
    /// This class is for validating date of birth. Gives an error if a user is under 18 years old. 
    /// </summary>
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;
        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    return date.AddYears(_minimumAge) < DateTime.Now;
                }
            }
            return true;
        }
    }
}
