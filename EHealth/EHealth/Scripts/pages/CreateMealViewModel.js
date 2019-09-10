var CreateMealViewModel = function () {
    var self = this;

    self.Id = ko.observable();
    self.PictureUrl = ko.observable();
    self.Name = ko.observable();
    self.Foods = ko.observableArray();
    self.SelectedFoods = ko.observableArray();
    self.Description = ko.observable();
    self.Quantity = ko.observable();
    self.FoodsWithQuantity = ko.observableArray();


    self.ClearData = () => {
        self.Id('');
        self.PictureUrl('');
        self.Name('');
        self.Foods([]);
        self.SelectedFoods([]);
        self.Description('');
    }

    self.Save = () => {
        showLoading();

        var data = new FormData();
        var foods = [];
        data.append('Id', self.Id());
        data.append('PictureUrl', document.getElementById('meal-item-photo').files[0]);
        data.append('Name', self.Name());
        data.append('Description', self.Description());
        data.append('SelectedFoodsJson', JSON.stringify(self.FoodsWithQuantity()));
        debugger;
        ajaxHelper.postFile(
            "/Meal/Save",
            data,
            (response) => {
                debugger;

                if (response && response.Success) {

                    hideLoading();
                    showError();
                    return;
                }

                hideLoading();
                showError();
            },
            () => {
                debugger;
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
            var newobj = {};
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
                    item['name'] = `${item.name} ${self.Quantity()} (g)`;
                });
                self.Foods(semanticObj);
            },
            () => {
                showError();
            }
        );
    }

    self.OnFoodItemAdded = (arr, value, name) => {
        if (typeof (name) === 'string') {
            let foodName = name.split(' ');
            self.FoodsWithQuantity.push({ Id: value, Name: foodName[0], Quantity: foodName[1] });
        } else if (typeof (name) === 'object') {
            name = value;
            let foodName = name.split(' ');
            var filteredArray = self.FoodsWithQuantity().filter((item) => {
                return item.Name !== foodName[0];
            });
            self.FoodsWithQuantity(filteredArray);
        }
    }
}

var CreateMealVM = null;

var Food = function (data, quantity) {
    this.name = data.name;
    this.value = data.value;
    this.quantity = quantity;
}