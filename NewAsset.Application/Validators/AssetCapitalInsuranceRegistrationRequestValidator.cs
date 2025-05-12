

namespace NewAsset.Application.Validators
{

    public class AssetCapitalInsuranceRegistrationRequestValidator:AbstractValidator<AssetCapitalInsuranceRegistrationRequest>
    {
        public AssetCapitalInsuranceRegistrationRequestValidator()
        {
            RuleFor(x => x.ChannelId)
                .GreaterThan(0).WithMessage("ChannelId must be greater than 0.");

            RuleFor(x => x.Bvn)
                .NotEmpty().WithMessage("BVN is required.")
                .Length(11).WithMessage("BVN must be exactly 11 digits.")
                .Matches("^[0-9]+$").WithMessage("BVN must contain only digits.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{11}$").WithMessage("Phone number must be exactly 11 digits.");

            RuleFor(x => x.Nin)
                .NotEmpty().WithMessage("NIN is required.")
                .Length(11).WithMessage("NIN must be exactly 11 digits.")
                .Matches("^[0-9]+$").WithMessage("NIN must contain only digits.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MinimumLength(5).WithMessage("Address must be at least 5 characters long.")
                .Matches(@"^[a-zA-Z0-9\s.,]+$").WithMessage("Address can only contain letters, numbers, spaces, commas, and periods.");

            RuleFor(x => x.UserType)
                .NotEmpty().WithMessage("UserType is required.")
                .Must(value => new[] { "asset", "capital", "insurance" }
                    .Contains(value.Trim().ToLower()))
                .WithMessage("UserType must be 'asset', 'capital', or 'insurance'.");
        }
    }

}
