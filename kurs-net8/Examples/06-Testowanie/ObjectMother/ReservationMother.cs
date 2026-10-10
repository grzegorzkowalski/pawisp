namespace ObjectMother_sample
{
    public static class ReservationMother
    {
        private static int _nextId = 100;

        private static Reservation CreateBase(string guestName, DateTime checkIn, DateTime checkOut, decimal price)
        {
            return new Reservation
            {
                Id = _nextId++,
                GuestName = guestName,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                TotalPrice = price,
                HasPaid = false,
                Status = "Confirmed"
            };
        }

        // SCENARIUSZ 1: STANDARDOWA rezerwacja na najbliższy weekend
        public static Reservation CreateWeekendStay()
        {
            return CreateBase(
                guestName: "Anna Nowak",
                checkIn: DateTime.Now.AddDays(7),
                checkOut: DateTime.Now.AddDays(9),
                price: 500.00M
            );
        }

        // Wariant do scenariuszy, w których zameldowanie jest możliwe od razu.
        public static Reservation CreateReadyForCheckIn()
        {
            return CreateBase(
                guestName: "Anna Nowak",
                checkIn: DateTime.Now.AddDays(-1),
                checkOut: DateTime.Now.AddDays(1),
                price: 500.00M
            );
        }

        // SCENARIUSZ 2: DROGA, W PEŁNI OPŁACONA rezerwacja biznesowa
        public static Reservation CreatePaidBusinessTrip()
        {
            var reservation = CreateBase(
                guestName: "Piotr Kowalski",
                checkIn: DateTime.Now.AddDays(14),
                checkOut: DateTime.Now.AddDays(16),
                price: 1500.00M
            );
            reservation.HasPaid = true; // Modyfikacja kluczowego pola
            return reservation;
        }

        // SCENARIUSZ 3: ANULOWANA rezerwacja
        public static Reservation CreateCanceledReservation()
        {
            var reservation = CreateWeekendStay(); // Używamy bazowego obiektu
            reservation.Status = "Canceled"; // Modyfikujemy tylko status
            return reservation;
        }
    }
}
