var MealViewModel = function () {
    var self = this;

    self.Meals = ko.observableArray();
    self.Init = () => {
        showLoading();
        ajaxHelper.get(
            "/Meal/GetMeals",
            {},
            (response) => {
                if (response && response.Success) {
                    let data = response.Data;
                    debugger;
                    let mealArr = [];

                    for (var i = 0; i < data.length; i++) {
                        mealArr.push(new Meal(i + 1, data[i]));
                    }

                    self.Meals(mealArr);
                    hideLoading();
                    return;
                }

                hideLoading();
                showError();
            },
            () => {
                hideLoading();
                showError();
            }

        );
    }
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