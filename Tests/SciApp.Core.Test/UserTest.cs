using NUnit.Framework;
using Rhino.Mocks;

namespace SciApp.Core.Test
{
    [TestFixture]
    public class UserTest
    {
        private User user;
        private IUserRepository userRepository;

        [SetUp]
        public void SetUp()
        {

            user = new User() { Username = "UserA" };
            userRepository = MockRepository.GenerateMock<IUserRepository>();
            userRepository.Stub(r => r.GetUser(Arg<int>.Is.Anything)).Return(user).Repeat.Once();
        }

        [Test]
        public void Test()
        {

            user = new User() { Username = "UserB" };
            var newUser = userRepository.GetUser(1);

            Assert.AreEqual(user.GetHashCode(), newUser.GetHashCode());
            Assert.AreEqual("UserB", newUser.Username);

        }
    }
}