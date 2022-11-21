using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCStart.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "โปรดระบุชื่อ-นามสกุล")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "ชื่อ-นามสกุลต้องเป็นภาษาอังกฤษและไม่เกิน 40 ตัวอักษร")]
        [Display(Name = "ชื่อ-นามสกุล")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "โปรดระบุ Email")]
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "รูปแบบ Email ไม่ถูกต้อง")]
        [Remote("CheckEmail", "Home", ErrorMessage = "Email นี้ถูกใช้งานแล้ว")]
        [Display(Name = "อีเมล")]
        public string? Email { get; set; }

        [Range(0,100, ErrorMessage = "โปรดระบุอายุให้อยู่ในช่วง 1 ถึง 100")]
        [Display(Name = "อายุ")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "โปรดระบุรหัสผ่าน")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "รหัสผ่านจะต้องไม่เกิน 12 ตัวอักษรและต้องระบุอย่างน้อย 6 ตัวอักษร")]
        [Display(Name = "รหัสผ่าน")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "โปรดยืนยันรหัสผ่าน")]
        [Compare("Password", ErrorMessage = "โปรดยืนยันรหัสผ่านให้ถุกต้อง")]
        [Display(Name = "ยืนยันรหัสผ่าน")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "ที่อยู่")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }



    }
}
