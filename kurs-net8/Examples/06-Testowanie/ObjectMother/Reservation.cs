namespace ObjectMother_sample
{
    public class Reservation
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool HasPaid { get; set; }
        public string Status { get; set; } // np. "Confirmed", "Canceled", "CheckedIn"
    }
}
