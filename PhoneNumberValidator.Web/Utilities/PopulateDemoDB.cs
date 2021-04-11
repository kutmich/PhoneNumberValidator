using PhoneNumberValidator.DAL.Repository.Contracts;
using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Web.Utilities
{
    public class PopulateDemoDB
    {
        private readonly INationalDoNotCallRepository _nationalDoNotCallRepository;
        private readonly IInternalDoNotCallRepository _internalDoNotCallRepository;
        private readonly IWhiteListRepository _whiteListRepository;
        private readonly IPersonRepository _personRepository;


        public PopulateDemoDB(INationalDoNotCallRepository nationalDoNotCallRepository,
                              IInternalDoNotCallRepository internalDoNotCallRepository,
                              IWhiteListRepository whiteListRepository,
                              IPersonRepository personRepository)
        {
            _nationalDoNotCallRepository = nationalDoNotCallRepository;
            _internalDoNotCallRepository = internalDoNotCallRepository;
            _whiteListRepository = whiteListRepository;
            _personRepository = personRepository;
        }

        internal void start()
        {
            PopulateNationalDoNotCallList();
            PopulateInternalDoNotCallList();
            PopulateWhiteList();
            PopulatePerson();
        }

        private void PopulateNationalDoNotCallList()
        {
            try {
                var items = new List<NationalDoNotCall>();
                items.Add(item: new NationalDoNotCall() { PhoneNo = "5321695487", Persons = { new Person() { Name = "Amthony Smith", IsMember = true }, new Person() { Name = "Sue Smith", IsMember = true } } });//assume that can be one to many realtion
                items.Add(new NationalDoNotCall() { PhoneNo = "5749875634" });
                items.Add(new NationalDoNotCall() { PhoneNo = "1547894653" });

                _nationalDoNotCallRepository.AddRangeAsync(items);
                _nationalDoNotCallRepository.SaveAsync();
            } 
            catch(Exception e)
            {
                var t = e;
            }
      
        }

        private void PopulateInternalDoNotCallList()
        {
            var items = new List<InternalDoNotCall>();
            items.Add(new InternalDoNotCall() { Active = true, CreatedBy = "John Stone", CreationDate = RandomDate(), ExparationDate = FeatureDate(), DeactivationDate = RandomDate(), DeactivatedBy = null, DeactivationSource = null, PersonName = "Donald Morris", PhoneNo = "65479738976", UpdateDate = RandomDate() });
            items.Add(new InternalDoNotCall() { Active = true, CreatedBy = "Matt Darci", CreationDate = RandomDate(), ExparationDate = FeatureDate(), DeactivationDate = RandomDate(), DeactivatedBy = null, DeactivationSource = null, PersonName = "Martin Larry", PhoneNo = "15243226797", UpdateDate = RandomDate() });
            items.Add(new InternalDoNotCall() { Active = true, CreatedBy = "Ann Mart", CreationDate = RandomDate(), ExparationDate = FeatureDate(), DeactivationDate = RandomDate(), DeactivatedBy = null, DeactivationSource = null, PersonName = "Ann Toten", PhoneNo = "54987563134", UpdateDate = RandomDate() });

            _internalDoNotCallRepository.AddRangeAsync(items);
            _internalDoNotCallRepository.SaveAsync();
        }

        private void PopulateWhiteList()
        {
            var items = new List<WhiteList>();
            items.Add(new WhiteList() { CreatedBy = "System", PhoneNo = "5332145687", Reason = "Toronto King Liberty Club: 169", CreationDate = RandomDate(), Source = "Location" });
            items.Add(new WhiteList() { CreatedBy = "Person", PhoneNo = "1324657598", Reason = "Wonderland 948", CreationDate = RandomDate(), Source = "Location" });
            items.Add(new WhiteList() { CreatedBy = "Owner", PhoneNo = "6548664530", Reason = "Alenby 45", CreationDate = RandomDate(), Source = "Location" });

            _whiteListRepository.AddRangeAsync(items);
            _whiteListRepository.SaveAsync();
        }


        private void PopulatePerson()
        {
            var items = new List<Person>();
            items.Add(new Person() { Name = "Gordon Lucket", IsMember = false});
            items.Add(new Person() { Name = "Mark Twen", IsMember=false});

            _personRepository.AddRangeAsync(items);
            _personRepository.SaveAsync();
        }

        private DateTime RandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;

            return start.AddDays(gen.Next(range));
        }

        private DateTime FeatureDate()
        {
           return new DateTime(2030, 1, 1);
        }

        private string RandomPhoneNumber(int length)
        {

            var chars = "0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

    }
}
