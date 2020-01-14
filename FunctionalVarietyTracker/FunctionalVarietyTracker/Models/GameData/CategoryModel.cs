using System.Collections.ObjectModel;
using FunctionalVarietyTracker.Controls.ViewModels;
using FunctionalVarietyTracker.Types;
using JetBrains.Annotations;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal class CategoryModel : PropertyChangedBase
  {
    private string _category;
    private ObservableCollection<LevelModel> _levels;
    private ContentSliderViewModel _sliderDataContext;

    public ContentSliderViewModel SliderDataContext
    {
      get => _sliderDataContext;
      set => SetValue(ref _sliderDataContext, value);
    }

    public string Category
    {
      get => _category;
      set => SetValue(ref _category, value);
    }

    public ObservableCollection<LevelModel> Levels
    {
      get => _levels;
      set => SetValue(ref _levels, value);
    }

    public CategoryModel()
    {
    }

    public CategoryModel(string category, [NotNull] ObservableCollection<LevelModel> levels)
    {
      Category = category;
      Levels = levels;

      SliderDataContext = new ContentSliderViewModel(Levels);
    }
  }
}