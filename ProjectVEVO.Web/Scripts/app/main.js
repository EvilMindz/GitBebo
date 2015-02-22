angular.module('vevo.controllers', []).controller('maincontroller', function ($scope, vevoAPIfactory) {

    var init = function () {
        $scope.AddNewVideo = false;
    }

    init();
    
    vevoAPIfactory.getAllVideos().success(function (response) {
        $scope.videosList = response;
    });

    $scope.RemoveVideo = function (title) {
        //vevoAPIfactory.deleteVideoBy(videoId).success(function (response) {
        //    if (response === true) {
        //        $scope.videosList.splice(videoId,1)
        //        toastr.success("Video " + String(videoId) + " deleted successfully!");
        //    }
        //});

        var index = -1;

        var videos = eval($scope.videosList);
        for (var i = 0; i < videos.length; i++) {
            if (videos[i].VevoVideo.Title === title) {
                index = i;
                break;
            }
        }

        if (index === -1) {
            toastr.error("Video " + title + " could not be deleted due to some unknown error!");
        }
        else {
            vevoAPIfactory.deleteVideoBy($scope.videosList[index].VevoVideo.Title).success(function (response) {
                $scope.videosList.splice(index, 1);
                toastr.success("Video " + title + " deleted successfully!");
            });
        }                
    };

    $scope.ShowAdd = function () {
        toastr.info("Submit a new video to VEVO..");
        $scope.Title = "";
        $scope.Description = "";
        $scope.AddNewVideo = true;
    };

    $scope.AddVideo = function () {
        
        vevoAPIfactory.addVideoBy($scope.Title, $scope.Description).success(function (response) {

            if (response === true) {
                $scope.videosList.push({ 'Key': $scope.Title, 'VevoVideo': { 'Title': $scope.Title, 'Description': $scope.Description } });
                toastr.success("Video " + $scope.Title + " added successfully!");
            }
            else {
                toastr.error("Video " + $scope.Title + " could not be added due to error!");
            }
        }).error(function (xhr,status,response) {
            toastr.error("Error!");
        });

        $scope.AddNewVideo = false;
    };

    $scope.Cancel = function () {
        toastr.success("Canceled!");
        $scope.AddNewVideo = false;
    };

});