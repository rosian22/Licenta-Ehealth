var FoodViewModel = function () {
    var self = this;

    self.FoodList = ko.observableArray();
    self.FilterTerm = ko.observable();

    self.Init = () => {
        showLoading();
        self.GetFoods();
    }

    self.Filter = (text) => {
        showLoading();
        self.GetFoods(text);
    }

    self.GetFoods = (text) => {
        ajaxHelper.get(
            '/Food/GetFoodItems',
            {
                term: text
            },
            function (foodList) {
                var updatedList = [];
                foodList.forEach((food) => {
                    updatedList.push(new Food(food));
                });

                self.FoodList(updatedList);
                hideLoading();
            },
            function () {
                showError('Failed to get food items');
                hideLoading();
            }
        );
    }

    self.ShowCreateModal = () => {
        $('.food-item-modal').modal('show');
    }

    self.HideCreateModal = () => {
        $('.food-item-modal').modal('hide');
    }

};

var Food = function (raw) {
    var self = this;

    self.Id = ko.observable(raw.Id);
    self.Name = ko.observable(raw.Name);
    self.PictureUrl = ko.observable(raw.PictureUrl);
};

var FoodVM = null;