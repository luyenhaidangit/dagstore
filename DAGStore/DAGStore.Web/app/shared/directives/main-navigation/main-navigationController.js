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
            /*console.log($scope.categorysShowOnHomePage);*/
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetCategoryShowOnHomePage();

    // Get List Child Category By ID
    $scope.GetListChildCategory = GetListChildCategory;
    function GetListChildCategory(id) {
        var config = {
            params: {
                id: id
            }
        }
        var list = [];
        apiService.get("/category/getlistchildcategory", config, function (result) {
            list = result.data;
            console.log(list);
            return list;
        }, function (error) {
        
            console.log("Get data fail");
        })
    };
    
   /* $scope.GetListChildCategory(8);*/
    
    
};