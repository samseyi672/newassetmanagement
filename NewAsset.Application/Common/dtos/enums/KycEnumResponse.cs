

namespace NewAsset.Application.Common.dtos.enums
{
    public enum KycEnumResponse
    {
        [Description("wrong file type")]
        WrongFileType,
        [Description("All Kyc completed already")]
        AllApprovedAll,
        [Description("Wrong user Type")]
        WrongUserType,
        [Description("Invalid file format")]
        InvalidFileformat
    }
}
