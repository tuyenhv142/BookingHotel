using System;
using System.Collections.Generic;

namespace BookingHotel.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Bookings = new HashSet<Booking>();
        }

        public int PaymentId { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentAmount { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
