

using System.Net.Mail;

namespace NewAsset.Infrastructure.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        private readonly SmtpDetails _smtpDetails;

        public EmailNotificationService(ILogger<EmailNotificationService> logger, IOptions<SmtpDetails> smtpDetails)
        {
            _logger = logger;
            _smtpDetails = smtpDetails.Value;
        }

        public GenericApiResponse<string> sendOtpMail(SendMail sendMail, MemoryStream? pdfStream)
        {
            try
            {
                _logger.LogInformation($"SendMailObject {JsonConvert.SerializeObject(sendMail)} smtpDetails.Host {_smtpDetails.Host} -- smtpDetails.Port {_smtpDetails.Port}");
                SmtpClient MyServer = new SmtpClient()
                {
                    Host = _smtpDetails.Host,// "smtp.office365.com",
                    Port = _smtpDetails.Port,// 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    //Credentials = new NetworkCredential("eyiwunmi.dawodu@trustbancgroup.com", "Jugger007%")
                    Credentials = new NetworkCredential(_smtpDetails.Username, _smtpDetails.Password)
                };

                MailAddress from = new MailAddress(_smtpDetails.FrmMail, _smtpDetails.FrmName);
                MailAddress receiver = new MailAddress(sendMail.Email,sendMail.Firstname);
                MailMessage Mymessage = new MailMessage(from, receiver);
                Attachment attachment = null;
                if (pdfStream != null)
                {
                    attachment = new Attachment(pdfStream, $"{sendMail.Firstname}.pdf", "application/pdf");
                    Mymessage.Attachments.Add(attachment);
                }
                if (!string.IsNullOrEmpty(_smtpDetails.BccMail))
                {
                    MailAddress bcc = new MailAddress(_smtpDetails.BccMail);
                    Mymessage.Bcc.Add(bcc);
                }

                Mymessage.Subject = sendMail.Subject;
                Mymessage.Body = sendMail.Html;
                //sends the email
                Mymessage.IsBodyHtml = true;
                try
                {
                    MyServer.Send(Mymessage);
                    Console.WriteLine("mail sent in mailer .......");
                    _logger.LogInformation($"Mail sent to {sendMail.Email} -- {sendMail.Subject}");
                    return GenericApiResponse<string>.SuccessResponse(CustomerEnumResponse.Successful.GetDescription());
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message + " " + ex.StackTrace);
                    throw new NetworkRequestException(ex.Message);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                throw new NetworkRequestException(ex.Message);
            }
        }
    }
}
