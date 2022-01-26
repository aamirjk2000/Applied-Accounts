using System.Collections.Generic;
using System.Text;
using MailKit.Net.Pop3;
using MimeKit;

namespace Applied_Accounts.Classes
{
    public class AppliedEmail
    {
        public StringBuilder EmailsReceived = new StringBuilder();

        public AppliedEmail()
        {

        }

        public List<MimeMessage> ReceiveEmail(int maxCount = 100)
        {
            List< MimeMessage> emails = new List<MimeMessage> ();

            using (var emailClient = new Pop3Client())
            {
                emailClient.Connect("jahangir.com");
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2"); 
                emailClient.Authenticate("aamir@jahangir.com", "(Ramla1056*)");

                for (int i = 0; i < emailClient.Count && i < maxCount; i++)
                {
                    var message = emailClient.GetMessage(i);
                    var emailMessage = new MimeMessage();
                    emails.Add(message);
                }
                return emails;
            }
        }
    }
}
