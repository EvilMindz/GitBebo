angular.module('vevo.factory', []).factory('vevoAPIfactory', function ($http) {//api factory
    'use strict';

    //AngularJS Factory
    var vevoAPI = {};

    var vevoAPIURI = "http://localhost:15446/api/video/";

    //Api to GET all videos from persistence
    vevoAPI.getAllVideos = function () {
        return $http({
            method: "GET",            
            async: true,            
            url: vevoAPIURI

        });
    };

    //Api to DELETE a video title from persistence
    vevoAPI.deleteVideoBy = function (title) {        
        return $http({
            method: "DELETE",
            async: true,
            url: vevoAPIURI + title

        });
    };

    //Api to POST add a new title and description for a video to persistence
    vevoAPI.addVideoBy = function (title, description) {
        return $http({
            method: "POST",
            async: true,            
            url: vevoAPIURI + title + "/" + description
        });
    };

    return vevoAPI;
});