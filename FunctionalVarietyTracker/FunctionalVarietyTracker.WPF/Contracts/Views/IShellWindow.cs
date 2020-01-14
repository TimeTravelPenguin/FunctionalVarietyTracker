using System.Windows.Controls;

namespace FunctionalVarietyTracker.WPF.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();
    }
}
