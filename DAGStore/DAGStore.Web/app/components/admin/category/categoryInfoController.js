// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryInfoController', categoryInfoController);

// Controller
function categoryInfoController($scope, apiService, notificationService, $stateParams, ckeditorService) {
    // Load category Detail
    $scope.category = {
    }
    $scope.LoadCategoryDetail = LoadCategoryDetail;
    function LoadCategoryDetail() {
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadCategoryDetail();

    // Load Parent Category
    $scope.parentCategory = {};
    $scope.categorys = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data.filter(x => x.ID !== $scope.category.ID);
            $scope.parentCategory = $scope.categorys.filter(x => x.ID === $scope.category.ParentCategoryID)[0];
            console.log($scope.category)
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");
}