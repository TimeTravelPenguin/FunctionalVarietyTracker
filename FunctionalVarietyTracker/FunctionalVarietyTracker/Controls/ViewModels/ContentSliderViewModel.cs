using FunctionalVarietyTracker.Models;
using FunctionalVarietyTracker.Models.GameData;

namespace FunctionalVarietyTracker.Controls.ViewModels
{
  internal class ContentSliderViewModel
  {
    public SelectableCollectionModel<CategoryModel> Categories { get; }

    public ContentSliderViewModel() : this(null)
    {
    }

    public ContentSliderViewModel(SelectableCollectionModel<CategoryModel> categories)
    {
      Categories = categories ?? new SelectableCollectionModel<CategoryModel>();
    }
  }
}