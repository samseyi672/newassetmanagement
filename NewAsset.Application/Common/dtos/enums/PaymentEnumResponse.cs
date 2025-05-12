

namespace NewAsset.Application.Common.dtos.enums
{
  public enum PaymentEnumResponse
    {
        [Description("One of NGN,USD,GBP is expected")]
        InvalidCurrencyFormat,
        [Description("This Bank already added for you")]
        ClientBankAlreadyAdded,
        [Description("Payment failed")]
        PaymentFailed,
        [Description("No Payment found")]
        NoPaymentFound,
        [Description("Invalid paymentoption.")]
        PaymentChannelNotAllowed,
        [Description("Transaction Successful but subscription failed.")]
        TransactionButSubscriptionFailed,
        [Description("Payment submitted already.")]
        PaymentSubmittedAlready,
        [Description("Liquidation still in process.")]
        LiquidationInProcessalready,
        [Description("Formal Partial Liquidation still in process.")]
        PartialsLiquidationInProcessalready,
        [Description("Full Liquidation approved.")]
        FullLiquidationApprovedalready,
        [Description("Minimum payable amount is 1000")]
        MinimumAmountPayment,
        [Description("Invalid account number or meter number")]
        IncorrectMeterOrAccountNumber,
        [Description("Temporary pin cannot be used for transaction")]
        TemporaryPin,
        [Description("Pin not found")]
        TransactionPinNotFound,
        [Description("Insufficient Balance")]
        InsufficientBalance,
        [Description("Unable to Debit Account")]
        UnabletoDebit,
        [Description("Withdrawal Request Pending")]
        WithdrawRequest,
        [Description("Transfer can not be made to the same account")]
        SameAccountErrors,
        [Description("Transaction ID Error")]
        TransError,
        [Description("Duplicate Transaction Error")]
        TransactionNotPermittedWithInterval,
        [Description("Transaction Submitted Successfully")]
        TransactionError,
        [Description("Wrong File format.only png or jpeg is accepted")]
        WrongFileFormat,
        [Description("No permission assigned")]
        NoPermissions,
        [Description("Staff not profiled")]
        UserNotProfiled,
        [Description("please profile users to aprrove this action")]
        ProfileUserAction,
        [Description("You cannot approve because you intiated it")]
        YouareNottheOne
    }
}
