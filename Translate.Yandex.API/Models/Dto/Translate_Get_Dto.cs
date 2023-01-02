namespace Translate.Yandex.API.Models.Dto
{
    public class Translate_Get_Dto
    {
        public string Text { get; set; }
        public string Lang { get; set; }
        
        public TranslateConnector DtoToEntity(string text, string language)
        {
            return new TranslateConnector()
            {
                Text = text,
                Lang = language,
            };
        }
    }

    public class Translate_Get_Return_Dto
    {
        public int Code { get; set; }
        public string Lang { get; set; }
        public string Translated_Text { get; set; }
    }
}
