(function () {
    var app = angular.module("CISS411-App");

    var LoginController = function (validationService, $window) {
        var vm = this;
        vm.invalidCredentials = false;
      
            

        vm.onsubmit = function () {
            validationService.validate(
                {
                    email: vm.email,
                    password: vm.password
                })
                .then(success, error);
        };

        function success(response) {
            $window.location.href = "/Home/Index";
        }

        function error(response) {
            console.log("there was a problem:", response)
            vm.invalidcredentials = true;
        }

    };

    app.controller("LoginController",
        ["validationService", "$window", LoginController]);
}());