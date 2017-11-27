(function () {
    var modalService = function () {

        function open() {
            var modal = document.getElementById("modal");
           // modal.
        }

        function close() {

        }

        return {
            open: open,
            close: close
        };
    };
    var app = angular.module("CISS411-App");
    app.factory("modalService", modalService);
}());