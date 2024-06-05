using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Application.MailService
{
    public interface IMailService
    {
        void SendMail(string FullName, string Email, string Subject, string Enquiry);
    }
}
