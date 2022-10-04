// Register controller
var app = angular.module("DAGStore.common");
app.controller("mainNavigationController", mainNavigationController);

// Controller
function mainNavigationController($scope, apiService) {
    // Get Data
    $scope.categorysShowOnHomePage = [];
    $scope.GetCategoryShowOnHomePage = GetCategoryShowOnHomePage;
    function GetCategoryShowOnHomePage() {
        apiService.get("/category/getcategoryshowonhomepage", null, function (result) {

            $scope.categorysShowOnHomePage = result.data;
            console.log($scope.categorysShowOnHomePage);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetCategoryShowOnHomePage();
};