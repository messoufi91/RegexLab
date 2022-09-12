using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegexLab.Model;
using RegexLab.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegexController : ControllerBase
    {
      

        public static string Path
        {
            get { return System.IO.Directory.GetCurrentDirectory()+@"\Json.txt"; }
        }

        private readonly ILogger<RegexController> _logger;
        private readonly IRegexService _regexService;

        public RegexController(ILogger<RegexController> logger, IRegexService regexService)
        {
            _logger = logger;
            _regexService = regexService;
        }

        [HttpGet("GetAll")]
        public List<RegexModel> GetAllRegex()
        {
            return _regexService.GetAllRegex() ;
        }

        [HttpGet("GetMatched")]
        public List<RegexModel> GetMatchedRegex()
        {
            return _regexService.GetAllRegex().Where(x => x.IsMatch == true).ToList();
        }

        [HttpPost("IsMatch")]
        public bool Post(string regx, string text)
        {
            if (string.IsNullOrEmpty(regx) && string.IsNullOrEmpty(text))
            {
                return false;
            }

            Regex validateRegex = new Regex(regx);
            bool result = validateRegex.IsMatch(text);

            _regexService.AddRegex(new RegexModel { Expression = text, Pattern = regx, IsMatch = result });

            return result;
        }

        [HttpPost("Matches")]
        public bool Matches(string regx, string text)
        {
            if (string.IsNullOrEmpty(regx) && string.IsNullOrEmpty(text))
            {
                return false;
            }
            bool result;
            Match match = Regex.Match(text, regx, RegexOptions.IgnoreCase);
            result = match.Success ? true : false;


            _regexService.AddRegex(new RegexModel { Expression = text, Pattern = regx, IsMatch = result });

            return result;
        }

    }
}
