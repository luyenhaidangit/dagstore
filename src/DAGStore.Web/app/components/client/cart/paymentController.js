// Register controller
var product = angular.module('DAGStoreHome.cart');
product.controller('paymentController', paymentController);

// Controller
function paymentController($scope, apiService, $stateParams, $filter, $rootScope, notificationService, alertService, $window, $location) {
    //Load Page
    $rootScope.LoadPageSuccess = true;
    // Get Data

    $scope.payment = {}

    apiService.get("/payment/PaymentConfirm?" + $location.absUrl().split('?')[1], null, function (result) {
        $scope.payment = result.data;
        console.log($scope.payment)
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })
    

    //Load Page
    //angular.element(function () {
    //    $timeout(function () {
    //        $rootScope.LoadPageSuccess = true;
    //    }, 600);
    //});
}