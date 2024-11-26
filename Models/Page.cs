using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public partial class Page
    {
        public Page() { Time = DateTime.Now; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên trang là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tên trang không được vượt quá 200 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Nội dung trang là bắt buộc")]
        public string? Content { get; set; }

        [StringLength(100, ErrorMessage = "Tiêu đề 1 không được vượt quá 100 ký tự")]
        public string? Title1 { get; set; }

        public string? Content1 { get; set; }

        [StringLength(100, ErrorMessage = "Tiêu đề 2 không được vượt quá 100 ký tự")]
        public string? Title2 { get; set; }

        public string? Content2 { get; set; }

        [StringLength(100, ErrorMessage = "Tiêu đề 3 không được vượt quá 100 ký tự")]
        public string? Title3 { get; set; }

        public string? Content3 { get; set; }

        public string? Image { get; set; }

        public string? ImageMore { get; set; }
        public DateTime? Time { get; set; }

        [StringLength(50, ErrorMessage = "Tác giả không được vượt quá 50 ký tự")]
        public string? Author { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? Status { get; set; }
    }
}
