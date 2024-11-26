using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookingHotel.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
            HotelTimeCreate = DateTime.Now;
        }

        public int HotelId { get; set; }
        [Required(ErrorMessage = "Tên khách sạn là bắt buộc")]
        [Display(Name = "Tên khách sạn")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "Địa chỉ khách sạn là bắt buộc")]
        [Display(Name = "Địa chỉ khách sạn")]
        public string? HotelAddress { get; set; }

        [Required(ErrorMessage = "Giá khách sạn là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá khách sạn phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá khách sạn")]
        public int? HotelPrice { get; set; }

        public string? HotelImage { get; set; }

        public string? HotelMoreImage { get; set; }

        public string? HotelDescription { get; set; }
        public string? HotelPhone { get; set; }

        public string? HotelType { get; set; }
        public DateTime? HotelTimeCreate { get; set; }

        public bool? HotelFlag { get; set; }
        public string? HotelArea { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
