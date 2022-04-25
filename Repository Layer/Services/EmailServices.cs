﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Repository_Layer.Services
{
    public class EmailServices
    {
        public static void SendMail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new NetworkCredential("temporaryfakemail97@gmail.com", "fake@123");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("temporaryfakemail97@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"Hi User,Find the below token \n \n www.FundooNotes.com/reset-password/{token}";
                client.Send(msgObj);
            }
        }
    }
}
