namespace ObjectMother_sample
{
    public class ReservationService
    {
        public bool CanCheckIn(Reservation reservation)
        {
            if (reservation.Status != "Confirmed")
            {
                return false;
            }

            if (reservation.CheckInDate.Date > DateTime.Now.Date)
            {
                return false;
            }

            return true;
        }
    }
}
