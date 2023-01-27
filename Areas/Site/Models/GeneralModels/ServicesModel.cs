namespace Lumos.Areas.Site.Models.GeneralModels
{
  public class ServicesModel
  {
    public int Id { get; set; }
    public int? Type { get; set; }
    public bool? IsFeatured { get; set; }
    public string PhotoPath { get; set; }
    public string PhotoPath2 { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? OrderBy { get; set; }
    public ServicesInnerModel ServicesLanguageList { get; set; }
  }
  public class ServicesInnerModel
  {
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
  }
}
