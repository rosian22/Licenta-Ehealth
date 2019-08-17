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
                    updatedList.push(new Food(food, self));
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
        $('#create-food-modal').modal('show');
    }

    self.HideCreateModal = () => {
        $('#create-food-modal').modal('hide');
    }

};

var Food = function (raw, parent) {
    var self = this;

    self.Id = ko.observable(raw.Id);
    self.Name = ko.observable(raw.Name);
    self.PictureUrl = ko.observable(raw.PictureUrl);
    self.Parent = parent;

    self.Delete = () => {
        ajaxHelper.post(
            "/Food/Delete",
            {
                FoodId: self.Id()
            },
            function (response) {
                if (response && response.Success) {
                    showSuccess("Successfully deleted food item");
                    self.Parent.Filter();
                    return;
                } else {
                    showError();
                }
            },
            function () {
                showError();
            }
        );
    }

    self.ShowDetailsModal = () => {
        ajaxHelper.get(
            '/Food/GetFoodDetails',
            {
                foodId: self.Id()
            },
            function (response) {
                if (response && response.Success) {
                    var data = response.Data;
                    CreateFoodVM.Init(data);
                    $('.upload-style').css('opacity', 0);
                    $('#create-food-modal').modal('show');
                    return;
                }

                showError(`An error has ocurred while getting ${self.Name()} data`);
            },
            function () {
                showError(`An error has ocurred while getting ${self.Name()} data`);
            }
        );
    }
};

var FoodVM = null;