

namespace NewAsset.Application.Validators
{
    public class SavePasswordRequestValidator:AbstractValidator<SavePasswordRequest>
    {
      public SavePasswordRequestValidator()
      {
            RuleFor(x => x.DeviceId)
                .NotEmpty().WithMessage("DeviceId is required.")
                .MinimumLength(5).WithMessage("DeviceId must be at least 5 characters long.")
                .Matches(@"^[a-zA-Z0-9\s.]+$").WithMessage("DeviceId can only contain letters and dots");
            RuleFor(x => x.DeviceName)
               .NotEmpty().WithMessage("DeviceName is required.")
               .MinimumLength(5).WithMessage("DeviceName must be at least 5 characters long.")
               .Matches(@"^[a-zA-Z0-9\s.]+$").WithMessage("DeviceName can only contain letters and dots");
        }
    }

}


