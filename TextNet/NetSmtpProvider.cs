using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    class NetSmtpProvider : ISmtpProvider
    {
        async public Task Send(string from, string to, string message)
        {
            using (var client = new SmtpClient())
            {
                await client.SendMailAsync(from, to, "", message);
            }
        }
    }
}
