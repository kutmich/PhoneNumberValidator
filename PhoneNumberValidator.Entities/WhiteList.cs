using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.Entities
{
    public class WhiteList
    {
        public int ID { get; set; }
        public string PhoneNo { get; set; }//NOT NULL, LEN=10 , ONLY NUMERIC
        public string Reason { get; set; }
        public string Source { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }




    }
}
