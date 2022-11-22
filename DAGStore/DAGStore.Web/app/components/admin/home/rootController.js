// Register controller
var app = angular.module('DAGStore');
app.controller('rootController', rootController);

// Controller
function rootController($scope, $state) {
    $scope.LogOut = LogOut;
    function LogOut() {
        $state.go('login');
    }
}
