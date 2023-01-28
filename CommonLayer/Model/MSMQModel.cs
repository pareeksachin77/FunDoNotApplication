using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MSMQModel
    {
        MessageQueue mq = new MessageQueue();
        public void sendData2Queue(string token)
        {
            mq.Path = @".\private$\FunDoNote";
            if(!MessageQueue.Exists(mq.Path))
            {
                MessageQueue.Create(mq.Path);
            }
            
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            mq.ReceiveCompleted += Mq_ReceiveCompleted;
            mq.Send(token);
            mq.BeginReceive();
            mq.Close();
        }

        private void Mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e) //event
        {
            var message = mq.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            string subject = "Test Message";
            string body = $"Fundoo Notes Reset Password: <a href=http://localhost:4200/resetPassword/{token}> Click Here</a>";
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("work.sachin45@gmail.com", "yflciqlhfqngmbmg"),
                EnableSsl = true,

            };
            smtp.Send("work.sachin45@gmail.com", "work.sachin45@gmail.com", subject, body);
            mq.BeginReceive();

        }
    }
}
