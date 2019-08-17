var CreateFoodViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Photo = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.Carbohydrates = ko.observable();
    self.Sugar = ko.observable();
    self.Fibre = ko.observable();
    self.Proteins = ko.observable();
    self.Fats = ko.observable();
    self.Calories = ko.observable();
    self.Grams = ko.observable();

    self.Save = () => {
        var data = new FormData();
        data.append('Id', self.Id());
        data.append("Photo", document.getElementById("food-item-photo").files[0]);
        data.append("Name", self.Name());
        data.append("Description", self.Description());
        data.append("Carbohydrates", self.Carbohydrates());
        data.append("Sugar", self.Sugar());
        data.append("Fibre", self.Fibre());
        data.append("Proteins", self.Proteins());
        data.append("Fats", self.Fats());
        data.append("Grams", self.Grams());
        data.append("Calories", self.Calories());

        showLoading();
        ajaxHelper.postFile(
            "/Food/Save",
            data,
            function (response) {
                if (response && response.Success) {
                    showSuccess("Successfully created food item");
                    $('#create-food-modal').modal('hide');
                    FoodVM.Init();
                    hideLoading();
                    return;
                } else {
                    showError();
                    hideLoading();
                }
            },
            function () {
                showError();
                hideLoading();
            }
        );
    }

    self.Init = (data) => {
        self.Id(data.Id);
        self.Photo(data.Photo);
        self.Name(data.Name);
        self.Description(data.Description);
        self.Carbohydrates(data.Carbohydrates);
        self.Sugar(data.Sugar);
        self.Fibre(data.Fibre);
        self.Proteins(data.Proteins);
        self.Fats(data.Fats);
        self.Calories(data.Calories);
        self.Grams(data.Grams);
    }

    self.ClearData = () => {
        self.Id("");
        self.Photo("");
        self.Name("");
        self.Description("");
        self.Carbohydrates("");
        self.Sugar("");
        self.Fibre("");
        self.Proteins("");
        self.Fats("");
        self.Calories("");
        self.Grams("");
    }

    self.PresetPhoto = () => {
        var reader = new FileReader();

        reader.onload = function (e) {
            self.Photo(e.target.result);
        }

        $('.upload-style').css('opacity', 0);

        reader.readAsDataURL(document.getElementById("food-item-photo").files[0]);
    }

}

var CreateFoodVM = null;