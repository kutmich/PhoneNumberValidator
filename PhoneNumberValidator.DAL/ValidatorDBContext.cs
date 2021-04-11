using Microsoft.EntityFrameworkCore;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.DAL
{
    public class ValidatorDBContext : DbContext
    {
        public ValidatorDBContext(DbContextOptions<ValidatorDBContext> options) : base(options) { }
        public DbSet<InternalDoNotCall> internalDoNotCallList { get; set; }
        public DbSet<NationalDoNotCall> nationalDoNotCallList { get; set; }
        public DbSet<WhiteList> whiteList { get; set; }
    }
}
