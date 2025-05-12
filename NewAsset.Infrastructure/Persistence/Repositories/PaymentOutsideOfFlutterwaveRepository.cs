

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class PaymentOutsideOfFlutterwaveRepository : IPaymentOutsideOfFlutterwave
    {

        private readonly AppDbContext _context;
        public PaymentOutsideOfFlutterwaveRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddIPaymentOutsideOfFlutterwave(PaymentNotificationOutsideOfFlutterwave paymentOutsideOfFlutterwave)
        {
            // _context.SaveChanges();
            var PaymentNotificationOutsideOfFlutterwave = _context.paymentnotificationoutsideofflutterwaves.FirstOrDefault(u => u.id == paymentOutsideOfFlutterwave.id);
            if (PaymentNotificationOutsideOfFlutterwave != null)
            {
                _context.Entry(PaymentNotificationOutsideOfFlutterwave).CurrentValues.SetValues(paymentOutsideOfFlutterwave);
            }
            else
            {
                _context.paymentnotificationoutsideofflutterwaves.Add(paymentOutsideOfFlutterwave); // new entities
            }
            _context.SaveChanges();
        }

        public PaymentNotificationOutsideOfFlutterwave GetIPaymentOutsideOfFlutterwaveByUserNameAndUserType(string UserName, string UserType, string PaymentReference)
        {
            return _context.paymentnotificationoutsideofflutterwaves
              .FirstOrDefault(p => string.Equals(p.UserName, UserName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(p.UserType, UserType, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(p.PaymentReference, PaymentReference, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
