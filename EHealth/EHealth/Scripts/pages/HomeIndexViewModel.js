var HomeIndexViewModel = function () {
    var self = this;

    self.AspNetUserId           = ko.observable();
    self.UserId                 = ko.observable();
    self.ProfilePictureUrl      = ko.observable();
    self.BodyWeight             = ko.observable();
    self.CaloriesBurned         = ko.observable();
    self.GoalsAchived           = ko.observable();
    self.Achivements            = ko.observable();
    self.DailyGoal              = ko.observable();
    self.Email                  = ko.observable();
    self.FullName               = ko.observable();
    self.BirthDay               = ko.observable();

    self.DailyMin               = ko.observable();
    self.WeeklyMin              = ko.observable();
    self.MonthlyMin             = ko.observable();

    self.Init = function () {
        ajaxHelper.get(
            '/User/GetUserData',
            function (response) {
                if (response && response.Success) {
                    let data = response.Data;
                    self.SetUserData(data);
                }
            }
        );
    }

    self.SetUserData = function (data) {
         self.AspNetUserId           (data.AspNetUserId        );
         self.UserId                 (data.UserId              );
         self.ProfilePictureUrl      (data.ProfilePictureUrl   );
         self.BodyWeight             (data.BodyWeight          );
         self.CaloriesBurned         (data.CaloriesBurned      );
         self.GoalsAchived           (data.GoalsAchived        );
         self.Achivements            (data.Achivements         );
         self.DailyGoal              (data.DailyGoal           );
         self.Email                  (data.Email               );
         self.FullName               (data.FullName            );
         self.BirthDay               (data.BirthDay            );
         self.DailyMin               (data.DailyMin            );
         self.WeeklyMin              (data.WeeklyMin           );
         self.MonthlyMin             (data.MonthlyMin          );
    }

}

var HomeIndexVM = null;