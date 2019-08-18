var ExerciseViewModel = function () {
    var self = this;

    self.Name = ko.observable();
    self.Description = ko.observable();
    self.Exercises = ko.observableArray();
    self.ActiveSectionGroupPaire = ko.observable({
        'upper-section': 'chest',
        'middle-section': 'rectus abdominis',
        'lower-section': 'quadriceps'
    });

    self.Init = () => {
        showLoading();
        ajaxHelper.get(
            '/Exercise/GetExercises',
            {
                ActiveSectionGroupPaire: self.ActiveSectionGroupPaire(),
                Name: self.Name(),
                Description: self.Description()
            },
            (response) => {
                if (response && response.Success) {
                    var data = response.Data;
                    var exercisesList = [];
                    data.forEach((exercise) => {
                        exercisesList.push(new Exercise(exercise));
                    });

                    self.Exercises(exercisesList);
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

var Exercise = function (data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.PictureUrl = ko.observable(data.PictureUrl);
    self.Title = ko.observable(data.Title);
    self.Description = ko.observable(data.Description);
}

var ExerciseVM = null;