using PROJECT.API.DTOs;
using PROJECT.API.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace PROJECT.API.Services
{
    public class StatisticsService : IStatisticsService
    {
        public StatisticsDTO GetTextStatistics(string text)
        {
            var wordsQuantity = GetWordsQuantity(text);

            return new StatisticsDTO
            {
                HyphenQuantity = text.QuantityOf('-'),
                WordsQuantity = wordsQuantity,
                SpacesQuantity = text.Count(char.IsWhiteSpace)
            };
        }

        private int GetWordsQuantity(string text)
        {
            var quantity = Regex.Matches(text, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase).Count;
            return quantity;
        }
    }
}
