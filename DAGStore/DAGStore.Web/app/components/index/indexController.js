// Register controller
var index = angular.module('DAGStoreHome.index');
index.controller('indexController', indexController);

// Controller
function indexController($scope, apiService){
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
}
