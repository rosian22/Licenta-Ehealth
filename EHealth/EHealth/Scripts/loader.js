
var showLoading = function () {
    $('.loading-container').show();
};

var hideLoading = function () {
    $('.loading-container').hide();
};

var showSuccess = function (message) {
    if (!message) {
        message = 'Success!';
    }

    $('.success-message p').text(message);
    $('.success-message').show();

    setTimeout(function () {
        $('.success-message').hide();
    }, 2000);
}

var showError = function (message) {
    if (!message) {
        message = 'An error has ocurred. Please try again later';
    }

    $('.error-message p').text(message);
    $('.error-message').show();


    setTimeout(function () {
        $('.error-message').hide();
    }, 2000);
}
