using NUnit.Framework;
using Rhino.Mocks;

namespace SciApp.Core.Test
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private User user;
        private IUserRepository userRepositoryMock;

        [SetUp]
        public void SetUp()
        {

            user = new User() { Username = "UserA" };
            userRepositoryMock = MockRepository.GenerateMock<IUserRepository>();
            //userRepositoryMock.Stub(r => r.GetUser(Arg<int>.Is.Anything)).Return(user).Repeat.Once();
        }

        [Test]
        public void GetUser_ValidUserId_GetUserCorrectly()
        {
            user = new User() { Username = "UserB" };
            var newUser = userRepositoryMock.GetUser(1);

            Assert.AreEqual(user.GetHashCode(), newUser.GetHashCode());
            Assert.AreEqual("UserB", newUser.Username);

        }

        [Test]
        public void Add_ValidUser_GetCalledWithMatchedUserName()
        {
            user = new User() { Username = "UserB" };
            var testUserName = "userA";

            userRepositoryMock.Expect(r => r.Add(Arg<User>.Matches(u => u.Username == testUserName)));
            userRepositoryMock.Add(user);

            userRepositoryMock.VerifyAllExpectations();

        }
    }
}