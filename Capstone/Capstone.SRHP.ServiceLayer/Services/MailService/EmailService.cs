using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Capstone.HPTY.ServiceLayer.Services.MailService
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class EmailService : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;
        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                message.To.Add(new MailAddress(email));

                using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    client.EnableSsl = _emailSettings.EnableSsl;
                    client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                    await client.SendMailAsync(message);
                }

                _logger.LogInformation($"Email sent successfully to {email}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email to {email}");
                throw;
            }
        }

        public async Task SendPasswordEmailAsync(string email, string name, string password)
        {
            string subject = "Your Account Password";
            string message = GetPasswordEmailTemplate(name, password);

            await SendEmailAsync(email, subject, message);
        }

        private string GetPasswordEmailTemplate(string name, string password)
        {
            return $@"
    <html>
    <head>
        <style>
            body {{ font-family: Arial, sans-serif; line-height: 1.6; }}
            .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
            .header {{ background-color: #f8f9fa; padding: 20px; text-align: center; }}
            .content {{ padding: 20px; }}
            .footer {{ text-align: center; margin-top: 20px; font-size: 12px; color: #6c757d; }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h2>Mật Khẩu Tài Khoản Của Bạn</h2>
            </div>
            <div class='content'>
                <p>Xin chào {name},</p>
                <p>Tài khoản của bạn đã được tạo thành công. Vì bạn đã đăng ký bằng Google, chúng tôi đã tạo một mật khẩu ngẫu nhiên cho tài khoản của bạn:</p>
                <p style='font-weight: bold; font-size: 16px; background-color: #f8f9fa; padding: 10px; text-align: center;'>{password}</p>
                <p>Để có thể sử dụng mật khẩu này bạn cần phải vô bổ sung đố điện thoại để có thể đăng nhập trực tiếp mà không cần sử dụng Google.</p>
                <p>Vì lý do bảo mật, chúng tôi khuyên bạn nên đổi mật khẩu này sau lần đăng nhập đầu tiên.</p>
                <p>Cảm ơn bạn đã tham gia cùng chúng tôi!</p>
            </div>
            <div class='footer'>
                <p>Đây là email tự động, vui lòng không trả lời email này.</p>
            </div>
        </div>
    </body>
    </html>";
        }

    }
}
