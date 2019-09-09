var ExerciseViewModel = function () {
    var self = this;

    //FILTER OBSERVABLES
    self.Name = ko.observable();
    self.Description = ko.observable();
    //FILTER OBSERVABLES


    self.UpperExercises = ko.observableArray();
    self.MiddleExercises = ko.observableArray();
    self.LowerExercises = ko.observableArray();

    self.BackUpperExercises = ko.observableArray();
    self.BackMiddleExercises = ko.observableArray();
    self.BackLowerExercises = ko.observableArray();

    self.OnKeydown = (data, event) => {
        if (event.which === 13) {
            self.Init();
        }

        return true;
    }

    self.ResetListData = () => {
        self.UpperExercises([]);
        self.MiddleExercises([]);
        self.LowerExercises([]);

        self.BackUpperExercises([]);
        self.BackMiddleExercises([]);
        self.BackLowerExercises([]);
    }

    self.ActiveSectionGroupPaire = ko.observable({
        'upper-section': 'chest',
        'middle-section': 'rectus abdominis',
        'lower-section': 'quadriceps'
    });

    self.FilterExercisesByMuscle = (vm, event) => {
        var section = $($(event.target).parent().parent()).attr('data-tab');

        if (section === 'upper-section') {
            let newUpperList = [];
            let muscle = $(event.target).text();
            self.BackUpperExercises().forEach((ex) => {
                if (ex.MuscleGroupName() === muscle) {
                    newUpperList.push(ex);
                }
            });

            self.UpperExercises(newUpperList);
        }
        else if (section === 'middle-section') {
            let newMiddleList = [];
            let muscle = $(event.target).text();
            self.BackMiddleExercises().forEach((ex) => {
                if (ex.MuscleGroupName() === muscle) {
                    newMiddleList.push(ex);
                }
            });

            self.MiddleExercises(newMiddleList);

        } else if (section === 'lower-section') {
            let newLowerList = [];
            let muscle = $(event.target).text();
            self.BackLowerExercises().forEach((ex) => {
                if (ex.MuscleGroupName() === muscle) {
                    newLowerList.push(ex);
                }
            });

            self.LowerExercises(newLowerList);
        }
    }

    self.Init = () => {
        showLoading();
        self.ResetListData();
        ajaxHelper.get(
            '/Exercises/GetExerciseData',
            {
                ActiveSectionGroupPaire: self.ActiveSectionGroupPaire(),
                Name: $('.name-filter').val(),
                Description: $('.description-filter').val()
            },
            (response) => {
                if (response && response.Success) {
                    var data = response.Data;

                    var UpperExercisesList = [];
                    var MiddleExercisesList = [];
                    var LowerExercisesList = [];

                    data.UpperExercises.forEach((exercise) => {
                        UpperExercisesList.push(new Exercise(exercise));
                    });

                    data.MiddleExercises.forEach((exercise) => {
                        MiddleExercisesList.push(new Exercise(exercise));
                    });

                    data.LowerExercises.forEach((exercise) => {
                        LowerExercisesList.push(new Exercise(exercise));
                    });

                    self.UpperExercises(UpperExercisesList.filter((ex) => {
                        return ex.MuscleGroupName().toLocaleLowerCase() === self.ActiveSectionGroupPaire()['upper-section'].toLocaleLowerCase();
                    }));
                    self.MiddleExercises(MiddleExercisesList.filter((ex) => {
                        return ex.MuscleGroupName().toLocaleLowerCase() === self.ActiveSectionGroupPaire()['middle-section'].toLocaleLowerCase();
                    }));
                    self.LowerExercises(LowerExercisesList.filter((ex) => {
                        return ex.MuscleGroupName().toLocaleLowerCase() === self.ActiveSectionGroupPaire()['lower-section'].toLocaleLowerCase();
                    }));

                    self.BackUpperExercises(UpperExercisesList);
                    self.BackMiddleExercises(MiddleExercisesList);
                    self.BackLowerExercises(LowerExercisesList);
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

    self.ShowCreateModal = () => {
        $('#create-exercise-modal').modal('show');
    }

    self.HideCreateModal = () => {
        $('#create-exercise-modal').modal('hide');
    }
}

var Exercise = function (data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.PictureUrl = ko.observable(data.PictureUrl);
    self.Title = ko.observable(data.Name);
    self.Description = ko.observable(data.Description);
    self.MuscleGroupName = ko.observable(data.MuscleGroup.Name);
    self.VideoUrl = ko.observable(data.VideoUrl);

    self.ShowDetailsModal = () => {
        ajaxHelper.get(
            '/Exercises/GetExerciseDetails',
            {
                exerciseId: self.Id()
            },
            function (response) {
                if (response && response.Success) {
                    var data = response.Data;
                    CreateExerciseVM.Init(data);
                    $('.upload-style').css('opacity', 0);
                    $('#create-exercise-modal').modal('show');
                    return;
                }

                showError(`An error has ocurred while getting ${self.Title()} data`);
            },
            function () {
                showError(`An error has ocurred while getting ${self.Title()} data`);
            }
        );
    }

    self.OpenVideoModal = () => {
        YtVideoVM.SetVideoUrl(self.VideoUrl());
        YtVideoVM.OpenVideoModal();
    }
}

var ExerciseVM = null;