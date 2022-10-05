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
















    
    //$scope.GetCategoryShowOnHomePage = GetCategoryShowOnHomePage;
    //function GetCategoryShowOnHomePage() {
        
    //};
    //$scope.GetCategoryShowOnHomePage();

    //$scope.categorysShowOnHomePage = [];
    //apiService.get("/category/getcategoryshowonhomepage", null, function (result) {
    //    $scope.categorysShowOnHomePage = result.data;
    //    for (let i = 0; i < $scope.categorysShowOnHomePage.length; i++) {
    //        var id = $scope.categorysShowOnHomePage[i].ID;
    //        /*console.log(id);*/
    //        console.log(GetListChildCategory(id));

    //    }
    //}, function (error) {
    //    console.log("Get data fail");
    //})

    /*$scope.list = [];*/

    // Get List Child Category By ID
    //$scope.GetListChildCategory = GetListChildCategory;
    //function GetListChildCategory(id) {
    //    var config = {
    //        params: {
    //            id: id
    //        }
    //    }
    //    apiService.get("/category/getlistchildcategory", config, function (result) {
    //        $scope.list = result.data;
    //        //if ($scope.list[0].ParentCategoryID === id) {
    //        //    console.log($scope.list);
    //        //    break;
    //        //}    
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
        
    //};

   

    


    


};