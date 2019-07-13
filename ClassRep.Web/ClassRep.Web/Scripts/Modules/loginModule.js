var loginModule = function () {

    //private methods
    function validateForm(formName) {
        var $form = $("#" + formName);
        $form.validate();
        return $form.valid();
    }


    function performLogin() {
        debugger
        var result = validateForm("login-form");
        if (!result) {
            return;
        }

        var postModel = {
            Email: $("#LoginEmail").val(),
            Password: $("#Password").val(),
        };

        var url = "/Account/Login/";
        ajaxHelper.post(url, postModel,
            function (response) {
                if (response && response.Success) {

                    setTimeout(function () {
                        var returnUrl = getUrlParam("ReturnUrl");
                        if (returnUrl === undefined || returnUrl === null) {
                            returnUrl = "/Home/Index";
                        }
                        window.location = returnUrl;
                    }, 2500);
                    toastrModule.showSuccess("You have successfully logged in");

                }
                else {
                    loginFailed();
                    return;
                }

            },
            function (response) {
                forgotFailed();
            }
        );

    }

    function forgotPassword() {

        var result = validateForm("login-form-forgot");
        if (!result) {
            return;
        }
        var postForgotPassword = {
            EmailForgot: $("#EmailForgot").val(),
        };

        ShowLoading();

        var url = "/Account/ForgotPassword";
        ajaxHelper.post(url, postForgotPassword,
            function (response) {
                if (response === undefined || response.Success === undefined ||
                    response.StatusCode === undefined) {

                    forgotFailed();
                }
                else {
                    if (response.Success === false) {
                        forgotFailed();
                        return;
                    }
                    toastrModule.showSuccess("You have successfully logged in");

                }
                HideLoading();

            },
            function (response) {
                forgotFailed();
            }
        );

    }

    function toggleTwoFactoSteps(step) {
        if (typeof (loginVM) !== "undefined" && loginVM) {
            loginVM.ViewMode(step);
        }
    }

    function openForgotPassword() {
         returnUrl = "/Account/ForgotPassword";
         window.location = returnUrl;
    }

      function openLogin() {
         returnUrl = "/Account/Login";
         window.location = returnUrl;
    }



    function loginFailed() {
        toastrModule.showError("The username or password is incorrect");
    }

    function forgotFailed() {
        toastrModule.showError("The username is incorrect");
    }

    return {
        performLogin: performLogin,
        forgotPassword: forgotPassword,
        openForgotPassword: openForgotPassword,
        toggleTwoFactoSteps: toggleTwoFactoSteps,
        openLogin: openLogin
    }
}();