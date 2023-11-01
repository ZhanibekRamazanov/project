using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PhoneNumberDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public bool IsMain { get; set; }
        
    }
}