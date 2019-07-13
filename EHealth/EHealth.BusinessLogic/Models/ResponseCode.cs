﻿namespace EHealth.BusinessLogic.Models
{
    public enum ResponseCode
    {
        NotSet = -1,
        Success = 0,
        Error = 1,
        ErrorInvalidInput = 2,
        ErrorNotInDatabase = 3,
        ErrorEntitieAlreadyDeleted = 4,
        ErrorUpdateFailed = 5,
        InactiveAccount = 6,
        ErrorAnErrorOccurred = 7,
        ErrorNoInternet = 8,
        ErrorEmailAlreadyTaken = 9,
        ErrorUserDoesntExists = 10,
        ErrorPendingApproval = 11,
        ErrorRejectedOrDeletedAccount = 12,
        ErrorUserPortfolioLimitReached = 13,
        ErrorNeedMainPortfolio = 14,
        ErrorNeedSecondPortfolio = 15,
        ErrorUsernameTaken = 16,
        ErrorFoundEmailCollisionOnCreate = 17,
        ErrorSignInFail = 18,
        ErrorInvalidUsernameOrPassword = 19,
        ErrorSignUpFail = 20,
        SuccessYourRequestResetPassword = 21,
        ErrorWrongWhitelabelId = 22,
        ErrorFailedToSendEmail = 23,
        ErrorInvaldPhoneNumberFormat = 24,
        ErrorEmailInvalid = 25,
        SuccessStart = 1000,
        SuccessProfileUpdated = 1001,
        SuccessSignUp = 1002,
        SuccessSignIn = 1003,
        SuccessSignOut = 1004,
        SuccessYourPasswordWasReset = 1005,
        SuccessPartial = 1006,

    }
}