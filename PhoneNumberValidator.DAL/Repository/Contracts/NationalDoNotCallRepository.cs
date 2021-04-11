using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneNumberValidator.DAL.Repository.Contracts
{
    public class NationalDoNotCallRepository : Repository<NationalDoNotCall>, INationalDoNotCallRepository
    {
        ValidatorDBContext _context;
        public NationalDoNotCallRepository(ValidatorDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string number)
        {
            return await Task.Run(() => _context.Set<NationalDoNotCall>().Any(x => x.PhoneNo == number));
        }

        public async Task<bool> IsMemberAndNationalDoNotCallAsync(string number)
        {
            return await Task.Run(() => _context.Set<NationalDoNotCall>()
                                 .Any(x => x.PhoneNo == number && x.Persons
                                 .Any(y => y.IsMember == true)));

        }
    }
}
