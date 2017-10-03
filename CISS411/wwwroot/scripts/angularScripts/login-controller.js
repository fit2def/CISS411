(function(){
    var app = angular.module("CISS411-App");

    var LoginController = function (validationService) {
        var vm = this;
        vm.invalidCredentials = false;

        vm.login = function () {
            validationService.validate(
                {
                    email: vm.email,
                    password: vm.password
                },
                vm.invalidCredentials
            );
        };
        
    };

    app.controller("LoginController",
        ["validationService", LoginController]);
}());