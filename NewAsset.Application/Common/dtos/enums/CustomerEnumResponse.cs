
namespace NewAsset.Application.Common.dtos.enums
{
    public enum EnumFixedDepositInvestmentType
    {
        [Description("Fixeddeposit")]
        Fixeddeposit,
        [Description("Halal")]
        Halal
    }
    public enum CustomerEnumResponse
    {
        [Description("Invalid Otp")]
        InvalidOtp,
        [Description("No Transactions Found")]
        NoTransactionFound,
        [Description("No file uploaded")]
        NoFileUploaded,
        // NoTransactionFound =56,
        [Description("PhoneNUmber Required")]
        PhoneNumberRequired,
        [Description("PhoneNUmber/Email already Exists.Pls complete your Registration")]
        InvalidAccountOpeningWithNin,
        [Description("Client Not Valid")]
        InvalidNin,
        [Description("Change Default Password")]
        PasswordNotChanged,
        [Description("Account Does Not Exist")]
        NoAccountExist,
        [Description("No Picture Found")]
        NoPictureFound,
        [Description("Registration Completed Successfully. Kindly Login")]
        RegistrationComplete,
        [Description("Sorry,Service failure.Please try again.")]
        SystemError,
        [Description("Sorry,this service is unavailable.Please try again later.")]
        SystemError2,
        [Description("InValid OTP")]  // this was change from validate to invalid
        OtpNotValidated,
        [Description("Password Conditions Not Met")]
        PasswordConditionNotMet,
        LoginSuccessful,
        [Description("Log out successful. Come back soon.")]
        LogoutSuccessful,
        [Description("Profile Already Exist")]
        ProfileAlreadyExist,
        [Description("Account Already Exist")]
        AccountAlreadyExist,
        [Description("Invalid BVN")]
        InvalidBvn,
        [Description("Suspected fraud/Invalid account")]
        SuspectedFraud,
        [Description("Incorrect Username or Password. Please check the information and try again.")]
        InvalidUsernameOrPassword,
        [Description("Profile Not Active")]
        DeviceNotRegistered = 30,
        [Description("Your profile is inactive and account locked.")]
        InActiveProfile = 31,
        [Description("Account Locked")]
        AccountLocked,
        [Description("Phone Number Is Not Registered")]
        PhoneNotRegistered,
        [Description("File Not Found")]
        FileNotFound,
        [Description("Email Address is Required")]
        EmailRequired,
        [Description("Your session has expired. Please log in to continue.")]
        SessionExpired,
        [Description("Device ID is Required")]
        DeviceIdRequired,
        NotProfiledOnMobile,
        [Description("Incorrect PIN. Please check and try again.")]
        InvalidTransactionPin,
        [Description("This device is not registered. Please unlock device to continue.")]
        ErrorGeneratingSession,
        [Description("Error Creating Profile")]
        ErrorCreatingProfile,
        AlreadyLoggedInOnDifferentChannel,
        SessionGeneratedSuccessfully,
        [Description("Password Expired, Kindly Reset It")]
        PasswordExpired,
        [Description("Incorrect validation information. Please check the information and try again.")]
        WrongDetails,
        [Description("Username Not Found")]
        UsernameNotFound,
        [Description("Transaction limit exceeded.")]
        DailyLimitExceed,
        [Description("User Already Exists. Please log in")]
        UserAlreadyExist,
        [Description("You are not registered on this platform. Sign up now and let’s get you started.")]
        NotProfileOnChannel,
        [Description("Duplicate Records")]
        DuplicateRecoundsFound,
        [Description("Transaction in progress. Please try again after one minute.")]
        DuplicateTransaction,
        [Description("You are currently logged in elsewhere. Please log out of existing session to continue.")]
        AlreadyLoggedIn,
        [Description("Username Must Contain Either String or Digits")]
        UsernameStringDigitOnly,
        [Description("Username Already Exist")]
        UsernameAlreadyExist,
        [Description("Operation Not Successful.")]
        NotSuccessful,
        [Description("Successful")]
        Successful,
        InvalidDetails,
        [Description("You have been logged out due to a session mismatch. Please log in again to continue.")]
        InvalidSession,
        [Description("Session end.Please restart and continue where you stopped.")]
        RestartRegistration,
        [Description(" Incorrect account number. Please check the number and try again.")]
        InvalidAccount,
        [Description("Invalid Registration Session")]
        InvalidRegSession,
        [Description("No Loan Found")]
        NoLoanFound,
        [Description("Username And Password is Compulsory")]
        UsernameOrPasswordRequired,
        [Description("Channel Not Permitted for Transactions")]
        ChannelError,
        [Description("Invalid Beneficiary")]
        InvalidBeneficiary,
        [Description("Not a Retail Account")]
        NotRetail,
        [Description("Application is busy. Please try again later")]
        ApplicationBusy,
        [Description("User Not Found")]
        UserNotFound,
        [Description("Invalid PhoneNumber")]
        InvalidPhoneNumber,
        [Description("Zero AmountOrPrincipal is  not Permitted")]
        ZeroAmountError,
        [Description("Nin is Valid")]
        ValidNin,
        [Description("Nin is Invalid")]
        InValidNin,
        [Description("Name Mismatch")]
        NameMisMatch,
        [Description("Date of Birth Mismatch")]
        DateMismatch,
        [Description("You already have an account")]
        UserAlreadyHasAnAccount,
        [Description("Investment Liquidated")]
        Liquidated,
        [Description("Wrong investment type")]
        WrongInvestmentType,
        [Description("Wrong beneficiary type. 1 or 2 is accepted")]
        InvalidBeneficiaryType,
        [Description("beneficiary already exists")]
        BeneficiaryAlreadyExists,
        [Description("Invalid Loan Tenor")]
        NotLoanTenor,
        [Description("Wrong date format")]
        WrongDateformat,
        [Description("Transaction Id Already Exists")]
        TransactionIdAlreadyExists,
        [Description("Staff does not exists")]
        StaffNotExists,
        [Description("wrong action input")]
        WrongAction,
        [Description("PhoneNumber already exists")]
        PhoneAlreadyExists,
        [Description("Approval denied successfully")]
        ApprovalDenied,
        [Description("Action likely approve.Please check with the admin or IT")]
        ActionLikelyApprove,
        [Description("Invalid staff id")]
        InvalidStaffid,
        [Description("Otp time out")]
        OtpTimeOut,
        [Description("DOB not found")]
        DobNotFound,
        [Description("Investment account does not exists")]
        InvestmentAccountDoesNotExists,
        [Description("Investment not found")]
        InvestmentNotfound,
        [Description("Invalid registration Id")]
        InvalidRegistrationId,
        [Description("This customer profile does not exists on Asset")]
        NotProfiledOnAsset,
        [Description("This customer bvn,firstname,lastnameand email cannot be empty")]
        InvalidBvnFirstNameLastnameEmailBirthDate,
        [Description("This customer validation unsuccessful")]
        CustomerValidationUnSuccessful,
        [Description("The authentication system is not available")]
        RedisError,
        [Description("The bvn cannot be found.")]
        BvnNotFound,
        [Description("No data found")]
        NotDataFound,
        [Description("invalid date format")]
        InvalidDateformat,
        [Description("Client identity is missing.Please contact the admin")]
        ClientIdNotFound,
        [Description("Please provide an optional email")]
        NoValidEmail,
        [Description("No Registration Found")]
        RegistratioNotFound
    }
}
