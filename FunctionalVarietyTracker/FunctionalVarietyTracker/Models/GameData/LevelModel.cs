using System.Collections.ObjectModel;
using System.Drawing;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal class LevelModel : PropertyChangedBase
  {
    private ObservableCollection<CollectableModel> _collectables;
    private Image _image;
    private string _levelName;

    public Image Image
    {
      get => _image;
      set => SetValue(ref _image, value);
    }

    public string LevelName
    {
      get => _levelName;
      set => SetValue(ref _levelName, value);
    }

    public ObservableCollection<CollectableModel> Collectables
    {
      get => _collectables;
      set => SetValue(ref _collectables, value);
    }

    public LevelModel(string levelName, ObservableCollection<CollectableModel> collectables = null, Image image = null)
    {
      _levelName = levelName;
      _collectables = collectables ?? new ObservableCollection<CollectableModel>();
      _image = image;
    }
  }
}