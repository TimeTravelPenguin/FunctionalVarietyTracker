using System;
using System.Collections.ObjectModel;
using FunctionalVarietyTracker.Models.GameData;
using FunctionalVarietyTracker.Types;
using JetBrains.Annotations;

namespace FunctionalVarietyTracker.ViewModels
{
  internal class EditGameViewModel : PropertyChangedBase
  {
    private IGameDataModel _gameData;

    public IGameDataModel GameData
    {
      get => _gameData;
      set => SetValue(ref _gameData, value);
    }

    public EditGameViewModel()
    {
    }

    public EditGameViewModel([NotNull] IGameDataModel gameData)
    {
      if (gameData is null)
      {
        throw new ArgumentNullException(nameof(gameData));
      }

      GameData = gameData;

      GameData.Categories.AddItem(new CategoryModel("My category 01",
        new ObservableCollection<LevelModel>
        {
          new LevelModel("Level 01"),
          new LevelModel("Level 02"),
          new LevelModel("Level 04")
        }));

      GameData.Categories.AddItem(new CategoryModel("My category 02",
        new ObservableCollection<LevelModel>
        {
          new LevelModel("Level 02")
        }));

      GameData.Categories.AddItem(new CategoryModel("My category 03",
        new ObservableCollection<LevelModel>
        {
          new LevelModel("Level 03")
        }));
    }
  }
}