using CISS411.Models.DomainModels;
using System.Net.Mail;

namespace CISS411.Models.Miscellaneous
{
    public static class Emailer
    {
        public static void EmailParties(Book book, Member user)
        {
            EmailUser(book, user);
            EmailAdmin(book, user);
        }

        private static void EmailAdmin(Book book, Member user)
        {
            string message = $"{user.FirstName} {user.LastName} has checked out";
            message += $"{book.Title}. ";
            message += $"Their email address is {user.Email}.";

            Email email = new Email
            {
                Body = message,
                Subject = "Someone checked out a book.",
                To = "xwu2@cougars.ccis.edu", //TODO add static class to retrieve from appsettings
                From = "tech@entrepreneurship.com"
            };
            
            SendEmail(email);

        }

        private static void EmailUser(Book book, Member user)
        {
            string message = $"Hello, {user.FirstName}, this email is verification has checked out";
            message += $"{book.Title}. ";
            message += $"Their email address is {user.Email}.";
        }

        private static void SendEmail(Email email)
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("tech@entrepreneurship.com"),
                Subject = email.Subject,
                Body = email.Body,
            };
            mailMessage.To.Add(email.To);
            client.Send(mailMessage);
        }
    }
}









