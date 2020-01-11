using System.Collections.ObjectModel;
using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  [AutoDependency(false)]
  internal class GameDataModel : PropertyChangedBase, IGameDataModel
  {
    private GameCategoryModel _gameModel;
    private ObservableCollection<LevelModel> _levelModels;

    public ObservableCollection<LevelModel> LevelModels
    {
      get => _levelModels;
      set => SetValue(ref _levelModels, value);
    }

    public GameCategoryModel GameModel
    {
      get => _gameModel;
      set => SetValue(ref _gameModel, value);
    }

    public GameDataModel(GameCategoryModel gameModel, ObservableCollection<LevelModel> levelModels)
    {
      GameModel = gameModel;
      LevelModels = levelModels;
    }
  }
}