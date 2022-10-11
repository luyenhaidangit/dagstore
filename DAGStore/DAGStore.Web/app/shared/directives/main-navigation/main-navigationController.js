// Register controller
var app = angular.module("DAGStore.common");
app.controller("mainNavigationController", mainNavigationController);

// Controller
function mainNavigationController($scope, apiService) {
    // Get Data
    $scope.SiteMenu = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/category/getall", null, function (result) {

            $scope.SiteMenu = result.data;



        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

};