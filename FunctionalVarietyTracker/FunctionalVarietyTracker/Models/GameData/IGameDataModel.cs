#region Title Header

// Name: Phillip Smith
// 
// Solution: FunctionalVarietyTracker
// Project: FunctionalVarietyTracker
// File Name: IGameDataModel.cs
// 
// Current Data:
// 2020-01-11 7:42 PM
// 
// Creation Date:
// -- 

#endregion

using System.Collections.ObjectModel;

namespace FunctionalVarietyTracker.Models.GameData
{
  internal interface IGameDataModel
  {
    string GameName { get; set; }
    SelectableCollectionModel<CategoryModel> Categories { get; set; }
  }
}