using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Emailer
{
    public static class Emailer
    {



        public static void SendEmail(string subject = "", string body = "", string[] to = null, string[] cc = null)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                string email = "donotreply@wolf-coin.us";
                string pass = "456456";

                message.From = new MailAddress(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                if (to != null)
                {
                    foreach (string recepient in to)
                    {
                        message.To.Add(recepient);
                    }
                }
                else
                {
                    throw new Exception("Invalid Email");
                }

                if (cc != null)
                {
                    foreach (string recepient in cc)
                    {
                        message.CC.Add(recepient);
                    }
                }

                smtp.Port = 587;
                smtp.Host = "mail.wolf-coin.us";
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(email, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                Console.WriteLine("Sent Email to " + to[0]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }




    }
}
