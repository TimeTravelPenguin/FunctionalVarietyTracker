using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  [AutoDependency(true)]
  internal class LevelModel : PropertyChangedBase
  {
    private string _levelName;

    public string LevelName
    {
      get => _levelName;
      set => SetValue(ref _levelName, value);
    }
  }
}