using System;
using System.Collections.ObjectModel;
using System.Windows;
using FunctionalVarietyTracker.Controls.Models.TemplateFactory;
using FunctionalVarietyTracker.Models.GameData;
using FunctionalVarietyTracker.Types;
using JetBrains.Annotations;

namespace FunctionalVarietyTracker.Controls.ViewModels
{
  internal class ContentSliderViewModel : PropertyChangedBase
  {
    private ObservableCollection<LevelModel> _levels;
    private int _slideValue;

    public ObservableCollection<LevelModel> Levels
    {
      get => _levels;
      set => SetValue(ref _levels, value);
    }

    public int SlideValue
    {
      get => _slideValue;
      set => SetValue(ref _slideValue, value);
    }

    public ItemTemplateSelector ItemTemplateSelector { get; }

    public ContentSliderViewModel()
    {
    }

    public ContentSliderViewModel([NotNull] ObservableCollection<LevelModel> levels)
    {
      if (levels is null)
      {
        throw new ArgumentNullException(nameof(levels));
      }

      _levels = levels;

      var factory = new ItemTemplateFactory();
      factory.Register(typeof(LevelModel), (DataTemplate) Application.Current.FindResource("EditCategory"));
      factory.Register(typeof(CategoryModel), (DataTemplate) Application.Current.FindResource("TrackCategory"));
      ItemTemplateSelector = new ItemTemplateSelector(factory);
    }
  }
}