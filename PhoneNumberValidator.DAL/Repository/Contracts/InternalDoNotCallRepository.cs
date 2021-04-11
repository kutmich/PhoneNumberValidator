using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneNumberValidator.DAL.Repository.Contracts
{
    public class InternalDoNotCallRepository : Repository<InternalDoNotCall>, IInternalDoNotCallRepository
    {
        ValidatorDBContext _context;

        public InternalDoNotCallRepository(ValidatorDBContext context) : base(context)
        {
            _context = context;
        }    

        public async Task<bool> ExistsAsync(string number)
        {
            return await Task.Run(() => _context.Set<InternalDoNotCall>().Any(x => x.PhoneNo == number));
        }
    }
}
 