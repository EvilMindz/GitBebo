angular.module('vevo.controllers', []).controller('maincontroller', function ($scope, vevoAPIfactory) {//injecting http and vevoAPIFactory services into main controller
    'use strict';


    //Initialize
    var init = function () {
        $scope.addNewVideo = false;

        //initialize var for angularjs Validation 
        $scope.formSubmitted = false;

        //TODO: Use interceptor to show/hide spinner
        $scope.showLoader = true;

        vevoAPIfactory.getAllVideos().success(function (response) {
            $scope.videosList = response;

            $scope.showLoader = false;
        });
    };
    
    ///Remove Video for persistence
    $scope.removeVideo = function (title) {
        
        var index = -1;

        var videos = eval($scope.videosList);
        for (var i = 0; i < videos.length; i++) {
            if (videos[i].vevoVideo.title === title) {
                index = i;
                break;
            }
        }

        if (index === -1) {
            toastr.error("Video " + title + " could not be deleted due to some unknown error!");
        }
        else {

            $scope.showLoader = true;

            vevoAPIfactory.deleteVideoBy($scope.videosList[index].vevoVideo.title).success(function (response) {

                $scope.videosList.splice(index, 1);

                toastr.success("Video " + title + " deleted successfully!");

                $scope.showLoader = false;

            }).error(function (response, status) {

                toastr.error("Error!");

                $scope.showLoader = false;
            });
        }                
    };

    ///Show Add Video Div conditionally
    $scope.showAddVideo = function () {
        toastr.info("Submit a new video to VEVO..");
        $scope.formSubmitted = false;
        $scope.title = "";
        $scope.description = "";
        $scope.addNewVideo = true;        
    };

    ///Add new video to persistence
    $scope.addVideo = function () {

        //Angularjs Page Validation
        $scope.formSubmitted = true;

        //Angularjs Page Validation
        if ($scope.vevoForm.$valid) {

            $scope.showLoader = true;

            vevoAPIfactory.addVideoBy($scope.title, $scope.description).success(function (response) {

                if (response === true) {
                    $scope.videosList.push({ 'key': $scope.title, 'vevoVideo': { 'title': $scope.title, 'description': $scope.description } });
                    toastr.success("Video " + $scope.title + " added successfully!");
                }
                else {
                    toastr.error("Video " + $scope.title + " could not be added due to error!");
                }

                $scope.showLoader = false;

            }).error(function (response, status) {
                toastr.error("Error!");

                $scope.showLoader = false;
            });

            $scope.addNewVideo = false;
        }
        //else {

        //    if ($scope.vevoForm.title.$error.required) {
        //        toastr.warning("Title is required.")
        //    }

        //    if ($scope.vevoForm.description.$error.required) {
        //        toastr.warning("Description is required.")
        //    }            
        //}
    };

    ///Cancel video add functionality
    $scope.cancel = function () {
        toastr.success("Canceled!");
        $scope.addNewVideo = false;        
    };

    //initialize
    init();

});