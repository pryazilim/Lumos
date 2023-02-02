namespace Lumos.Areas.Site.Models.GeneralModels
{
  public class SliderModel
  {
    public int Id { get; set; }
    public int? Type { get; set; }
    public string PhotoPath { get; set; }
    public string SecondPhoto { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? OrderBy { get; set; }
    public SliderInnerModel SliderLanguageList { get; set; }

  }
  public class SliderInnerModel
  {
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string Title { get; set; }
    public string UnderTitle { get; set; }
    public string ButtonTitle { get; set; }
    public string ButtonUrl { get; set; }
  }
}
