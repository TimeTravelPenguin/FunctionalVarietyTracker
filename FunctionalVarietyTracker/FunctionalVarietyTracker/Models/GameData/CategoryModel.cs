using System.Collections.ObjectModel;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal class CategoryModel : PropertyChangedBase
  {
    private string _category;
    private SelectableCollectionModel<LevelModel> _levels;

    public string Category
    {
      get => _category;
      set => SetValue(ref _category, value);
    }

    public SelectableCollectionModel<LevelModel> Levels
    {
      get => _levels;
      set => SetValue(ref _levels, value);
    }

    public CategoryModel():this(string.Empty, null)
    {
    }

    public CategoryModel(string category, SelectableCollectionModel<LevelModel> levels = null)
    {
      Category = category;
      Levels = levels ?? new SelectableCollectionModel<LevelModel>();
    }
  }
}