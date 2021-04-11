using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneNumberValidator.DAL.Repository.Contracts
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        ValidatorDBContext _context;
        public PersonRepository(ValidatorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
