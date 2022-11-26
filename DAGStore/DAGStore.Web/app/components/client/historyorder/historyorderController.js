// Register controller
var historyorder = angular.module('DAGStoreHome.historyorder');
historyorder.controller('historyorderController', historyorderController);

// Controller
function historyorderController($scope, apiService, sliderService, $rootScope, $timeout, $state) {
    //Load Page
    $rootScope.LoadPageSuccess = false;

    $scope.emailverifi = {}
    $scope.SendCodeSuccess = false;

    $scope.SendCode = SendCode;
    function SendCode() {
        apiService.get("/historyorder/sendcode?email=" + $scope.emailverifi.email, null, function (success) {
            $scope.SendCodeSuccess = true;
            apiService.get("/historyorder/getall", null, function (result) {
                console.log(result.data)
            }, function (error) {
                console.log("Get data fail");
            })
        }, function (error) {
            console.log("không thành công!")
        })
    }
    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
