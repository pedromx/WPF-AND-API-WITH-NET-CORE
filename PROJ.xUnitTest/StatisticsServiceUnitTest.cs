using PROJECT.API.Services;
using Xunit;

namespace PROJECT.xUnitTest
{
    public class StatisticsServiceUnitTest
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsServiceUnitTest()
        {
            _statisticsService = new StatisticsService();
        }

        [Theory]
        [InlineData("Hi, My name is Peter, Sorry if you are not prepare for this.He says - I'm the best.", 1, 17, 18)]
        [InlineData(" Hi u  ", 0, 4, 1)]        
        [InlineData(" -  ", 1, 3, 0)]
        [InlineData("dasdas'", 0, 0, 1)]
        [InlineData(",.´+,´+.´.+,´.+,´,", 0, 0, 0)]
        public void GetTextStatisticsTest(string value, int hypens, int spaces, int words)
        {

            var result = _statisticsService.GetTextStatistics(value);

            Assert.Equal(result.HyphenQuantity, hypens);
            Assert.Equal(result.SpacesQuantity, spaces);
            Assert.Equal(result.WordsQuantity, words);
        }
    }
}
