using System.Windows.Controls;

using FunctionalVarietyTracker.WPF.Contracts.Views;
using FunctionalVarietyTracker.WPF.ViewModels;

using MahApps.Metro.Controls;

namespace FunctionalVarietyTracker.WPF.Views
{
    public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
    {
        public ShellDialogWindow(ShellDialogViewModel viewModel)
        {
            InitializeComponent();
            viewModel.SetResult = OnSetResult;
            DataContext = viewModel;
        }

        public Frame GetDialogFrame()
            => dialogFrame;

        private void OnSetResult(bool? result)
        {
            DialogResult = result;
            Close();
        }
    }
}
