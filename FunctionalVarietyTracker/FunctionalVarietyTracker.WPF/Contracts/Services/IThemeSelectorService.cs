using FunctionalVarietyTracker.WPF.Models;

namespace FunctionalVarietyTracker.WPF.Contracts.Services
{
    public interface IThemeSelectorService
    {
        bool SetTheme(AppTheme? theme = null);

        AppTheme GetCurrentTheme();
    }
}
