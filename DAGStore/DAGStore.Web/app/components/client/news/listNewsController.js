// Register controller
var news = angular.module('DAGStoreHome.news');
news.controller('listNewsController', listNewsController);

// Controller
function listNewsController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;


    // Load news Detail
    $scope.news = {
    }
    $scope.LoadnewsDetail = LoadnewsDetail;
    function LoadnewsDetail() {
        apiService.get("/news/getall", null, function (result) {
            $scope.news = result.data;
            console.log($scope.news)
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadnewsDetail();

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

    $scope.newsAll = []
    /* $scope.category =*/
    apiService.get("/news/getall", null, function (result) {
        $scope.newsAll = result.data;


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

    apiService.get("/news/GetProductOrderByViewCount", null, function (result) {
        $scope.newsCount = result.data;


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

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}