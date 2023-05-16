using System;
using System.Collections.Generic;

namespace BlogManagement.Models;

public partial class BlogPost
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? ContentBlogPost { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
