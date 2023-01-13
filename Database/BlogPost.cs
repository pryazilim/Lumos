public class BlogPost
{
  public int Id { get; set; }

  public string  Title { get; set; }

  public string Slug { get; set; }

  public string Summary { get; set; }

  public string Body { get; set; }

  public char BlogType { get; set; } // B: BlogPost, N: News, E: Example, D: Draft

  public DateTime CreatedOn { get; set; }
  public int CreatedBy { get; set; }

  public DateTime? DeletedOn { get; set; }
  public int? DeletedBy { get; set; }

  public DateTime? ModifiedOn { get; set; }
  public int? ModifiedBy { get; set; }

  public DateTime? PublishedOn { get; set; }
}
