var cDateTimeFormat24H = "DD.MM.YYYY HH:mm";
var cDateTimeFormat12H = "DD.MM.YYYY hh:mm tt";
var cDateFormat = "DD.MM.YYYY";
var ISODateFormat = "YYYY-MM-DD";
var GUID_EMPTY = "00000000-0000-0000-0000-000000000000";
var TAKE_COUNT = 10;
var EURO_SYMBOL = "\u20AC";
var DOLLAR_SYMBOL = "\u0024"

var DAY_MILLISECONDS = 1000 * 60 * 60 * 24;
var DAY_SECODS = 60 * 60 * 24;
var DAY_MINUTES = 60 * 24;
var DAY_HOURS = 24;

var MINUTE_MILLISECONDS = 1000 * 60;

var NO_PICTURE_SET_URL = "";

var MarketOrderEnum = {
    Buy: 0,
    Hold: 1,
    Sell: 2
};

var MarketOrders = [
    { Name: "Buy", Value: 0 },
    { Name: "Hold", Value: 1 },
    { Name: "Sell", Value: 2 },
];

var MarketPositionEnum = {
    Flat: 0,
    Other: 1,
};

var MarketPositions = [
    { Name: "Flat", Value: 0 },
    { Name: "Other", Value: 1 },
];

var PortfolioFlags = {
    None: 0,
    IsMain: 1 << 0,
    IsSecond: 1 << 1,
    IsFreezed: 1 << 2
};

var ContactTypeEnum = {
    Email: 0,
    Phone: 1,
}

var ContactType = [
    { Name: "Email", Value: 0 },
    { Name: "Phone", Value: 1 }
]

var AuthenticationTypeEnum = {
    Code: 0,
    Biometric: 1,
}

var AuthenticationType = [
    { Name: "Code", Value: 0 },
    { Name: "Biometric", Value: 1 }
]
