using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTR.Services
{
    public interface IMailService
    {
        void Send(string to, string subject, string body, object attachment = null);
    }
}
