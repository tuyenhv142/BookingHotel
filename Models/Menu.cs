using System;
using System.Collections.Generic;

namespace BookingHotel.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? DisplayOrder { get; set; }
        public string? Target { get; set; }
        public bool? Status { get; set; }
    }
}
