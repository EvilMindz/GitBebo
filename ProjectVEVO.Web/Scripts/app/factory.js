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
        var dt = { 'titleToDelete': title };
        dt = JSON.stringify(dt);

        return $http({
            method: "DELETE",
            //async: true,            
            data: dt,
            //contentType: "application/json",
            url: "http://localhost:15446/api/video/"

        });
    };

    vevoAPI.addVideoBy = function (title, description) {
        
        var dt = { 'Key': title, 'VevoVideo': { 'Title': title, 'Description': description } };

        return $http({
            method: "PUT",
            async: true,            
            data: dt,
            url: "http://localhost:15446/api/video/"
        });
    }

    return vevoAPI;
});