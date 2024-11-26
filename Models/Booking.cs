using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookingHotel.Models
{
    public partial class Booking
    {
        public Booking() { BookingTimeCreate = DateTime.Now.Date; }
        public int BookingId { get; set; }
        [Required(ErrorMessage = "Tên khách hàng là bắt buộc")]
        [Display(Name = "Tên khách hàng")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Email khách hàng là bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        [Display(Name = "Email khách hàng")]
        public string? CustomerEmail { get; set; }

        [Required(ErrorMessage = "Số điện thoại khách hàng là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại khách hàng")]
        public string? CustomerPhone { get; set; }
        public DateTime? BookingTimeCreate { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
        public double? BookingTotalMoney { get; set; }
        public int? RoomId { get; set; }
        public int? PaymentId { get; set; }
        public int? StatusId { get; set; }

        public virtual Payment? Payment { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Status? Status { get; set; }
    }
}
