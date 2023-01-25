namespace Lumos.Models.GeneralModels
{
  public class SeoDataModel
  {
    public int Id { get; set; }
    public byte? Type { get; set; }
    public List<SeoInnerModel>? SeoLanguageList { get; set; }
  }

  public class SeoInnerModel
  {
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Keywords { get; set; }
  }
}
