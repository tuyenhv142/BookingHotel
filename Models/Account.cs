using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public partial class Account
    {
        public Account() { AccountTimeCreate = DateTime.Now; }
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Tên tài khoản là bắt buộc")]
        public string? AccountName { get; set; }

        [Required(ErrorMessage = "Email tài khoản là bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string? AccountEmail { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        //[StringLength(50, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        public string? AccountPassword { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string? AccountAddress { get; set; }

        public string? AccountPhone { get; set; }

        [StringLength(1000, ErrorMessage = "Phần giới thiệu không vượt quá 1000 ký tự")]
        public string? AccountAbout { get; set; }
        public DateTime? AccountTimeCreate { get; set; }
        public int? PositionId { get; set; }

        public virtual Position? Position { get; set; }
    }
}
