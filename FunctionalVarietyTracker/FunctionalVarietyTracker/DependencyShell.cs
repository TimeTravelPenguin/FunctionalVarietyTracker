using System;
using FunctionalVarietyTracker.AutoDependencies;

namespace FunctionalVarietyTracker
{
  internal static class DependencyShell
  {
    public static IAutoDependency BuildDependencies()
    {
      var autoDependency = AutoDependency.Instance;

      var assemblies = AppDomain.CurrentDomain.GetAssemblies();
      autoDependency.RegisterAutoDependencies(assemblies);

      autoDependency.BuildContainer();
      return autoDependency;
    }
  }
}