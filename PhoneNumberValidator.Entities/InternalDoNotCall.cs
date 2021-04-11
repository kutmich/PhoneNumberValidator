using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.Entities
{
    public class InternalDoNotCall
    {
        public int ID { get; set; }
        public string PhoneNo { get; set; }//NOT NULL
        public string Source { get; set; }
        public string PersonName { get; set; }
        public Boolean Active { get; set; }//Default true
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }//NOT NULL
        public DateTime ExparationDate { get; set; }//NOT NULL
        public DateTime DeactivationDate { get; set; }
        public string DeactivatedBy { get; set; } 
        public string DeactivationSource { get; set; }
        public DateTime UpdateDate { get; set; }//NOT NULL

        public void AddRange(InternalDoNotCall t)
        {
            throw new NotImplementedException();
        }
    }
}
