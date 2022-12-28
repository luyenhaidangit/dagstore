// Register controller
var suggest = angular.module('DAGStore.suggest');
suggest.controller('suggestEditController', suggestEditController);

// Controller
function suggestEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService, $filter) {
    //Config
    $scope.config = {
        nameManage: "Đề xuất sản phẩm",
        urlManage: "suggest",
        namesuggest: "Quản lý đề xuất",
    }

    $scope.SuggestProduct = [];
    $scope.Suggest = {}
    apiService.get("/product/getall", null, function (result) {
        $scope.SuggestProduct = result.data;

        apiService.get("/suggest/getbyid?id=" + $stateParams.id, null, function (result) {
            $scope.Suggest = result.data;

            var SuggestProduct = result.data.SuggestProducts;

            var ele = SuggestProduct.map((x) => {
                return x.ProductID;
            })
           
            $scope.SuggestProduct = $scope.SuggestProduct.map(function (e) {
                if (ele.includes(e.ID)) {
                    e.SelectSuggest = 1;
                    return e;
                } else {
                    e.SelectSuggest = 0;
                    return e;
                }
            });

            $scope.SuggestProduct = $filter('orderBy')($scope.SuggestProduct, '-SelectSuggest');

            console.log($scope.SuggestProduct);

        }, function (error) {

        });

        

        console.log($scope.SuggestProduct)
    }, function (error) {
      
    });

    $scope.categoríes = []
    apiService.get("/category/getall", null, function (result) {
        $scope.categories = result.data;
    }, function (error) {

    });

    $scope.ChangeSelectSuggest = ChangeSelectSuggest;
    function ChangeSelectSuggest(item) {
        if (item.SelectSuggest == 1) {
            item.SelectSuggest = 0;
        } else {
            item.SelectSuggest = 1;
        }
    }



    
}