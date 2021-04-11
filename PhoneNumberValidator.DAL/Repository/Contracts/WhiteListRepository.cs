using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.DAL.Repository.Contracts
{
    public class WhiteListRepository : Repository<WhiteList>, IWhiteListRepository
    {
        public WhiteListRepository(ValidatorDBContext context) : base(context)
        {
                
        }
    }
}
