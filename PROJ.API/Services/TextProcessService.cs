using PROJECT.API.Utilities;
using System.Linq;

namespace PROJECT.API.Services
{
    public class TextProcessService : ITextProcessService
    {
        public string GetOrderedText(string selectedOption, string textToProcess)
        {
            switch (selectedOption)
            {
                case Constants.ALPHABETIC_ASC:
                    return GetAlphabeticAscText(textToProcess);

                case Constants.ALPHABETIC_DESC:
                    return GetAlphabeticDescText(textToProcess);

                case Constants.LENGHT_ASC:
                    return GetLenghtText(textToProcess);

                default:
                    return "Invalid Selected Option";
            }
        }

        private string GetLenghtText(string text)
        {
            var orderedStringArray = text.Split(' ').OrderBy(x => x.Length);
            return string.Join(' ', orderedStringArray);
        }

        private string GetAlphabeticAscText(string text)
        {
            var orderedStringArray = text.Split(' ').OrderBy(x => x);
            return string.Join(' ', orderedStringArray);
        }

        private string GetAlphabeticDescText(string text)
        {
            var orderedStringArray = text.Split(' ').OrderByDescending(x => x);
            return string.Join(' ', orderedStringArray);
        }
    }
}
