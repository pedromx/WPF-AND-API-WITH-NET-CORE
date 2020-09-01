using PROJECT.API.Utilities;
using System.Collections.Generic;

namespace PROJECT.API.Services
{
    public class OptionsService : IOptionsService
    {
        public List<string> GetOrderOptions()
        {
            return new List<string>
            {
                Constants.ALPHABETIC_ASC,
                Constants.ALPHABETIC_DESC,
                Constants.LENGHT_ASC
            };
        }
    }
}
