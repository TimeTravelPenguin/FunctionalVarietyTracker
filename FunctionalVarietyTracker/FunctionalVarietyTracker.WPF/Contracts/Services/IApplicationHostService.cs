using System.Threading.Tasks;

namespace FunctionalVarietyTracker.WPF.Contracts.Services
{
    public interface IApplicationHostService
    {
        Task StartAsync();

        Task StopAsync();
    }
}
