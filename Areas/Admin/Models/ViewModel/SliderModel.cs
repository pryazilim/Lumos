using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lumos.Areas.Admin.Models.ViewModel
{
  public class SliderModel : BaseModel.LayoutModel
  {
    public List<GeneralModels.SliderModel>? SliderList { get; set; }
    public GeneralModels.SliderModel? SliderMain { get; set; }
  }
}
