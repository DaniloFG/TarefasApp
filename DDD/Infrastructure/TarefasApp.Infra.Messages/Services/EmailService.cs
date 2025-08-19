using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using TarefasApp.Infra.Messages.Models;
using TarefasApp.Infra.Messages.Settings;

namespace TarefasApp.Infra.Messages.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task SendMailAsync(EmailMessageModel model)
        {
            // Obtém o diretório onde o executável está localizado
            string pastaDoExecutavel = AppDomain.CurrentDomain.BaseDirectory;

            // Define o nome do arquivo
            string nomeDoArquivo = "registro_data_hora.txt";

            // Monta o caminho completo do arquivo
            string caminhoCompleto = Path.Combine(pastaDoExecutavel, nomeDoArquivo);

            // Conteúdo a ser gravado: data e hora atual
            string conteudo = model.Body;

            // Grava o conteúdo no arquivo (sobrescreve se já existir)
            await File.AppendAllTextAsync(caminhoCompleto, conteudo + Environment.NewLine);

            Console.WriteLine($"Arquivo gravado em: {caminhoCompleto}");

            // var mailMessage = new MailMessage(_emailSettings.Email, model.To)
            // {
            //     Subject = model.Subject,
            //     Body = model.Body
            // };

            // var smtpClient = new SmtpClient(_emailSettings.Smtp, _emailSettings.Port)
            // {
            //     EnableSsl = true,
            //     Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)

            // };

            // smtpClient.Send(mailMessage);

            // var message = new MimeMessage();
            // message.From.Add(MailboxAddress.Parse(_emailSettings.Email));
            // message.To.Add(MailboxAddress.Parse(model.To));
            // message.Subject = model.Subject;
            // message.Body = new TextPart("plain")
            // {
            //     Text = model.Body
            // };

            // using var smtp = new SmtpClient();
            // await smtp.ConnectAsync(_emailSettings.Smtp, _emailSettings.Port, SecureSocketOptions.StartTls);
            // await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
            // await smtp.SendAsync(message);
            // await smtp.DisconnectAsync(true);
        }
    }
}