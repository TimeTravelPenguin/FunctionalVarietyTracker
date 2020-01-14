using System.Collections.ObjectModel;
using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Models;
using FunctionalVarietyTracker.Models.GameData;
using FunctionalVarietyTracker.Types;
using FunctionalVarietyTracker.Views;
using Microsoft.Expression.Interactivity.Core;

namespace FunctionalVarietyTracker.ViewModels
{
  internal class SetupViewModel : PropertyChangedBase
  {
    private static IAutoDependency _autoDependency;
    private SelectableCollectionModel<IGameDataModel> _gameCollectionFromFiles;
    private ObservableCollection<IGameDataModel> _gameDataModels;

    public ActionCommand CommandCreateNew { get; }

    public SelectableCollectionModel<IGameDataModel> GameCollectionFromFiles
    {
      get => _gameCollectionFromFiles;
      set => SetValue(ref _gameCollectionFromFiles, value);
    }

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
      CommandCreateNew = new ActionCommand(CreateNewGameData);
    }

    private static void CreateNewGameData()
    {
      var view = new EditGameView
      {
        DataContext = new EditGameViewModel(GameDataModel.NewGame())
      };

      view.ShowDialog();
    }
  }
}