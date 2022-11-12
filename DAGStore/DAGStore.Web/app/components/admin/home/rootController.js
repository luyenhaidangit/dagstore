// Register controller
var app = angular.module('DAGStore');
app.controller('rootController', rootController);

// Controller
function rootController($scope) {
    $scope.LogOut = LogOut;
    function LogOut() {
        window.location = "/login"
    }
}
