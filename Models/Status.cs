using System;
using System.Collections.Generic;

namespace BookingHotel.Models
{
    public partial class Status
    {
        public Status()
        {
            Bookings = new HashSet<Booking>();
        }

        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
