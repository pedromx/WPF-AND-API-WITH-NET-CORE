namespace PROJECT.API.Services
{
    public interface ITextProcessService
    {
        public string GetOrderedText(string selectedOption, string textToProcess);
    }
}