using System.Collections.Generic;
using System.Threading.Tasks;

using FunctionalVarietyTracker.WPF.Core.Models;

namespace FunctionalVarietyTracker.WPF.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
