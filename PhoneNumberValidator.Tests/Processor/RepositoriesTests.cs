using Moq;
using PhoneNumberValidator.DAL;
using PhoneNumberValidator.DAL.Repository.Contracts;
using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneNumberValidator.Processor
{
    public class RepositoriesTests
    {
        private Mock<IInternalDoNotCallRepository> _repositoryInternalMock;

        public RepositoriesTests()
        {
            //Mock immitates functiuonality of the object
            _repositoryInternalMock = new Mock<IInternalDoNotCallRepository>();
        }

        [Fact]
        public void ShouldSavePhoneNum() {
            try
            {
                _repositoryInternalMock.Setup(x => x.GetAllAsync());
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
