namespace AssertClass.Tests
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }             // Saldo jest domyślnie 0
        public bool IsVerifiedByCompliance { get; set; } // Musi być zweryfikowane
        public bool IsActive { get; set; }               // Musi być aktywne
        public required string Currency { get; set; }    // Domyślnie "PLN"
    }
}
