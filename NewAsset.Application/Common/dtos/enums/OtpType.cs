using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.dtos.enums
{
    public enum OtpType
    {
        PasswordReset = 1,
        UnlockDevice = 2,
        UnlockProfile = 3,
        RetrieveUsername = 4,
        Registration = 5,
        Confirmation = 6,
        PinResetOrChange = 7
    }
}
