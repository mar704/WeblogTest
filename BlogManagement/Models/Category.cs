using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models;

public partial class Category
{
    public int Id { get; set; }


    [Display(Name = "عنوان")]
    public string? CategoryName { get; set; }

    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
}
