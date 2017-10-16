(function () {
    var validationService = function ($http) {
        var validate = function (loginObject) {
            return $http.post("/Account/Login", loginobject);
        };

        return {
            validate: validate
        };
    };
    var app = angular.module("CISS411-App");
    app.factory("validationService", validationService);
}());