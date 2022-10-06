// Register controller
var category = angular.module('DAGStoreHome.category');
category.controller('categoryController', categoryController);

// Controller
function categoryController($scope, apiService, $stateParams) {

    console.log("okslf")
    // Load Category Detail
    $scope.category = {
    }
    $scope.LoadCategoryDetail = LoadCategoryDetail;
    function LoadCategoryDetail() {
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
            /*console.log($scope.category);*/
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadCategoryDetail();
}