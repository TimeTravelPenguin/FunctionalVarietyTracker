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

    public GameDataModel() : this(string.Empty)
    {
    }

    public GameDataModel(string gameName = "", SelectableCollectionModel<CategoryModel> categoryModels = null)
    {
      GameName = gameName;
      Categories = categoryModels ?? new SelectableCollectionModel<CategoryModel>();
    }
  }
}