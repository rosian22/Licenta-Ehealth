Array.prototype.count = function (expr) {
    if (expr === undefined || typeof expr !== "function") {
        return null;
    }

    var count = 0;
    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            count++;
        }
    }
    return count;
};

Array.prototype.all = function (expr) {
    for (var i = 0; i < this.length; i++) {
        if (!expr(this[i])) {
            return false;
        }
    }

    return true;
};

Array.prototype.where = function (expr) {
    if (expr === undefined || typeof expr !== "function") {
        return null;
    }

    var out = [];
    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            out.push(this[i]);
        }
    }
    return out;
};

Array.prototype.select = function (expr) {
    if (expr === undefined || typeof expr !== "function") {
        return null;
    }

    var out = [];
    for (var i = 0; i < this.length; i++) {
        out.push(expr(this[i]));
    }

    return out;
};

Array.prototype.whereSelect = function (where, select) {
    if (!where || !select || typeof where !== "function" || typeof select !== "function") {
        return null;
    }

    if (this.length === 0) {
        return [];
    }

    var out = [];
    for (var i = 0; i < this.length; i++) {
        if (where(this[i])) {
            out.push(select(this[i]));
        }
    }

    return out;
};

Array.prototype.find = function (expr) {
    if (expr === undefined || typeof expr !== "function") {
        return null;
    }
    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            return this[i];
        }
    }
    return null;
};

Array.prototype.last = function (expr) {
    if (this.length === 0) {
        return null;
    }

    if (!expr || typeof (expr) !== "function") {
        return this[this.length - 1];
    }

    var subArray = this.where(expr);
    if (subArray !== null) {
        if (subArray.length === 0) {
            return null;
        }
        else {
            return subArray[subArray.length - 1];
        }
    }

    return this[this.length - 1];
};

Array.prototype.minMax = function (getMinOrMax) {
    if (this.length == 0) {
        return null;
    }

    var minMax = this[0];

    for (var i = 0; i < this.length; i++) {
        minMax = getMinOrMax(this[i], minMax);
    }

    return minMax;
}

Array.prototype.aggregate = function (list) {
    if (list.length === 0) {
        return;
    }

    for (var i = 0; i < list.length; i++) {
        this.push(list[i]);
    }
};

Array.prototype.aggregateEx = function (listArray) {
    if (listArray.length === 0) {
        return;
    }

    var elements = [];

    for (var i = 0; i < listArray.length; i++) {
        for (var j = 0; j < listArray[i].length; j++) {
            elements.push(listArray[i][j]);
        }
    }

    this.length = 0;
    for (var i = 0; i < elements.length; i++) {
        this.push(elements[i]);
    }
};

Array.prototype.first = function (expr) {
    if (this.length === 0) {
        return null;
    }

    if (!expr) {
        return this.length > 0 ? this[0] : null;
    }

    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            return this[i];
        }
    }

    return null;
};

Array.prototype.addAggregated = function (array) {
    for (var i = 0; i < array.length; i++) {
        this.push(array[i]);
    }

    return this;
};

Array.prototype.any = function (expr) {
    if (this.length === 0) {
        return false;
    }

    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            return true;
        }
    }

    return false;
};

Array.prototype.hasEventOccured = function (eventName) {
    if (this.length === 0) {
        return false;
    }

    for (var i = 0; i < this.length; i++) {
        if (this[i] === eventName) {
            return true;
        }
    }

    return false;
};

Array.prototype.indexWhere = function (expr) {
    if (this.length === 0) {
        return -1;
    }

    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            return i;
        }
    }

    return -1;
};

Array.prototype.indicesWhere = function (expr) {
    var outData = [];
    if (this.length === 0) {
        return outData;
    }

    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            outData.push(i);
        }
    }

    return outData;
};

Array.prototype.forEach = function (expr) {
    if (this.length === 0) {
        return;
    }

    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            break;
        }
    }
};

Array.prototype.count = function (expr) {
    if (this.length === 0) {
        return 0;
    }

    var count = 0;
    for (var i = 0; i < this.length; i++) {
        if (expr(this[i])) {
            count++;
        }
    }

    return count;
};

Array.prototype.containsByProp = function (prop, value) {
    var found = this.first(function (ar) {
        return ar[prop] !== undefined && ar[prop] === value;
    });

    return found;
}

Array.prototype.getById = function (id) {
    for (var i = 0; i < this.length; i++) {
        if (this[i].Id === id) {
            return this[i];
        }
    }

    return null;
};

Array.prototype.groupByProp = function (propName) {
    var groups = [];

    for (var i = 0; i < this.length; i++) {
        var element = this[i];

        if (!element) {
            continue;
        }

        var group = groups.first(function (e) {
            return compareByPropEx(e, element, "Key", propName);
        });

        if (!group) {
            group = {
                Key: element[propName],
                Items: []
            };

            groups.push(group);
        }

        group.Items.push(element);

    }

    return groups;
}

function _getMsb(n) {
    if (typeof n !== "number") {
        return null;
    }

    n = Math.floor(n);
    if (n === 0) {
        return 0;
    }

    return 1 * Math.pow(2, Math.floor(Math.log2(n)));
}

function getActivePageNumber() {
    if (!$(".pagination").length) {
        return 0;
    }

    var activePageTab = $(".pagination").find(".active");
    if (activePageTab === undefined) {
        return 0;
    }

    var pageNumber = parseInt($(activePageTab).find("a").html());
    if (isNaN(pageNumber)) {
        return 0;
    }

    return pageNumber - 1;
}

function getActivePageNoForTab(tabId) {
    if (!$("#" + tabId + " .pagination").length) {
        return 0;
    }

    var activePageTab = $("#" + tabId + " .pagination").find(".active");
    if (activePageTab === undefined) {
        return 0;
    }

    var pageNumber = parseInt($(activePageTab).find("a").html());
    if (isNaN(pageNumber)) {
        return 0;
    }

    return pageNumber - 1;
}

String.prototype.isEmpty = function () {
    return this.trim() === "";
}

function isNullOrEmpty(str) {
    return str === undefined || str === null || str.isEmpty();
}

function hasClass(element, className) {
    if (element === undefined || element === null)
        return false;

    if (className === null || className === undefined || className === "")
        return true;

    var classNames = element.className.split(" ");
    for (var i = 0; i < classNames.length; i++) {
        if (classNames[i] === className) {
            return true;
        }
    }

    return false;
};

function removeClass(element, className) {
    if (element === undefined || element === null)
        return;

    if (className === null || className === undefined || className === "")
        return;

    var classNames = element.className.split(" ");
    var finalClassName = "";
    for (var i = 0; i < classNames.length; i++) {
        if (classNames[i] !== className) {
            finalClassName += classNames[i] + " ";
        }
    }

    element.className = finalClassName;
}

function validResult(result) {
    return result !== undefined && result.Success !== undefined && result.Success;
}

function showError() {
    if (typeof (toastrModule) === undefined) {
        throw "need toastrModule!!!!";
    }

    toastrModule.showError("An error occurred, please try again.");
}

function extractHostname(url) {
    var hostname;

    if (url.indexOf("://") > -1) {
        hostname = url.split('/')[2];
    }
    else {
        hostname = url.split('/')[0];
    }

    hostname = hostname.split(':')[0];
    hostname = hostname.split('?')[0];

    return hostname;
}

function navigate(url) {
    document.location.href = url;
}

function getUrlParam(name) {
    var decodedUrl = decodeURIComponent(window.location.href);
    if (decodedUrl === undefined || decodedUrl === null)
        return null;
    try {
        if (decodedUrl.indexOf('ReturnUrl') < 0) {
            return null;
        }
        return decodedUrl.substring(decodedUrl.indexOf('ReturnUrl') + "ReturnUrl=".length)
    } catch (e) {
        return null;
    }
};

function showModal(id) {
    $("#" + id).modal("show");
}

function hideModal(id) {
    $("#" + id).modal("hide");
}

function createElementFromHTML(htmlString) {
    var div = document.createElement('div');
    div.innerHTML = htmlString.trim();

    return div.firstChild;
}

function __click(id) {
    $("#" + id).click();
}

function __clickSibling(selector) {
    var child = $($($(this).parent()[0]).children(selector)[0])[0];
    if (child) {
        $(child).click();
    }
}

function __clickChild(selector) {
    var child = $(this).children(selector)[0];
    if (child) {
        $(child).click();
    }
}

function __toggleAttr(attr, val1, val2) {
    var $self = $(this);

    if ($self.attr(attr) === val1) {
        $self.attr(attr, val2);
    }
    else {
        $self.attr(attr, val1);
    }
}

function __toggleAttrFirstChild(attr, val1, val2) {
    var val = $($(this).children()[0]).attr(attr);

    if (!val || val != val1) {
        var val = $($(this).children()[0]).attr(attr, val1);

    }
    else {
        var val = $($(this).children()[0]).attr(attr, val2);
    }
}

function __toggleAttrByClass(className, attr, val1, val2) {

    var elements = $("." + className).toArray();
    for (var i = 0; i < elements.length; i++) {
        var $self = $(elements[i]);

        if ($self.attr(attr) === val1) {
            $self.attr(attr, val2);
        }
        else {
            $self.attr(attr, val1);
        }
    }

}

function __setAttr(attr, val) {
    var $self = $(this);

    if ($self.attr(attr) !== val) {
        $self.attr(attr, val);
    }
}

function _stopPropagatingEvent(event) {
    event.stopPropagation();
}

function _copy(obj) {
    if (obj === undefined || obj === null)
        return obj;

    if (_isObservable(obj)) {
        return JSON.parse(JSON.stringify(obj()));
    }

    return JSON.parse(JSON.stringify(obj));
}

function isValid(obj) {
    return obj !== undefined && obj !== null;
}

function addStatus(status, toAdd) {
    return status | toAdd;
}
function removeStatus(status, toRemove) {
    return status & (~toRemove);
}
function hasStatus(status, have) {
    return (status & have) > 0;
}
function hasAllStatuses(status, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (!hasStatus(status, arr[i])) {
            return false;
        }
    }
    return true;
}
function hasNonOfTheStatuses(status, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (hasStatus(status, arr[i])) {
            return false;
        }
    }
    return true;
}
function hasAnyStatuses(status, arr) {
    for (var i = 0; i < arr.length; i++) {
        if (hasStatus(status, arr[i])) {
            return true;
        }
    }
    return false;
}

function isInteger(obj) {
    return !isNaN(parseInt(obj)) && isFinite(obj);
};

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function isAlphaNumeric(input) {
    var regex = /^[a-z0-9]+$/i;
    return regex.test(String(input).toLowerCase());
}

Date.prototype.toUTC = function () {
    return new Date(this.getUTCFullYear(), this.getUTCMonth(), this.getUTCDate(), this.getUTCHours(), this.getUTCMinutes(), this.getUTCSeconds());
};

Date.prototype.toIsoString = function () {
    var tzo = -this.getTimezoneOffset(),
        dif = tzo >= 0 ? '+' : '-',
        pad = function (num) {
            var norm = Math.floor(Math.abs(num));
            return (norm < 10 ? '0' : '') + norm;
        };
    return this.getFullYear() +
        '-' + pad(this.getMonth() + 1) +
        '-' + pad(this.getDate()) +
        'T' + pad(this.getHours()) +
        ':' + pad(this.getMinutes()) +
        ':' + pad(this.getSeconds()) +
        dif + pad(tzo / 60) +
        ':' + pad(tzo % 60);
}

if (typeof ($) === undefined) {
    throw "Need jquery!!!!";
}
else {
    $.fn.extend({
        confirm: function (message, okCallback, cancelCallback, options) {
            var element = this[0];
            if (element.Id === undefined) {
                element = this;
            }

            var okMessage = "Ok";
            var cancelMessage = "Cancel";
            var okClass = "button-primary";
            var cancelClass = "button-negative";
            var parentId = element.Id === undefined ? "" : element.Id;

            if (options !== undefined) {
                if (options.okValue !== undefined) {
                    okMessage = options.okValue;
                }
                if (options.cancelValue !== undefined) {
                    cancelMessage = options.cancelValue;
                }

                if (options.cancelClass !== undefined) {
                    cancelClass = options.cancelClass;
                }

                if (options.okClass !== undefined) {
                    cancelClass = options.okClass;
                }

                if (options.parent !== undefined) {
                    parentId = options.parent;
                }
            }

            var confirmTemplate = "<div class='jq-confirmation'><label class ='jq-confirmation-message'>" + message + "</label><br/><input class='jq-confirmation-ok " + okClass + "' type='button' value='" + okMessage + "' ><input class='jq-confirmation-cancel " + cancelClass + "' type='button' value='" + cancelMessage + "' ></div>";
            if ($('#' + parentId + ' .jq-confirmation').length === 0) {
                if (!$(element).hasClass('relative')) {
                    $(element).addClass("relative");
                }
                $(element).append(confirmTemplate);
                $('#' + parentId + ' .jq-confirmation-ok').click(function () {
                    if (okCallback !== undefined && typeof okCallback === "function") {
                        if (!okCallback(this)) {
                            return;
                        }
                    }

                    $('#' + parentId + ' .jq-confirmation').remove();
                });
                $('#' + parentId + ' .jq-confirmation-cancel').click(function () {
                    if (cancelCallback !== undefined && typeof cancelCallback === "function") {
                        if (!cancelCallback(this)) {
                            return;
                        }
                    }

                    $('#' + parentId + ' .jq-confirmation').remove();
                });
            }
        },
        confirm2: function (message, okCallback, cancelCallback, options) {
            var $element = $(this);
            if (!$element.hasClass('relative')) {
                $element.addClass("relative");
            }

            var okMessage = "Ok";
            var cancelMessage = "Cancel";
            var okClass = "button-primary";
            var cancelClass = "button-negative";

            if (options !== undefined) {
                if (options.okValue !== undefined) {
                    okMessage = options.okValue;
                }
                if (options.cancelValue !== undefined) {
                    cancelMessage = options.cancelValue;
                }

                if (options.cancelClass !== undefined) {
                    cancelClass = options.cancelClass;
                }

                if (options.okClass !== undefined) {
                    cancelClass = options.okClass;
                }

                if (options.parent !== undefined) {
                    parentId = options.parent;
                }
            }

            var confirmTemplate = "<div class='jq-confirmation'><label class ='jq-confirmation-message'>" + message + "</label><br/><input class='jq-confirmation-ok " + okClass + "' type='button' value='" + okMessage + "' ><input class='jq-confirmation-cancel " + cancelClass + "' type='button' value='" + cancelMessage + "' ></div>";
            $element.append(confirmTemplate);

            var $ok = $($element.find('.jq-confirmation-ok')[0]);
            $ok.on("click", function () {
                if (okCallback !== undefined && typeof okCallback === "function") {
                    if (!okCallback(this)) {
                        return;
                    }
                }

                $($element.find('.jq-confirmation')[0]).remove();
            });

            var $cancel = $($element.find('.jq-confirmation-cancel')[0]);
            $cancel.on("click", function () {
                if (cancelCallback !== undefined && typeof cancelCallback === "function") {
                    if (!cancelCallback(this)) {
                        return;
                    }
                }

                $($element.find('.jq-confirmation')[0]).remove();
            });
        },
        confirm3: function (title, message, okCallback, cancelCallback, options) {
            var template = "<div class='jq-popover-confirm'> " +
                "    <div class='jq-popover-header'>                                        " +
                "        <label class='jq-popover-title'>" + title + "</label>               " +
                "    </div>                                                                 " +
                "    <span class='jq-popover-hook'></span>                                  " +
                "    <span class='jq-popover-message'> " + message + " </span>              " +
                "    <input type='button' value='Ok' class='jq-popover-ok' />               " +
                "    <input type='button' value='Cancel' class='jq-popover-cancel' />       " +
                "</div>";

            var popover = createElementFromHTML(template);
            $(popover).children(".jq-popover-ok").click(okCallback);
            $(popover).children(".jq-popover-cancel").click(cancelCallback);

            $(this).parent().append(popover);
        },
        showLoading: function (selector) {
            var loadingTemplate = "<div class='jq-loading'></div>";

            if (selector !== undefined) {
                var element = $(this).children(selector);
                if (!$(element).hasClass('relative')) {
                    $(element).addClass("relative");
                }
                $(element).append(loadingTemplate);
            }
            else {
                var element = $(this);
                if (!$(element).hasClass('relative')) {
                    $(element).addClass("relative");
                }

                $(element).append(loadingTemplate);
            }
        },
        hideLoading: function (selector) {
            var loadingClass = ".jq-loading";

            if (selector !== undefined) {
                $("#" + $(this).attr("Id") + " " + selector + " " + loadingClass).remove();
            }
            else {
                $("#" + $(this).attr("Id") + " " + loadingClass).remove();
            }
        },
        resetValidation: function () {
            var $this = $(this);

            $this.removeData("validator");
            $.validator.unobtrusive.parse(this);
        },
        clearValidation: function () {
            $(this[0]).find(".field-validation-error").each(function (i, item) { $(item).html(""); });
        }
    });
}

function _number(event) {
    var isFirefox = typeof InstallTrigger !== 'undefined';
    var isChrome = !!window.chrome && !!window.chrome.webstore;

    if (isFirefox) {
        event.keyCode = event.charCode;
    }

    //allow only 1 [,] or [.]
    var currsorPosition = event.currentTarget.value.slice(0, event.currentTarget.selectionStart).length;

    if ((event.keyCode === 44 || event.keyCode === 46) &&
        ((event.currentTarget.value.includes('.') || event.currentTarget.value.includes(',')))) {
        event.preventDefault();
        return false;
    }

    if ((event.keyCode === 45) && (event.currentTarget.value.includes('-') || currsorPosition !== 0)) {
        event.preventDefault();
        return false;
    }

    // Allow: backspace, delete
    if ((event.keyCode === 46 || event.keyCode === 8) ||
        //Allow -
        ((event.keyCode === 45 || event.keyCode === 109)) ||
        // Allow: . ,
        (event.keyCode === 188 || event.keyCode === 190 || event.keyCode === 110) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39) ||
        (event.keyCode >= 48 && event.keyCode <= 57)) {

        return true;
    }
    else {
        event.preventDefault();
        return false;
    }
}

function _isKeyDown(event, key) {
    var isFirefox = typeof InstallTrigger !== 'undefined';
    var isChrome = !!window.chrome && !!window.chrome.webstore;

    if (isFirefox) {
        event.keyCode = event.charCode;
    }

    return event.keyCode === key;
}

function _pnumber(event) {
    var isFirefox = typeof InstallTrigger !== 'undefined';
    var isChrome = !!window.chrome && !!window.chrome.webstore;

    if (isFirefox) {
        event.keyCode = event.charCode;
    }

    //allow only 1 [,] or [.]
    var currsorPosition = event.currentTarget.value.slice(0, event.currentTarget.selectionStart).length;

    if ((event.keyCode === 44 || event.keyCode === 46) &&
        ((event.currentTarget.value.includes('.') || event.currentTarget.value.includes(',')))) {
        event.preventDefault();
        return false;
    }

    // Allow: backspace, delete
    if ((event.keyCode === 46 || event.keyCode === 8) ||
        // Allow: . ,
        (event.keyCode === 188 || event.keyCode === 190 || event.keyCode === 110) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39) ||
        (event.keyCode >= 48 && event.keyCode <= 57)) {

        return true;
    }
    else {
        event.preventDefault();
        return false;
    }
}

function _integer(event) {
    var isFirefox = typeof InstallTrigger !== 'undefined';
    var isChrome = !!window.chrome && !!window.chrome.webstore;

    if (isFirefox) {
        event.keyCode = event.charCode;
    }

    //allow only 1 [,] or [.]
    var currsorPosition = event.currentTarget.value.slice(0, event.currentTarget.selectionStart).length;

    if ((event.keyCode === 45) && (event.currentTarget.value.includes('-') || currsorPosition !== 0)) {
        event.preventDefault();
        return false;
    }

    // Allow: backspace, delete
    if ((event.keyCode === 46 || event.keyCode === 8) ||
        //Allow -
        ((event.keyCode === 45 || event.keyCode === 109)) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39) ||
        (event.keyCode >= 48 && event.keyCode <= 57)) {

        return true;
    }
    else {
        event.preventDefault();
        return false;
    }
}

function _pinteger(event) {
    var isFirefox = typeof InstallTrigger !== 'undefined';
    var isChrome = !!window.chrome && !!window.chrome.webstore;

    if (isFirefox) {
        event.keyCode = event.charCode;
    }
    if ((event.keyCode >= 35 && event.keyCode <= 39) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode > 95 && event.keyCode < 112) || event.charCode == 0 /*backspace and delete for mozilla*/) {
        return true;
    }
    else {
        event.preventDefault();
        return false;
    }
}

function _applyPinteger(element) {
    $(element).keypress(function (event) {
        return _pnumber(event);
    });
}

function applyCommonEvents() {
    if (typeof ($) === undefined) {
        throw "Need jquery!!!!";
    }

    $(".trigger").each(function (i, element) {
        $(element).click(function () {
            $("#" + $(element).attr("data-target")).trigger($(element).attr("data-trigger"));
        });
    });

    $(".navigate").each(function (i, element) {
        $(element).click(function () {
            document.location.href = $(element).attr("data-target");
        });
    });

    $(".toggler").each(function (i, element) {
        if ($(element).attr("data-visible", "false")) {
            $("#" + $(element).attr("data-target")).css("display", "none");
        }
        $(element).click(function () {
            $("#" + $(element).attr("data-target")).fadeToggle({
                duration: $(element).attr("data-time"),
                done: function (animation, jumpedToEnd) {
                    if ($("#" + $(element).attr("data-target")).is(":visible")) {
                        $(element).attr("data-visible", "true");
                    }
                    else {
                        $(element).attr("data-visible", "false");
                    }
                }
            });
        });
        $(document).click(function () {
            if ($(element).attr("data-visible") === "true") {
                if ($("#" + $(element).attr("data-target") + ":hover").length === 0) {
                    $("#" + $(element).attr("data-target")).fadeOut($(element).attr("data-time"));
                    $(element).attr("data-visible", "false");
                }
            }
        });
    });

    $('.number').keypress(function (event) {
        return _number(event);
    });

    $('.pnumber').keypress(function (event) {
        return _pnumber(event);
    });

    $('.integer').keypress(function (event) {
        return _integer(event);
    });

    $('.pinteger').keypress(function (event) {
        return _pinteger(event);
    });

    if (typeof (siteModule) !== undefined) {
        siteModule.showLoading = function () {
            $("#loading").show();
        }
        siteModule.hideLoading = function () {
            $("#loading").hide();
        }
    }
}

function bindPhoneNumberEvents(containerId) {
    if (!containerId) {

        $(".phonenumber-prefix").each(function (i, element) {
            $(element).select2();

        });
        return;
    }

}

function _normalizeStatus(status) {
    if (status == undefined || status == null || typeof (status) !== "number") { return undefined; }
    if (status === 0) { return 0; }
    if (status === 1) { return 1; }

    return Math.log2(_getMsb(status)) + 1;
}

function _denormalizeStatus(status) {
    if (status == undefined || status == null || typeof (status) !== "number") { return undefined; }
    if (status === 0) { return 0; }
    if (status === 1) { return 1; }

    return Math.pow(2, status);
}

function processEscaped(text) {
    if (!text) {
        return null;
    }

    return unescape(escape(text));
}

//########### PHONE NUMBER SCRIPTS #############

var _pFilterEventHandler = null;

function _pKeyDown(element) {
    $(element).attr("data_filter_time", new Date().getTime());
}

function _pFilterFunc(root) {
    var filterVal = $(root).val();

    $($(root).siblings(".phonenumber-prefix-body")[0]).children().each(function (i, element) {
        var $text = $($(element).children(".phonenumber-prefix-text")[0]);
        if (!$text) {
            return;
        }

        var oldVisibleVal = $(element).attr("data_visible");
        if (!filterVal || filterVal.trim() === "" && !oldVisibleVal) {
            $(element).attr("data_visible", true);
        }
        else {
            var text = $text.text();
            if (text.toLowerCase().indexOf(filterVal.trim().toLowerCase()) >= 0) {
                $(element).attr("data_visible", true);
            }
            else {
                $(element).attr("data_visible", false);
            }
        }
    });
}

function _pFilter(element) {
    var lastUpdateTime = parseInt($(element).attr("data_filter_time"));
    var now = new Date().getTime();

    if (now - lastUpdateTime > 300) {

        _pFilterFunc(element);
        console.log("filter-" + now);
        return;
    }

    if (_pFilterEventHandler) {
        clearTimeout(_pFilterEventHandler);
        _pFilterEventHandler = null;
    }

    _pFilterEventHandler = setTimeout(function () {
        _pFilter(element);
    }, 100);
}

function _pFilterToggleAttr(shouldClick) {
    if (shouldClick != undefined && shouldClick != null && !shouldClick) {
        return;
    }

    $element = $($(this).children()[0]);
    if (!$element) {
        return;
    }

    var visible = $element.attr("data_visible");
    if (!visible || visible === "false") {
        $element.attr("data_visible", "true")
    }
    else {
        $element.attr("data_visible", "false")
    }

    var $input = $element.children("input[type='text']");
    $input.val("");

    if (!visible || visible === "false") {
        $input.focus();
    }

    _pFilterFunc($input);
}

function _pSelect(element) {
    var $select = $($(element).parents(".phonenumber-prefix-select")[0]);
    var $val = $($select.children(".phonenumber-val")[0]);
    $val.val($(element).attr("value")).change();
    _pFilterToggleAttr.bind($select[0], "data_visible", "true", "false")();
}

//#############################################
function _isObservable(val) {
    return typeof (val) === "function" && val.name === "observable";
}

function __UpdateObject(obj, raw, parentKey, index) {
    var changedProps = [];

    for (var key in obj) {
        if (raw[key] == undefined) {
            continue;
        }

        var isKo = ko.isObservable(obj[key]) && !ko.isComputed(obj[key]);;
        var objVal = isKo ? obj[key]() : obj[key];
        var isArray = Array.isArray(objVal);

        if (!isKo && typeof (objVal) === "function") {
            continue;
        }

        var pKey = parentKey ? parentKey + "/" + key : key;
        if (index) {
            pKey += "[" + index + "]";
        }

        if (Array.isArray(raw[key])) {
            if (objVal === null || objVal === undefined) {
                if (isKo) {
                    obj[key](_copy(raw[key]));
                }
                else {
                    obj[key] = _copy(raw[key]);
                }

                changedProps.push(pKey);
            }
            else if (isArray) {
                if (objVal.length !== raw[key].length) {
                    objVal.length = 0;
                    objVal.addAggregated(_copy(raw[key]));

                    if (isKo) {
                        obj[key].valueHasMutated(); //trigger ko change event
                    }

                    pKey += "{" + objVal.length + "}";
                    changedProps.push(pKey);
                }
                else {
                    for (var i = 0; i < raw[key].length; i++) {
                        var oProps = __UpdateObject(obj[key], raw[key], pKey, i);

                        if (oProps && oProps.length) {
                            changedProps.push(pKey + "[" + i + "]");
                            for (var i = 0; i < oProps.length; i++) {
                                changedProps.push(oProps[i]);
                            }
                        }
                    }
                }
            }
        }
        else if (typeof objVal !== "object") {
            if (raw[key] !== objVal) {
                if (isKo) {
                    obj[key](raw[key]);
                }
                else {
                    obj[key] = raw[key];
                }

                changedProps.push(pKey);
            }
        }
        else if (typeof raw[key] === "object") {
            var oProps = __UpdateObject(obj[key], raw[key], pKey);

            if (oProps && oProps.length) {
                changedProps.push(pKey);
                for (var i = 0; i < oProps.length; i++) {
                    changedProps.push(oProps[i]);
                }
            }
        }
        else {
            if (isKo) {
                obj[key](raw[key]);
            }
            else {
                obj[key] = raw[key];
            }

            changedProps.push(pKey);
        }
    }

    return changedProps;
}

function UpdateObject(obj, raw) {
    if (typeof (obj) !== "object" ||
        typeof (raw) !== "object") {
        return "NaO";
    }

    return __UpdateObject(obj, raw);
}

function _queryObjectsChanges(objects, props) {
    if (!objects || !props || !Array.isArray(props) || !Array.isArray(objects) || props.length == 0 || objects.length <= 1) {
        return [];
    }

    var result = [];

    var rootObject = objects[0];
    objects = objects.splice(1, objects.length - 1);

    var propName = null;
    var prop = null;
    var rootProp = null;
    var isObservable = false;
    var isArray = false;
    var hasChanged = false;

    objects.forEach(function (object) {
        hasChanged = false;

        for (var i = 0; i < props.length; i++) {
            propName = props[i];
            prop = object[propName];
            rootPorp = rootObject[propName];

            isObservable = _isObservable(prop);
            isArray = Array.isArray(prop);

            if (isArray) {
                if (!Array.isArray(rootProp)) {
                    result.push(propName);
                    hasChanged = true;
                    break;
                }
                else if (rootProp.length !== prop.length) {
                    result.push(propName);
                    hasChanged = true;
                    break;
                }
                else {
                    continue;
                }
            }
            else if (isObservable) {

                prop = prop();

                if (_isObservable(rootProp)) {
                    rootProp = rootProp();
                    hasChanged = true;
                    break;
                }

                if (prop !== rootProp) {
                    result.push(propName);
                    hasChanged = true;
                    break;
                }

            }
            else if (prop !== rootProp) {
                result.push(propName);
                break;
            }
        }

        if (hasChanged) {
            return true; //this will break inside the forEach method
        }

    });

    return result;
}

Array.prototype.groupByProp = function (propName) {
    var groups = [];

    for (var i = 0; i < this.length; i++) {
        var element = this[i];

        if (!element) {
            continue;
        }

        var group = groups.first(function (e) {
            return compareByPropEx(e, element, "Key", propName);
        });

        if (!group) {
            group = {
                Key: element[propName],
                Items: []
            };

            groups.push(group);
        }

        group.Items.push(element);

    }

    return groups;
}

function getValue(prop) {
    if (_isObservable(prop)) {
        return prop();
    }

    return prop;
}

function compareByProp(self, other, propName) {
    if (self[propName] == null ||
        self[propName] == undefined ||
        other[propName] == null ||
        other[propName] == undefined) {
        return false;
    }

    var myValue = _isObservable(self[propName]) ? self[propName]() : self[propName];
    var otherValue = _isObservable(other[propName]) ? other[propName]() : other[propName];

    return myValue === otherValue;
}

function compareByPropEx(self, other, myPropName, otherPropName) {
    if (self[myPropName] == null ||
        self[myPropName] == undefined ||
        other[otherPropName] == null ||
        other[otherPropName] == undefined) {
        return false;
    }

    var myValue = _isObservable(self[myPropName]) ? self[myPropName]() : self[myPropName];
    var otherValue = _isObservable(other[otherPropName]) ? other[otherPropName]() : other[otherPropName];

    return myValue === otherValue;
}

function compareByProp(self, other, propName) {
    if (self[propName] == null ||
        self[propName] == undefined ||
        other[propName] == null ||
        other[propName] == undefined) {
        return false;
    }

    var myValue = _isObservable(self[propName]) ? self[propName]() : self[propName];
    var otherValue = _isObservable(other[propName]) ? other[propName]() : other[propName];

    return myValue === otherValue;
}

function compareByPropEx(self, other, myPropName, otherPropName) {
    if (self[myPropName] == null ||
        self[myPropName] == undefined ||
        other[otherPropName] == null ||
        other[otherPropName] == undefined) {
        return false;
    }

    var myValue = _isObservable(self[myPropName]) ? self[myPropName]() : self[myPropName];
    var otherValue = _isObservable(other[otherPropName]) ? other[otherPropName]() : other[otherPropName];

    return myValue === otherValue;
}

function _genericSwitch(e, boundCallback) {
    var $switch = $(e).parent();

    $switch.children().each(function (i, c) {
        if (c !== e) {
            $(c).attr("data-selected", false);
        }
    });

    var triggerCallback = $(e).attr("data-selected") == "false" || !$(e).attr("data-selected");

    $(e).attr("data-selected", true);

    if (triggerCallback && (typeof (boundCallback) == "function")) {
        boundCallback();
    }
}

function ShowLoading() {
    $('.loading').css('display', 'inline-block')
}

function HideLoading() {
    $('.loading').css('display', 'none')
}


function validateAjaxForm(formName) {
    var $form = $("#" + formName);

    $form.unbind();
    $form.data("validator", null);
    $.validator.unobtrusive.parse($form);
    $form.validate();

    return $form.valid();
}

function validateForm(formName) {
    var $form = $("#" + formName);
    $form.validate();
    return $form.valid();
};
