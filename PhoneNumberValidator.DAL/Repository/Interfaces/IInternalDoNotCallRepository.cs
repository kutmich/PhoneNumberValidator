using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.DAL.Repository.Interfaces
{
    public interface IInternalDoNotCallRepository : IRepository<InternalDoNotCall>
    {
        Task<bool> ExistsAsync(string number);
    }
}
