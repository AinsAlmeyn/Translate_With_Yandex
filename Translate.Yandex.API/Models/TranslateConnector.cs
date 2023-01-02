using Newtonsoft.Json;
using System.Configuration;
using Translate.Yandex.API.Models.Dto;

namespace Translate.Yandex.API.Models
{
    public class TranslateConnector
    {
        public int Code { get; set; }
        public string Text { get; set; }
        public string Lang { get; set; }

        public async Task<Translate_Get_Return_Dto> YandexTranslate(Translate_Get_Dto translate_Get, string api_key)
        {
            try
            {
                TranslateConnector article = translate_Get.DtoToEntity(translate_Get.Text, translate_Get.Lang);
                string endpoint = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key={api_key}&text={article.Text}&lang={article.Lang}";
                HttpClient httpClient = new();
                HttpResponseMessage responseMessage = await httpClient.GetAsync(endpoint);
                string new_Article = await responseMessage.Content.ReadAsStringAsync();
                TranslateConnector result_Article = JsonConvert.DeserializeObject<TranslateConnector>(new_Article);
                return new Translate_Get_Return_Dto
                {
                    Code = result_Article.Code,
                    Lang = result_Article.Lang,
                    Translated_Text = result_Article.Text,
                };
            }
            catch (Exception e)
            {
                return new Translate_Get_Return_Dto
                {
                    Code = 400
                };
            }
        }
    }
}
