using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
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

      InitialiseWorkingDirectory();

      var setup = new SetupWindow
      {
        DataContext = new SetupViewModel(_autoDependency)
      };

      setup.Show();
    }

    private void InitialiseWorkingDirectory()
    {
      var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
      var subDir = Path.Combine(path ?? throw new NullReferenceException(ExceptionResources.FilePathNull), "GameData");

      // Check folder for loading data exists
      if (!Directory.Exists(subDir))
      {
        Directory.CreateDirectory(subDir);
      }

      // Check for files
      var files = Directory.GetFiles(subDir);

      // TODO: Process files and report non-working files
      if (files.Any(f => f.EndsWith(Resources.FileTypeExtension)))
      {
        return;
      }

      if (MessageBox.Show(
            Resources.NoFilesFound_Dialogue,
            Resources.NoFilesFound, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        Process.Start(Resources.GitHubRepo);
      }
    }
  }
}