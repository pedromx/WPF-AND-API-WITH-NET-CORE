using PROJECT.API.Services;
using PROJECT.API.Utilities;
using Xunit;

namespace PROJECT.xUnitTest
{
    public class TextProcessServiceUnitTest
    {
        private readonly TextProcessService _textProcessService;
        public TextProcessServiceUnitTest()
        {
            _textProcessService = new TextProcessService();
        }

        [Theory]
        [InlineData("", "", "Invalid Selected Option")]
        [InlineData(Constants.ALPHABETIC_ASC, "Hi Peter", "Hi Peter")]
        [InlineData(Constants.ALPHABETIC_ASC, "Peter Hi", "Hi Peter")]
        [InlineData(Constants.ALPHABETIC_ASC, ".ç+´ç.ç+ Peter Hi", ".ç+´ç.ç+ Hi Peter")]

        [InlineData(Constants.ALPHABETIC_DESC, "Hi Peter", "Peter Hi")]
        [InlineData(Constants.ALPHABETIC_DESC, ".ç+´ç.ç+ Peter Hi", "Peter Hi .ç+´ç.ç+")]

        [InlineData(Constants.LENGHT_ASC, "a asdasd asd as asdasdasd", "a as asd asdasd asdasdasd")]
        [InlineData(Constants.LENGHT_ASC, ".ç+´ç.+´.´ç+ 1 123 23 454545", "1 23 123 454545 .ç+´ç.+´.´ç+")]
        public void GetTextStatisticsTest(string option, string value, string res)
        {
            var result = _textProcessService.GetOrderedText(option, value);

            Assert.Equal(result, res);
        }
    }
}
