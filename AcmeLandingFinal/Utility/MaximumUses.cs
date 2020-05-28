using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeLandingFinal.Utility
{
    //public class MaximumUses : ValidationAttribute
    //{

    //    public string Duplicate;
    //    //private readonly FormContext _context;

    //    public MaximumUses()
    //    {
    //    }


    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        KeyValidation keyValidation = new KeyValidation(FormContext);
    //        List<string> dupes = new List<string>();

    //        var form = (Form)validationContext.ObjectInstance;
    //        dupes = keyValidation.GetListOfDuplicates();

    //        if (dupes.Contains(form.ProductSerialNumber))
    //        {
    //            return new ValidationResult("Key has already been used 2 times");
    //        }
    //        return ValidationResult.Success;
    //    }
    //}
}
