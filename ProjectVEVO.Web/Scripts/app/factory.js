'use strict';

angular.module('vevo.factory', []).factory('vevoAPIfactory', function ($http) {//api factory

    var vevoAPI = {};

    var vevoAPIURI = "http://localhost:15446/api/video/";

    vevoAPI.getAllVideos = function () {
        return $http({
            method: "GET",            
            async: true,            
            url: vevoAPIURI

        });
    };

    vevoAPI.deleteVideoBy = function (title) {        
        return $http({
            method: "DELETE",
            //async: true,
            //data: {},            
            //url: vevoAPIURI + "?title=" + title
            url: vevoAPIURI + title

        });
    };

    vevoAPI.addVideoBy = function (title, description) {        
        return $http({
            method: "POST",
            async: true,
            //contentType: "application/json; charset=utf-8",
            //data: dt,
            //url: vevoAPIURI + "?title=" + title + "&description=" + description
            url: vevoAPIURI + title + "/" + description
        });
    }

    return vevoAPI;
});