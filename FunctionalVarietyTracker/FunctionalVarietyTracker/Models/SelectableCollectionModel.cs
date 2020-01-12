using System.Collections.ObjectModel;
using System.Linq;
using FunctionalVarietyTracker.Types;

namespace FunctionalVarietyTracker.Models
{
  internal class SelectableCollectionModel<T> : PropertyChangedBase
  {
    private ObservableCollection<T> _data;
    private T _selectedItem;

    public ObservableCollection<T> Data
    {
      get => _data;
      set
      {
        SetValue(ref _data, value);
        OnPropertyChanged(nameof(SelectedItem));
      }
    }

    public T SelectedItem
    {
      get => _selectedItem;
      set => SetValue(ref _selectedItem, value);
    }

    public SelectableCollectionModel() : this(null)
    {
    }

    public SelectableCollectionModel(ObservableCollection<T> data = null)
    {
      Data = data ?? new ObservableCollection<T>();
      SelectedItem = Data.FirstOrDefault();
    }

    public void AddItem(T item)
    {
      Data.Add(item);
    }

    public void RemoveItem(T item)
    {
      Data.Remove(item);
    }
  }
}