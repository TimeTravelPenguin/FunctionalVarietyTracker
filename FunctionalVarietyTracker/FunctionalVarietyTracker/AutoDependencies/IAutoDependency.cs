using System;
using System.Reflection;

namespace FunctionalVarietyTracker.AutoDependencies
{
  internal interface IAutoDependency
  {
    bool IsRegistered(Type service);

    void RegisterInstance<TType>(TType instance) where TType : class;
    void RegisterAutoDependencies(params Assembly[] assemblies);
    void Register<TType>(bool asSelf, bool asSingleton);
    void Register<TInterface, TType>(bool asSingleton);
    void RegisterGeneric(Type implementerInterface, Type implementer, bool asSingleton);

    void RegisterTypeWithParameters<TType>(Type param1Type, object param1Value, Type param2Type, string param2Name,
      bool asSingleton)
      where TType : class;

    void RegisterTypeWithParameters<TInterface, TType>(Type param1Type, object param1Value, Type param2Type,
      string param2Name, bool asSingleton)
      where TInterface : class
      where TType : class, TInterface;

    TType Resolve<TType>();
    object Resolve(Type type);
    Lazy<TType> ResolveLazily<TType>();

    void BuildContainer();
  }
}