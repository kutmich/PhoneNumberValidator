using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneNumberValidator.Entities
{
    public class NationalDoNotCall
    {
        public NationalDoNotCall()
        {
            Persons = new HashSet<Person>();
        }
        [Key]
        public string PhoneNo { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
