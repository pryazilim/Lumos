namespace Lumos.Areas.Site.Models.GeneralModels
{
   public class AddressModel
  {
    public int Id { get; set; }
    public int? OrderBy { get; set; }
    public string Address { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public AddressInnerModel AddresLanguageList { get; set; }
  }
  public class AddressInnerModel
  {
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string Title { get; set; }
    public string Map { get; set; }
    public string Mail { get; set; }
    public string Fax { get; set; }
    public string Phone { get; set; }
  }
}
