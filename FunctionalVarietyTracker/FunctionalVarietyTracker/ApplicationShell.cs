using System;
using FunctionalVarietyTracker.AutoDependencies;
using FunctionalVarietyTracker.Properties;
using FunctionalVarietyTracker.ViewModels;
using FunctionalVarietyTracker.Views;

namespace FunctionalVarietyTracker
{
  internal class ApplicationShell
  {
    private static IAutoDependency _autoDependency;

    private ApplicationShell()
    {
      _autoDependency = DependencyShell.BuildDependencies();
    }

    public static ApplicationShell NewShell()
    {
      return new ApplicationShell();
    }

    public void Startup()
    {
      if (_autoDependency is null)
      {
        throw new InvalidOperationException(ExceptionResources.AutoDependency_NotInitialised);
      }

      var setup = new SetupWindow
      {
        DataContext = new SetupViewModel(_autoDependency)
      };

      setup.Show();
    }
  }
}