using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericHostConsoleApp.Interfaces
{
    public interface IWeatherService
    {
         Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync();
    }
}