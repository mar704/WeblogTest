using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Models;

public partial class BlogPost
{
    public int Id { get; set; }

    [Display(Name = "عنوان پست")]

    public string? Title { get; set; }

    [Display(Name = " محتوای پست")]

    public string? ContentBlogPost { get; set; }

    public int? CategoryId { get; set; }

    [Display(Name = "برچسب")]

    public virtual Category? Category { get; set; }
}
