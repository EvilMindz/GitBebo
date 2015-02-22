angular.module('vevo.factory', []).factory('vevoAPIfactory', function ($http) {

    var vevoAPI = {};

    vevoAPI.getAllVideos = function () {
        return $http({
            method: "GET",            
            async: true,            
            url: "http://localhost:15446/api/video/"

        });
    };

    vevoAPI.deleteVideoBy = function (title) {
        //var dt = { 'Key': title, 'VevoVideo': { 'Title': title, 'Description': "" } };

        return $http({
            method: "DELETE",
            //async: true,
            //data: {},            
            url: "http://localhost:15446/api/video/" + "?title=" + title

        });
    };

    vevoAPI.addVideoBy = function (title, description) {
        
        //var dt = { 'Key': title, 'VevoVideo': { 'Title': title, 'Description': description } };

        return $http({
            method: "POST",
            async: true,
            //contentType: "application/json; charset=utf-8",
            //data: dt,
            url: "http://localhost:15446/api/video/" + "?title=" + title + "&description=" + description
        });
    }

    return vevoAPI;
});