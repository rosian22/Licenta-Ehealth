var loginModule = function () {
    function validateForm(formName) {
        var $form = $("#" + formName);
        $form.validate();
        return $form.valid();
    }

    function performLogin() {
        var result = validateForm("login-form");
        if (!result) {
            return;
        }
        var postModel = {
            Email: $("#email-input").val(),
            Password: $("#password-input").val()
        };

        var url = "/Login/Login/";
        ajaxHelper.post(url, postModel,
            function (response) {
                if (response === undefined || response.Success === undefined ||
                    response.StatusCode === undefined) {

                    loginFailed();
                }
                else {
                    if (response.Success === false) {
                        loginFailed();
                        return;
                    }

                    console.log("You have successfully logged in");
                    setTimeout(function () {
                        if (typeof (Storage) !== "undefined") {
                            localStorage.setItem("email", postModel.Email);
                            localStorage.setItem("password", postModel.Password);
                        }

                        var returnUrl = getUrlParam("ReturnUrl");
                        if (returnUrl === undefined || returnUrl === null) {
                            returnUrl = "/Home/Index";
                        }
                        window.location = returnUrl;
                    }, 2500);
                }
            },
            function (response) {
                loginFailed();
            }
        );
    }

    function loginFailed() {
        console.log("The username or password is incorrect!");
    }

    return {
        performLogin: performLogin
    }
}();