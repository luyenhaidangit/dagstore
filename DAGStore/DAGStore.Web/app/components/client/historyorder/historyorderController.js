// Register controller
var historyorder = angular.module('DAGStoreHome.historyorder');
historyorder.controller('historyorderController', historyorderController);

// Controller
function historyorderController($scope, apiService, sliderService, $rootScope, $timeout, $state) {
    //Load Page
    $rootScope.LoadPageSuccess = false;

    $scope.statusForm = 1;

    $scope.emailverifi = {}
    $scope.SendCodeSuccess = false;
    $scope.customerExist = false;
    $scope.notFindExist = false;

    $scope.SendCode = SendCode;
    function SendCode() {
        apiService.get("/customer/FindCustomerExist?email=" + $scope.emailverifi.email, null, function (success) {
            $scope.customerExist = success.data;
            $scope.notFindExist = $scope.customerExist == false ? true : false;
            if ($scope.customerExist) {
                $scope.statusForm = 2;
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
        }, function (error) {
            console.log("không thành công!")
        })
    }

    $scope.ReturnEmailForm = ReturnEmailForm;
    function ReturnEmailForm() {
        $scope.statusForm = 1;
        $scope.notFindExist = false;
    }
    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
