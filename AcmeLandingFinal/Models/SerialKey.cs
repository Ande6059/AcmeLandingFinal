using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeLandingFinal.Models
{
    public class SerialKey
    {
        [Key]
        public int KeyId { get; set; }

        public string KeyCode { get; set; }

        public int NumberOfUses { get; set; }

        public bool Validity { get; set; } = true;
    }
}
