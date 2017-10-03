(function() {
    var validationService = function($http, $window) {
        var validate = function (loginObject, invalidCredentials) {
            $http.post("/AccountController/Login", loginObject)
                .success(function (response) {
                    
                })
                .error(function (response) {
                    console.log("There was a problem:", response)
                    invalidCredentials = true;
                });
        };

        return {
            validate: validate
        };
    };
    var app = angular.module("CISS411-App");
    app.factory("validationService", validationService);
}());