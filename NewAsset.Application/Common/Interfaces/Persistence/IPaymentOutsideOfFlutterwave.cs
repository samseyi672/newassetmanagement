

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IPaymentOutsideOfFlutterwave
    {
        void AddIPaymentOutsideOfFlutterwave(PaymentNotificationOutsideOfFlutterwave paymentOutsideOfFlutterwave);
        PaymentNotificationOutsideOfFlutterwave GetIPaymentOutsideOfFlutterwaveByUserNameAndUserType(string UserName, string UserType, string PaymentReference);
    }
}
