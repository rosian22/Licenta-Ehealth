var CreateExerciseViewModel = function () {
    var self = this;

    self.Id = ko.observable();
    self.MuscleGroupId = ko.observable();
    self.PictureUrl = ko.observable();
    self.Description = ko.observable();
    self.VideoUrl = ko.observable();

    self.Delete = () => {
        showLoading();
        ajaxHelper.post(
            '/Exercise/Delete',
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
        data.append('ExercisesId', self.Id());
        data.append('MuscleGroupId', self.MuscleGroupId());
        data.append('PictureUrl', document.getElementById('exercises-photo-thumbnail').file[0]);
        data.append('VideoUrl', self.VideoUrl());
        data.append('Description', self.Description());

        showLoading();
        ajaxHelper.post(
            "/Exercise/Save",
            data,
            (response) => {
                if (response && response.Success) {

                    self.Init();
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

    self.Init = () => {
        ajaxHelper.get(
            '/Exercise/Details',
            (response) => {

                if (response && response.Success) {
                    let data = response.Data;
                    self.SetData(data);
                    showSuccess();
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

    self.SetData = (data) => {

        self.Id(data.Id);
        self.MuscleGroupId(data.MuscleGroupId);
        self.PictureUrl(data.PictureUrl);
        self.Description(data.Description);
        self.VideoUrl(data.VideoUrl);
    }
}

var ExerciseVM = null;