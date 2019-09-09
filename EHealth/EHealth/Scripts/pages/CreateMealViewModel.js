var CreateMealViewModel = function () {
    var self = this;

    self.Id = ko.observable();
    self.PictureUrl = ko.observable();
    self.Name = ko.observable();
    self.Calories = ko.observable();
    self.Foods = ko.observableArray();
    self.SelectedFoods = ko.observableArray();
    self.Description = ko.observable();
    self.Quantity = ko.observable();


    self.ClearData = () => {
        self.Id('');
        self.PictureUrl('');
        self.Name('');
        self.Calories('');
        self.Foods([]);
        self.SelectedFoods([]);
        self.Description('');
    }

    self.Save = () => {
        showLoading();
        ajaxHelper.postFile(
            "/Meal/Save",
            {
                Id: self.Id(),
                PictureUrl: self.PictureUrl(),
                Name: self.Name(),
                Calories: self.Calories(),
                Foods: self.Foods(),
                SelectedFoods: self.SelectedFoods(),
                Description: self.Description(),
            },
            (response) => {
                if (response && response.Success) {

                    hideLoading();
                    showError();
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

    self.PresetPhoto = () => {
        var reader = new FileReader();

        reader.onload = function (e) {
            self.PictureUrl(e.target.result);
        }

        $('.upload-style').css('opacity', 0);

        reader.readAsDataURL(document.getElementById("meal-item-photo").files[0]);
    }

    self.MakeSemanticObject = (data) => {
        var returnedObject = [];
        data.forEach(function (item) {
            var newobj = {}
            newobj['name'] = item.Name;
            newobj['value'] = item.Id;
            returnedObject.push(newobj);
        });

        return returnedObject;
    }

    self.Quantity.subscribe(() => {
        self.InitDropdown();
    });


    self.InitDropdown = () => {
        ajaxHelper.get(
            "/Meal/GetFoodList",
            {},
            (data) => {

                if (!self.Quantity()) {
                    self.Quantity('0');
                }

                var semanticObj = self.MakeSemanticObject(data);
                semanticObj.forEach((item) => {
                    item['quantity'] = self.Quantity();
                    item['name'] = `${item.name} ${self.Quantity()}(g)`;
                });
                self.Foods(semanticObj);
            },
            () => {
                showError();
            }
        );
    }


}

var CreateMealVM = null;

var Food = function (data, quantity) {
    this.name = data.name;
    this.value = data.value;
    this.quantity = quantity;
}