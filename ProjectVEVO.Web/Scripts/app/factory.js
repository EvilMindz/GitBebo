angular.module('Bebo.factory', []).factory('BeboAPIfactory', function ($http) {//api factory
    'use strict';

    //AngularJS Factory
    var beboAPI = {};

    var beboAPIURI = "http://localhost:15446/api/video/";

    //Api to GET all videos from persistence
    beboAPI.getAllVideos = function () {
        return $http({
            method: "GET",            
            async: true,            
            url: beboAPIURI

        });
    };

    //Api to DELETE a video title from persistence
    beboAPI.deleteVideoBy = function (title) {
        return $http({
            method: "DELETE",
            async: true,
            url: beboAPIURI + title

        });
    };

    //Api to POST add a new title and description for a video to persistence
    beboAPI.addVideoBy = function (title, description) {
        return $http({
            method: "POST",
            async: true,            
            url: beboAPIURI + title + "/" + description
        });
    };

    return beboAPI;
});