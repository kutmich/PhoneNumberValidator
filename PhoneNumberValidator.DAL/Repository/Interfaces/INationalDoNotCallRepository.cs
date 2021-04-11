using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.DAL.Repository.Interfaces
{
    public interface INationalDoNotCallRepository : IRepository<NationalDoNotCall>
    {
        Task<bool> IsMemberAndNationalDoNotCallAsync(string number);
        Task<bool> ExistsAsync(string number);  
    }
}
