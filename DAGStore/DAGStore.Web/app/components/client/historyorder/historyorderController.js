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
    $scope.notCodeExist = false;

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

    $scope.SubmitForm = SubmitForm;
    function SubmitForm() {
        apiService.get("/historyorder/getall", null, function (result) {
            var data = result.data.data;
            console.log(data)
            

            var resultCode = data.filter((obj) => {
                return obj.Email === $scope.emailverifi.email && obj.Otp === $scope.emailverifi.code;
            })

           

            if (resultCode.length > 0) {
                $scope.statusForm = 3;
            } else {
                $scope.notCodeExist = true;
            }
        }, function (error) {
            console.log("Get data fail");
        })
    }
    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
