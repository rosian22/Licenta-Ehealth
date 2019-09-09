var YoutubeVideoViewModel = function () {

    var self = this;

    self.VideoUrl = ko.observable();

    self.OpenVideoModal = () => {
        $('#video-modal').modal({
            blurring: true,
            closable: false
        }).modal('show');
    }

    self.CloseVideoModal = () => {
        $('#video-modal').modal('hide');
        self.VideoUrl('');
    }

    self.SetVideoUrl = (url) => {
        self.VideoUrl(url);
    }

}

var YtVideoVM = null;