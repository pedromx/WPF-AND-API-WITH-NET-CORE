using PROJECT.UI.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROJECT.UI.providers
{
    public interface ICustomProvider
    {
        Task<List<string>> GetOrderOptions();
        Task<string> GetOrderedText(TextOrder textOrder);
        Task<string> GetTextStatistics(string text);
    }
}