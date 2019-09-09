var MealViewModel = function () {
    var self = this;

    self.Meals = ko.observableArray();


}

var Meal = function (counter, data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.CounterNumber = ko.observable(counter);
    self.CounterText = ko.computed(() => {
        if (!self.CounterNumber()) {
            return "NOT SET";
        }
        return `Meal ${self.CounterNumber()}`;
    });

    self.PictureUrl = ko.observable(data.PictureUrl);
    self.Name = ko.observable(data.Name);
    self.Calories = ko.observable(data.Calories);
    self.CaloriesText = ko.computed(() => {
        if (!self.Calories()) {
            return 'NOT SET';
        }
        return `${self.Calories()} calories`;
    });
}

var MealVM = null;