﻿#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("lang")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("many")]
        public async Task<IActionResult> GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            var result = await _languageService.GetAllAsync(parameters, ct).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("update")]
        public Language UpdateLanguage(Language lang, CancellationToken ct)
        {
            lang.Name += "[updated]";
            return lang;
        }
    }
}