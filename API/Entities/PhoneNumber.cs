using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("PhoneNumbers")]
    public class PhoneNumber
    {
        
        public int Id { get; set; }

        public string Number { get; set; }

        public bool IsMain { get; set; }
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        
    }
}