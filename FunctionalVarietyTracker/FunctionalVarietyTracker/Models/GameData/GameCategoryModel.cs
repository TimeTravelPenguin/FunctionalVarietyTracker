using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  [AutoDependency(true)]
  internal class GameCategoryModel : PropertyChangedBase
  {
    private string _category;
    private string _gameName;

    public string GameName
    {
      get => _gameName;
      set => SetValue(ref _gameName, value);
    }

    public string Category
    {
      get => _category;
      set => SetValue(ref _category, value);
    }

    public GameCategoryModel(string gameName, string category)
    {
      GameName = gameName;
      Category = category;
    }
  }
}