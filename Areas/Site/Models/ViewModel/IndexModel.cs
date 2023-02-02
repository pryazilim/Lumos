namespace Lumos.Areas.Site.Models.ViewModel
{
    public class IndexModel : BaseModel.LayoutModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<GeneralModels.SliderModel> SliderList { get; set; }
        public GeneralModels.SliderModel SliderMain { get; set; }
        public List<GeneralModels.ServicesModel> ServicesList { get; set; }
        public GeneralModels.ServicesModel ServicesMain { get; set; }
        public List<GeneralModels.AddressModel> AddressList { get; set; }
    }
}
