using System.Collections.ObjectModel;
using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Models.GameData;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.ViewModels
{
  internal class SetupViewModel : PropertyChangedBase
  {
    private static IAutoDependency _autoDependency;
    private ObservableCollection<IGameDataModel> _gameDataModels;

    public ObservableCollection<IGameDataModel> GameDataModels
    {
      get => _gameDataModels;
      set => SetValue(ref _gameDataModels, value);
    }
    
    public SetupViewModel(IAutoDependency autoDependency) : this()
    {
      _autoDependency = autoDependency;
    }

    public SetupViewModel()
    {
      // TODO : Find json files / game data for randomizer amd bingo
    }
  }
}