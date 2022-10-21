// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandInfoController', brandInfoController);

// Controller
function brandInfoController($scope, apiService, notificationService, $stateParams) {
    // Load brand Detail
    $scope.brand = {
    }
    $scope.LoadBrandDetail = LoadBrandDetail;
    function LoadBrandDetail() {
        apiService.get("/brand/getbyid/" + $stateParams.id, null, function (result) {
            $scope.brand = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadBrandDetail();
}