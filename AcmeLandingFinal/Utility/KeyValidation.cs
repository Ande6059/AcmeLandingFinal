using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeLandingFinal.Utility
{
    //public class KeyValidation 
    //{

    //    public List<string> listOfDupes = new List<string>();
    //    private readonly FormContext _context;

    //    public KeyValidation(FormContext context)
    //    {
    //        _context = context;
    //    }




    //    public List<string> GetListOfDuplicates()
    //    {





    //        using (var db = _context)
    //        {
    //            List<Form> listOfForms = _context.Form.ToList();

    //            List<string> duplicateKeys = listOfForms
    //                .GroupBy(f => f.ProductSerialNumber)
    //                .Where(k => k.Count() > 1)
    //                .Select(d => d.Key).ToList();
    //            duplicateKeys = listOfDupes;
    //        }
    //        return listOfDupes;

    //    }

    //    //public SerialKey KeyValidator(SerialKey key)
    //    //{
    //    //    if (key.NumberOfUses < 2)
    //    //    {
    //    //        key.Validity = true;

    //    //        return key;
    //    //    }
    //    //    else
    //    //    {
    //    //        key.Validity = false;

    //    //        return key;
    //    //    }

    //    //}
    //}
}
