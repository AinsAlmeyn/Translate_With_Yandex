using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using Translate.Yandex.API.Models;
using Translate.Yandex.API.Models.Dto;

namespace Translate.Yandex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        public Configuration configuration;
        public TranslateController(Configuration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("Translate")]
        public async Task<IActionResult> langToLang(Translate_Get_Dto translate_Get)
        {
            TranslateConnector translateConnector = new();
            Translate_Get_Return_Dto value = await translateConnector.YandexTranslate(translate_Get, configuration.GetSection("ApiKey").ToString());
            return Ok(value);
        }
    }
}
