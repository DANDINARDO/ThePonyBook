using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ThePonyBookApi.Controllers;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services.Interfaces;
using ThePonyBookTest.Api.Base;

namespace ThePonyBookTest.Api.Controllers
{
    public abstract class when_using_user_controller : BaseTestFixture
    {
        protected UserController _sut;
        protected Mock<IUserService> _userServiceMock;

        public override void SetupContext()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        protected void SetupSut()
        {
            _sut = new UserController(_userServiceMock.Object);
        }
    }

    [TestFixture]
    public class when_getting_user_by_email : when_using_user_controller
    {
        private AspNetUser _result;
        private AspNetUser _aspNetUser;
        private string email = "testuser@test.com";

        public override void SetupContext()
        {
            base.SetupContext();

            _aspNetUser = new AspNetUser();

            _userServiceMock.Setup(x => x.GetUserByEmail(email))
                .Returns(_aspNetUser)
                .Verifiable();

            base.SetupSut();
        }

        public override void Act()
        {
            _result = _sut.GetUserByEmail(email);
        }

        [Test]
        public void verify_service_call()
        {
            _userServiceMock.Verify(x => x.GetUserByEmail(email), Times.Once);
        }

        [Test]
        public void verify_return()
        {
            NUnit.Framework.Assert.IsNotNull(_result);
            NUnit.Framework.Assert.IsInstanceOf<AspNetUser>(_result);
        }
    }
}

