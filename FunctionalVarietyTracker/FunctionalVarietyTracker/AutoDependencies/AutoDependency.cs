using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace FunctionalVarietyTracker.AutoDependencies
{
  internal sealed class AutoDependency : IAutoDependency
  {
    public static readonly AutoDependency Instance = new AutoDependency();
    private readonly ContainerBuilder _builder = new ContainerBuilder();
    private IContainer _container;

    public bool IsRegistered(Type service)
    {
      return _container.IsRegistered(service);
    }

    public void RegisterInstance<TType>(TType instance) where TType : class
    {
      _builder.RegisterInstance(instance).As<TType>();
    }

    public void RegisterAutoDependencies(params Assembly[] assemblies)
    {
      foreach (var asSelf in new[] {true, false})
      {
        foreach (var asSingleton in new[] {true, false})
        {
          var builder = _builder
            .RegisterAssemblyTypes(assemblies)
            .Where(item => IsDependency(item, asSelf, asSingleton));

          builder = asSelf
            ? builder.AsSelf()
            : builder.AsImplementedInterfaces();

          if (asSingleton)
          {
            builder.SingleInstance();
          }
        }
      }
    }

    public void Register<TType>(bool asSelf, bool asSingleton)
    {
      var builder = _builder.RegisterType<TType>();

      if (asSelf)
      {
        builder.AsSelf();
      }
      else
      {
        builder.AsImplementedInterfaces();
      }

      if (asSingleton)
      {
        builder.SingleInstance();
      }
    }

    public void Register<TInterface, TType>(bool asSingleton)
    {
      var builder = _builder.RegisterType<TType>().As<TInterface>();

      if (asSingleton)
      {
        builder.SingleInstance();
      }
    }

    public void RegisterTypeWithParameters<TType>(Type param1Type, object param1Value, Type param2Type,
      string param2Name, bool asSingleton)
      where TType : class
    {
      var builder = _builder.RegisterType<TType>()
        .WithParameters(new List<Parameter>
        {
          new TypedParameter(param1Type, param1Value),
          new ResolvedParameter(
            (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
            (pi, ctx) => ctx.Resolve(param2Type))
        });

      if (asSingleton)
      {
        builder.SingleInstance();
      }
    }

    public void RegisterTypeWithParameters<TInterface, TType>(Type param1Type, object param1Value, Type param2Type,
      string param2Name, bool asSingleton)
      where TInterface : class
      where TType : class, TInterface
    {
      var builder = _builder.RegisterType<TType>()
        .WithParameters(new List<Parameter>
        {
          new TypedParameter(param1Type, param1Value),
          new ResolvedParameter(
            (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
            (pi, ctx) => ctx.Resolve(param2Type))
        }).As<TInterface>();

      if (asSingleton)
      {
        builder.SingleInstance();
      }
    }

    public TType Resolve<TType>()
    {
      return _container.Resolve<TType>();
    }

    public object Resolve(Type type)
    {
      return _container.Resolve(type);
    }

    public Lazy<TType> ResolveLazily<TType>()
    {
      return new Lazy<TType>(Resolve<TType>);
    }

    public void BuildContainer()
    {
      _container = _builder.Build();
    }

    public void RegisterGeneric(Type implementerInterface, Type implementer, bool asSingleton)
    {
      var builder = _builder.RegisterGeneric(implementer).As(implementerInterface);

      if (asSingleton)
      {
        builder.SingleInstance();
      }
    }

    private static bool IsDependency(MemberInfo memberInfo, bool registeredAsSelf, bool isSingleton)
    {
      var attribute = memberInfo.GetCustomAttribute<AutoDependencyAttribute>();

      return attribute?.RegisterAsSelf == registeredAsSelf && attribute.IsSingleton == isSingleton;
    }
  }
}