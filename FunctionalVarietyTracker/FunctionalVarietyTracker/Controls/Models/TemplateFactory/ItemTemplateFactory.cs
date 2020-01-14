using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FunctionalVarietyTracker.Properties;

namespace FunctionalVarietyTracker.Controls.Models.TemplateFactory
{
  internal class ItemTemplateFactory : DataTemplateSelector
  {
    private readonly IDictionary<Type, DataTemplate> _registry;

    public ItemTemplateFactory()
    {
      _registry = new Dictionary<Type, DataTemplate>();
    }

    public void Register(Type type, DataTemplate template)
    {
      if (_registry.ContainsKey(type))
      {
        throw new ArgumentException(ExceptionResources.Factory_KeyAlreadyRegistered, nameof(type));
      }

      _registry.Add(type, template);
    }

    public DataTemplate Create(Type type)
    {
      return _registry.ContainsKey(type) ? _registry[type] : throw new ArgumentException(ExceptionResources.Factory_KeyNotExist, nameof(type));
    }
  }
}