var CreateExerciseViewModel = function () {
    var self = this;

    self.Id = ko.observable();
    self.SelectedMuscleGroup = ko.observable();
    self.PictureUrl = ko.observable();
    self.Description = ko.observable();
    self.VideoUrl = ko.observable();
    self.Name = ko.observable();

    self.MuscleGroups = ko.observableArray();

    self.ClearData = () => {
        self.Id("");
        self.SelectedMuscleGroup("");
        self.Name("");
        self.Description("");
        self.PictureUrl("");
        self.VideoUrl("");
    }

    self.InitDropdown = () => {
        showLoading();
        ajaxHelper.getWithoutData(
            "/Exercises/GetMuscleGroups",
            (response) => {
                response = JSON.parse(response);
                if (response && response.Success) {
                    var data = response.Data;
                    self.MuscleGroups(data);
                    hideLoading();
                    return;
                }

                showError();
                hideLoading();
            },
            () => {
                showError();
                hideLoading();
            },
        );
    }

    self.Delete = () => {
        showLoading();
        ajaxHelper.post(
            '/Exercises/Delete',
            {
                Id: self.Id()
            },

            (response) => {

                if (response && response.Success) {
                    self.Init();
                    showSuccess('Exercise successfully deleted');
                    hideLoading;
                    return;
                }

                showError();
                hideLoading();
            },

            () => {
                showError();
                hideLoading();
            }
        );
    }

    self.Save = () => {

        var data = new FormData();
        data.append('Id', self.Id());
        data.append('MuscleGroupId', self.SelectedMuscleGroup());
        data.append('PictureUrl', document.getElementById('exercise-item-photo').files[0]);
        data.append('VideoUrl', self.VideoUrl());
        data.append('Description', self.Description());
        data.append('Name', self.Name());

        //var data = {};
        //data.Id = self.Id();
        //data.MuscleGroupId = self.SelectedMuscleGroup();
        //data.PictureUrl = document.getElementById('exercise-item-photo').files[0];
        //data.VideoUrl = self.VideoUrl();
        //data.Description = self.Description();
        //data.Name = self.Name();

        showLoading();
        ajaxHelper.postFile(
            "/Exercises/Save",
            data,
            (response) => {
                if (response && response.Success) {

                    ExerciseVM.Init();
                    $('#create-exercise-modal').modal('hide');
                    self.ClearData();
                    showSuccess('Successfully created Exercise');
                    hideLoading();
                    return;
                }

                showError();
                hideLoading();
            },
            () => {
                showError();
                hideLoading();
            }
        );
    }

    self.Init = (data) => {
        self.SetData(data);
    }

    self.SetData = (data) => {

        self.Id(data.Id);
        self.SelectedMuscleGroup(data.MuscleGroupId);
        self.PictureUrl(data.PictureUrl);
        self.Description(data.Description);
        self.VideoUrl(data.VideoUrl);
        self.Name(data.Name);
    }

    self.PresetPhoto = () => {
        var reader = new FileReader();

        reader.onload = function (e) {
            self.PictureUrl(e.target.result);
        }

        $('.upload-style').css('opacity', 0);

        reader.readAsDataURL(document.getElementById("exercise-item-photo").files[0]);
    }
}

var CreateExerciseVM = null;