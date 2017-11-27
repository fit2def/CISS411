(function () {
    var validationService = function ($http) {
        var validate = function (loginViewModel) {
            return $http.post("/Account/Login", loginViewModel, { headers: new Headers({ 'Content-Type': 'application/json' })});
        };


        return {
            validate: validate
        };
    };
    var app = angular.module("CISS411-App");
    app.factory("validationService", validationService);
}());