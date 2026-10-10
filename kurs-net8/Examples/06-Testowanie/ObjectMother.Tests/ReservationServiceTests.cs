using ObjectMother_sample;

namespace ObjectMother.Tests_sample
{
    public class ReservationServiceTests
    {
        [Fact]
        public void ShouldAllowCheckIn_ForConfirmedReservation()
        {
            // ARRANGE
            var confirmedReservation = ReservationMother.CreateReadyForCheckIn();
            var service = new ReservationService();

            // ACT
            var result = service.CanCheckIn(confirmedReservation);

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public void ShouldNotAllowCheckIn_ForCanceledReservation()
        {
            // ARRANGE
            var canceledReservation = ReservationMother.CreateCanceledReservation();
            var service = new ReservationService();

            // ACT
            var result = service.CanCheckIn(canceledReservation);

            // ASSERT
            Assert.False(result);
        }
    }
}
