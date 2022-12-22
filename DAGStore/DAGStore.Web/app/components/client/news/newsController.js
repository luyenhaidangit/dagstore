// Register controller
var news = angular.module('DAGStoreHome.news');
news.controller('newsController', newsController);

// Controller
function newsController($scope, apiService, $stateParams, $filter, $sce, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;

    // Load Product Detail
    $scope.news = {
    }

    /* $scope.category =*/
    apiService.get("/news/getbyid/" + $stateParams.id, null, function (result) {
        $scope.news = result.data;
        console.log($scope.news)
        $scope.Message = $sce.trustAsHtml($scope.news.Content);

        ////Get Suggest Product Category
        //// Get Product Suggest Category
        //apiService.get("/product/GetProductsByCategory?id=" + $scope.product.CategoryID, null, function (result) {
        //    $scope.productSuggestCategory = result.data.filter((obj) => {
        //        return obj.IDProduct !== $scope.product.ID;
        //    });
        //    console.log($scope.productSuggestCategory)

        //}, function (error) {
        //    console.log("Không thể tải dữ liệu");
        //})
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    //// Load news Detail
    //$scope.news = {
    //}
    //$scope.LoadnewsDetail = LoadnewsDetail;
    //function LoadnewsDetail() {
    //    apiService.get("/news/getbyid/" + $stateParams.id, null, function (result) {
    //        $scope.news = result.data;
    //    }, function (error) {
    //        notificationService.displaySuccess("Không thể tải dữ liệu");
    //    })
    //}
    //$scope.LoadnewsDetail();

    //// Load List Product Of news
    //$scope.products = [];
    //$scope.GetProductsOfnews = GetProductsOfnews;
    //function GetProductsOfnews() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { newsID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfnews();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}