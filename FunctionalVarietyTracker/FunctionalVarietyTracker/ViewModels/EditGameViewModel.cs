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
      GameData.Categories.AddItem(new CategoryModel("My category 01"));
      GameData.Categories.AddItem(new CategoryModel("My category 02"));
      GameData.Categories.AddItem(new CategoryModel("My category 03"));
    }
  }
}