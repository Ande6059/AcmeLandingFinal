using AcmeLandingFinal.Models;
using ClassLibrary1;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeLandingFinal.Data
{
    public class DbInitializer
    {
        private ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public static void Initialize(ApplicationDbContext _context)
        {
            _context.Database.EnsureCreated();

            KeyGeneration generateKeys = new KeyGeneration();
            var keyCodes = new List<string>();
            var serialKeys = new SerialKey[99];

            if (!_context.SerialKey.Any())
            {

                keyCodes = generateKeys.KeyGenerator();

                foreach (string s in keyCodes)
                {
                    serialKeys = new SerialKey[]
                    {
                    new SerialKey{KeyCode = s}
                    };

                    foreach (SerialKey serial in serialKeys)
                    {
                        _context.SerialKey.Add(serial);
                    }
                    _context.SaveChanges();

                }


            }

            
            //if (!context.Form.Any())
            //{
            //    var forms = new Form[]
            //    {
            //        new Form{FirstName = "Karl", Lastname = "Johan", DateOfBirth = "02-03-1994", EmailAddress = "aaa@b.dk", ProductSerialNumber = "eb627b18-ffcd-4244-8ddd-f1c3deb7de0d"},
            //        new Form{FirstName = "Maja", Lastname = "Hansen", DateOfBirth = "03-05-1990", EmailAddress = "bbb@c.dk", ProductSerialNumber = "2a98c93f-a64a-45a8-85b1-a019d516082d"},
            //        new Form{FirstName = "Hans", Lastname = "Madsen", DateOfBirth = "20-07-1993", EmailAddress = "ccc@d.dk", ProductSerialNumber = "eb627b18-ffcd-4244-8ddd-f1c3deb7de0d"},
            //        new Form{FirstName = "Kaya", Lastname = "Kul", DateOfBirth = "26-09-1980", EmailAddress = "ddd@e.dk", ProductSerialNumber = "eed0d2a7-6697-459d-aa61-885cc58e2fcf"},
            //        new Form{FirstName = "Mikkel", Lastname = "Sermon", DateOfBirth = "27-10-1995", EmailAddress = "eee@f.dk", ProductSerialNumber = "a249ed54-99fe-4a7f-8b52-83fddff4340c"},
            //        new Form{FirstName = "Benjamin", Lastname = "Lundgren", DateOfBirth = "15-09-1997", EmailAddress = "fff@d.dk", ProductSerialNumber = "da8d5938-658d-4eeb-8885-421f71712412"},
            //    };

            //    foreach (Form f in forms)
            //    {
            //        context.Form.Add(f);
            //    }
            //    context.SaveChanges();
            //}






        }
        

    }
}
