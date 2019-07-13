
namespace Deventure.Common.Response
{
    public class ResponseCode
    {
        // Used for standard serialization 
        public const int NotSet = -1;

        public const int Success = 0;

        public const int Error = 1;
        public const int ErrorInvalidInput = 2;
        public const int ErrorNotInDatabase = 3;
        public const int ErrorEntitieAlreadyDeleted = 4;
        public const int ErrorUpdateFailed = 5;
        public const int InactiveAccount = 6;
        public const int ErrorAnErrorOccurred = 7;
        public const int ErrorNoInternet = 8;
        public const int ErrorEmailAlreadyTaken = 9;
        public const int ErrorUserDoesntExists = 10;
        public const int ErrorPendingApproval = 11;
        public const int ErrorRejectedOrDeletedAccount = 12;
        public const int ErrorUserPortfolioLimitReached = 13;
        public const int ErrorNeedMainPortfolio = 14;
        public const int ErrorNeedSecondPortfolio = 15;
        public const int ErrorUsernameTaken = 16;
        public const int ErrorFoundEmailCollisionOnCreate = 17;
        public const int ErrorSignInFail = 18;
        public const int ErrorInvalidUsernameOrPassword = 19;
        public const int ErrorSignUpFail = 20;
        public const int SuccessYourRequestResetPassword = 21; //do we keep this?
        public const int ErrorWrongWhitelabelId = 22;
        public const int ErrorFailedToSendEmail = 23;
        public const int ErrorInvaldPhoneNumberFormat = 24;

        // Success code constants ## starts from 1000
        public const int SuccessStart = 1000;
        public const int SuccessProfileUpdated = 1001;
        public const int SuccessSignUp = 1002;
        public const int SuccessSignIn = 1003;
        public const int SuccessSignOut = 1004;
        public const int SuccessYourPasswordWasReset = 1005;  //do we keep this?
        public const int SuccessPartial = 1006;

    }

    public static class CodeConstantsExtensions
    {
        public static bool IsEqualToResponseCode(this int value, int target)
        {
            return target.IsEqualToInt(value);
        }

        #region private methods

        private static bool IsEqualToInt(this int value, int target)
        {
            return value == target;
        }

        #endregion
    }
}