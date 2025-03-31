
//using Elfie.Serialization;
//using Newtonsoft.Json.Linq;

//namespace Clubmates.web.Services
//{
//    public class EmailServices(IConfiguration config) : IEmailServices
//    {
//        private readonly string apikey = config["Mailjet.ApiKey"]?? string.Empty;
//        private readonly string apiSecret = config["Mailjet.ApiSecret"]??string.Empty;
//        private readonly string from = config["Mailjet.From"]??string.Empty;
//        private readonly string fromName = config["Mailjet.FromName"]??string.Empty;


//        public Task<string> SendEmailAsync(string email, string subject, string htmlContent)
//        {
//            MailjetClient client = new(apikey, apiSecret);
//            MailjetRequest request = new()
//            {
//                Resource= Send.Resource,
//            }.Property(Send.FromEmail, from)
//             .Property(Send.FromName, fromName)
//             .Property(Send.Subject, subject)
//             .Property(Send.HtmlPart, htmlContent)
//             .Property(Send.Recipients, new JArray
//             {
//                 new JObject
//                 {
//                     {"Email",email }
//                 }
//             });
//        }
//    }
//}
