using System.Windows.Controls;

using FunctionalVarietyTracker.WPF.Contracts.Views;

using MahApps.Metro.Controls;

namespace FunctionalVarietyTracker.WPF.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();
    }
}
