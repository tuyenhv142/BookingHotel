using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            RoomTimeCreate = DateTime.Now;
        }

        public int RoomId { get; set; }
        [Required(ErrorMessage = "Tên phòng là bắt buộc")]
        [Display(Name = "Tên phòng")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "Kích thước phòng là bắt buộc")]
        [Display(Name = "Kích thước phòng")]
        public string? RoomSize { get; set; }

        [Required(ErrorMessage = "Thông tin giường là bắt buộc")]
        [Display(Name = "Thông tin giường")]
        public string? RoomBed { get; set; }
        public string? RoomPerson { get; set; }

        [Required(ErrorMessage = "Tiện nghi phòng là bắt buộc")]
        [Display(Name = "Tiện nghi phòng")]
        public string? RoomUtilities { get; set; }

        [Display(Name = "Dịch vụ đi kèm")]
        public string? RoomService { get; set; }

        [Required(ErrorMessage = "Giá phòng là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Giá phòng phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá phòng")]
        public int? RoomPrice { get; set; }

        public string? RoomImage { get; set; }

        public string? RoomMoreImage { get; set; }
        [Display(Name = "Thời gian tạo")]
        public DateTime? RoomTimeCreate { get; set; }
        public bool? RoomStatus { get; set; }

        public int? HotelId { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
