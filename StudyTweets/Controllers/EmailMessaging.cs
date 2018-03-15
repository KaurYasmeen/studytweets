using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudyTweets.Controllers
{
    public class EmailMessaging
    {
        public static void SendEmail(string Emaild)
        {
            Execute(Emaild).Wait();
        }

        static async Task Execute(string emailid)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("noreply@test.com", "StudyTweets Team");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(emailid, "End User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    
}
}
