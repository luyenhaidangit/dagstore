// Register controller
var product = angular.module('DAGStoreHome.product');
product.controller('productController', productController);

// Controller
function productController($scope, apiService, $stateParams, $filter, $window) {
    // Load Product Detail
    $scope.product = {
    }
    $scope.category = {
    }

    apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        $scope.product.CreateOn = $filter('formatJsonDate')($scope.product.CreateOn);
        apiService.get("/category/getbyid/" + $scope.product.CategoryID, null, function (resultCategory) {
            $scope.category = resultCategory.data;
            console.log($scope.category);
        }, function (error) {
            console.log("Không thể tải dữ liệu");
            
        })
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    // Add Session Product Cart
    var getValue = function () {
        return $window.sessionStorage.length;
    }

    var getData = function () {
        var json = [];
        $.each($window.sessionStorage, function (i, v) {
            json.push(angular.fromJson(v));
        });
        return json;
    }

    $scope.testSession = testSession;
    function testSession() {
        let carts = $window.sessionStorage.getItem("cart") ?
            JSON.parse($window.sessionStorage.getItem("cart")) : [];
        console.log(carts);
    }
    $scope.testSession();

    $scope.images = getData();
    $scope.count = getValue();

    $scope.addItem = function (id) {
        var image = document.getElementById('img' + id);
        json = {
            id: id,
            img: image.src
        }
        $window.sessionStorage.setItem(id, JSON.stringify(json));
        $scope.count = getValue();
        $scope.images = getData();
    }

    
}