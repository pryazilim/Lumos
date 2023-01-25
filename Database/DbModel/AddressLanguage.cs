public partial class AddressLanguage
{
  public int Id { get; set; }
  public Nullable<int> AddressId { get; set; }
  public Nullable<int> LanguageId { get; set; }
  public string Title { get; set; }
  public string Map { get; set; }
  public string Fax { get; set; }
  public string Phone { get; set; }
  public string Mail { get; set; }
}
