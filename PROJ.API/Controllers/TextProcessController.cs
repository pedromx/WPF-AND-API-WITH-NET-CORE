using System.Collections.Generic;
using PROJECT.API.DTOs;
using PROJECT.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace PROJECT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextProcessController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ITextProcessService _textProcessService;
        private readonly IOptionsService _optionsService;

        public TextProcessController(ITextProcessService textProcessService, IOptionsService optionsService, IStatisticsService statisticsService)
        {
            _textProcessService = textProcessService;
            _optionsService = optionsService;
            _statisticsService = statisticsService;
        }

        /// <summary>
        /// Get options to order a text
        /// </summary>
        /// <returns>options</returns>
        [HttpGet]
        [Route("options")]
        public IEnumerable<string> GetOptions()
        {
            var options = _optionsService.GetOrderOptions();
            return options;
        }

        /// <summary>
        /// Order a text using options
        /// </summary>
        /// <param name="orderOption"></param>
        /// <param name="textToOrder"></param>
        /// <returns>ordered text </returns>
        [HttpGet]
        [Route("{textToOrder}/order/{orderOption}")]
        public string GetOrderedText([FromRoute] string orderOption, [FromRoute] string textToOrder)
        {
            var result = _textProcessService.GetOrderedText(orderOption, textToOrder);
            return result;
        }

        /// <summary>
        /// analize text to get statistics 
        /// </summary>
        /// <param name="textToAnalize"></param>
        /// <returns>text statistics</returns>
        [HttpGet]
        [Route("{textToAnalize}/statistics")]
        public StatisticsDTO GetTextStatistics([FromRoute] string textToAnalize)
        {
            var result = _statisticsService.GetTextStatistics(textToAnalize);
            return result;
        }
    }
}
