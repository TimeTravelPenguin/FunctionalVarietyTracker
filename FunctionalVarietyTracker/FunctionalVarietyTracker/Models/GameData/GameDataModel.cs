using System.Collections.ObjectModel;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal class GameDataModel : PropertyChangedBase, IGameDataModel
  {
    private SelectableCollectionModel<CategoryModel> _categoryModels;
    private string _gameName;

    public string GameName
    {
      get => _gameName;
      set => SetValue(ref _gameName, value);
    }

    public SelectableCollectionModel<CategoryModel> Categories
    {
      get => _categoryModels;
      set => SetValue(ref _categoryModels, value);
    }

    public GameDataModel() : this("", null)
    {
    }

    public GameDataModel(string gameName, SelectableCollectionModel<CategoryModel> categoryModels)
    {
      GameName = gameName;
      Categories = categoryModels ?? new SelectableCollectionModel<CategoryModel>();
    }

    public static GameDataModel NewGame()
    {
      return new GameDataModel("<Game Name>", new SelectableCollectionModel<CategoryModel>(
        new ObservableCollection<CategoryModel>
        {
          new CategoryModel("<Category 01>",
            new ObservableCollection<LevelModel>
            {
              new LevelModel("<Level 01>", new ObservableCollection<CollectableModel>())
            })
        }));
    }
  }
}