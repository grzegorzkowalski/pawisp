namespace AssertClass.Tests
{
    public static class AccountAssert
    {
        public static void ShouldBeNewAndCompliant(BankAccount account)
        {
            // 1. Asercja: Saldo początkowe
            Assert.Equal(0.00M, account.Balance);

            // 2. Asercja: Aktywność
            Assert.True(account.IsActive,
                        $"Konto numer {account.AccountNumber} musi być aktywne po utworzeniu.");

            // 3. Asercja: Weryfikacja zgodności (Compliance)
            Assert.True(account.IsVerifiedByCompliance,
                        $"Konto numer {account.AccountNumber} nie przeszło weryfikacji zgodności (Compliance).");

            // 4. Asercja: Waluta domyślna
            Assert.Equal("PLN", account.Currency);
        }
    }
}
