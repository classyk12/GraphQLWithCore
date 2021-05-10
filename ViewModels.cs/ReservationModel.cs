using System;
namespace graphql.viewmodels
{
    public class ReservationModel
    {
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

    }   
}