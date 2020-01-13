using System.Collections.ObjectModel;
using FunctionalVarietyTracker.Models;
using FunctionalVarietyTracker.Models.GameData;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.ViewModels
{
  internal class EditGameViewModel : PropertyChangedBase
  {
    private IGameDataModel _gameData = new GameDataModel();

    public IGameDataModel GameData
    {
      get => _gameData;
      set => SetValue(ref _gameData, value);
    }

    public EditGameViewModel()
    {
      GameData.Categories.AddItem(new CategoryModel("My category 01")
      {
        Levels = new SelectableCollectionModel<LevelModel>
          {Data = new ObservableCollection<LevelModel> {new LevelModel("Level 01"), new LevelModel("Level 02"), new LevelModel("Level 04")}}
      });

      GameData.Categories.AddItem(new CategoryModel("My category 02")
      {
        Levels = new SelectableCollectionModel<LevelModel>
          {Data = new ObservableCollection<LevelModel> {new LevelModel("Level 02")}}
      });

      GameData.Categories.AddItem(new CategoryModel("My category 03")
      {
        Levels = new SelectableCollectionModel<LevelModel>
          {Data = new ObservableCollection<LevelModel> {new LevelModel("Level 03")}}
      });
    }
  }
}