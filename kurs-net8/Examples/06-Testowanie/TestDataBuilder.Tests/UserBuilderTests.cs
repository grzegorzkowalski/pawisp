namespace TestDataBuilder.Tests_sample
{
    public class UserBuilderTests
    {
        [Fact]
        public void CanCreateInactiveUser()
        {
            var user = new UserBuilder().WithFirstName("Ala").Inactive().Build();
            Assert.Equal("Ala", user.FirstName);
            Assert.False(user.IsActive);
        }
    }
}