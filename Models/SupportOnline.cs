using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookingHotel.Models
{
    public partial class SupportOnline
    {
        public SupportOnline() { Time = DateTime.Now; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên là bắt buộc")]
        [Display(Name = "Tên")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Tin nhắn là bắt buộc")]
        [Display(Name = "Tin nhắn")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string? Email { get; set; }
        public DateTime? Time { get; set; }
    }
}
