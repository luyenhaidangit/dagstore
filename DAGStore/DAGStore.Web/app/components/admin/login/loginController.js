// Register controller
var app = angular.module('DAGStoreLogin');
app.controller('loginController', loginController);

// Controller
function loginController($scope) {
    $scope.Login = Login;
    function Login() {
        window.location = "/admin"
    }
}
