using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneNumberValidator.Entities
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }
    }
}
