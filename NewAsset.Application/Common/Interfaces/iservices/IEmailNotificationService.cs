using System;


namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface IEmailNotificationService
    {
        public GenericApiResponse<string> sendOtpMail(SendMail sendMail,MemoryStream? pdfStream);
    }
}
