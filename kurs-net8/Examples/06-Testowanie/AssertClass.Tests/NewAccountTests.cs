namespace AssertClass.Tests
{
    public class NewAccountTests
    {
        [Fact]
        public void NewAccount_MustPassAllComplianceChecks()
        {
            // ARRANGE
            var newAccount = new BankAccount
            {
                AccountNumber = 556789,
                Balance = 0.00M,
                IsVerifiedByCompliance = true,
                IsActive = true,
                Currency = "PLN"
            };

            // ACT & ASSERT: Czyste wywo³anie asercji finansowej
            AccountAssert.ShouldBeNewAndCompliant(newAccount);
        }
    }
}