

namespace NewAsset.Application.Common.Utilities
{

    /// <summary>
    ///centralizing your UserType values will eliminate duplication 
    ///and reduce the chance of typos.
    /// </summary>
    public static class UserTypes
    {
        public const string Asset = "asset";
        public const string Capital = "capital";
        public const string Insurance = "insurance";

        public static readonly string[] All = { Asset, Capital, Insurance };

        public static bool IsValid(string? value) =>
            !string.IsNullOrWhiteSpace(value) &&
            All.Contains(value.Trim().ToLower());
    }

}
