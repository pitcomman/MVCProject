using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCCoreEF.Models
{
    public partial class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "โปรดระบุชื่อนามสกุล")]
        [Display(Name = "ชื่อ-นามสกุล")]
        public string Name { get; set; } = null!;
        [Display(Name = "ที่อยู่")]
        public string? Address { get; set; }
    }
}
