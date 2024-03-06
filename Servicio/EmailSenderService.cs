using MimeKit;
using Servicio.IServicio;
using Utilidades;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace Servicio
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        public EmailSenderService(IConfiguration config)
        {
            _config = config;
        }

        //metodo para enviar correo electronico
        public void SendEmail(MailRequest request)
        {
            var email = new MimeMessage();

            //parametros from -> de donde viene
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
            //add request que se pasa en el parametro
            email.To.Add(MailboxAddress.Parse(request.Email));
            //subject titulo del correo
            email.Subject = request.Subject;
            //body contenido del correo
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _config.GetSection("Email:Server").Value,
                Convert.ToInt32(_config.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );

            smtp.Authenticate(_config.GetSection("Email:UserName").Value,
                _config.GetSection("Email:Password").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

        }

    }
}
