using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace Servicio.IServicio
{
    public interface IEmailSenderService
    {
        void SendEmail(MailRequest request);

    }
}
