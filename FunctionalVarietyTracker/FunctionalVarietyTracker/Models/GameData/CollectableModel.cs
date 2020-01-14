using System.Drawing;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal class CollectableModel : PropertyChangedBase
  {
    private Image _image;
    private bool _isCollected;
    private string _name;

    public string Name
    {
      get => _name;
      set => SetValue(ref _name, value);
    }

    public bool IsCollected
    {
      get => _isCollected;
      set => SetValue(ref _isCollected, value);
    }

    public Image Image
    {
      get => _image;
      set => SetValue(ref _image, value);
    }

    public CollectableModel(string name, bool isCollected = false, Image image = null)
    {
      _name = name;
      _isCollected = isCollected;
      _image = image;
    }
  }
}