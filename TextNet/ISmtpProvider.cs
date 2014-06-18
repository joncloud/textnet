using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    public interface ISmtpProvider
    {
        Task Send(string from, string to, string message);
    }
}
