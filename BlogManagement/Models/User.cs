using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "نام کاربری الزامیست")]
    [Display(Name = "نام کاربری")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "رمزعبور الزامیست")]
    [Display(Name = "رمزعبور")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
