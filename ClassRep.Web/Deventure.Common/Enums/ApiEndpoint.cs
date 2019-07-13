namespace Deventure.Common.Enums
{
    public enum ApiEndpoint
    {
        GetUser = 1,
        Login = 2,
        Logout = 3,
        RecoverPassword = 4,
        CheckUsernameUniqueness = 5,

        IsAuthorized = 6,

        CreateStorageClient = 7,
        SubscribeToken = 8,
        GetUserByEmail = 9, 
        GetApplicationSettings = 10,
        GetCommunityList = 11,
        ValidateCredentials = 12,
        CheckToken = 13,
        GetCourses = 14,
        GetCurrentVideoByCourse = 15,
        GetNextVideo = 16,
        GetCurrentVideo = 17,
        GetCustomer = 18,
        GetCountrySettings = 19,
        GetCountryWithFlags = 20,
        RegisterUser = 21,
        VIPRequest = 22,
        GetVideoList = 23,
        GetDefaultData = 24,
        GetPortfolioData = 25,
        SavePortfolio = 26,
        SendCode = 27,
        AuthenticateWithCode = 28,
        BuyMarkets = 29,
        UpdateMedia = 30,
        UpdateProfileInfo = 31,
        UpdateProfileSecurity = 32,
        GetMarketsChartData = 33,
        Purchase = 34
    }
}