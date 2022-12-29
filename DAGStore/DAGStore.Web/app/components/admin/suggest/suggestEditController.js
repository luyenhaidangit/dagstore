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
    $scope.numberShowCateogires = 5;
    apiService.get("/category/getall", null, function (result) {
        $scope.categories = result.data;
        $scope.categories = $scope.categories.map((x) => {
            if (x.ParentCategoryID == 0) {
                return x;
            }
        })
        $scope.categories = $scope.categories.slice(0, $scope.numberShowCateogires);
    }, function (error) {

    });

    $scope.brands = []
    $scope.numberShowBrands = 5;
    apiService.get("/brand/getall", null, function (result) {
        $scope.brands = result.data;
        $scope.brands = $scope.brands.slice(0, $scope.numberShowBrands);
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

    $scope.ListChildOpen = -1;
    $scope.ShowListChild = ShowListChild;
    function ShowListChild(index) {
        if ($scope.ListChildOpen == index) {
            $scope.ListChildOpen = -1;
        } else {
            $scope.ListChildOpen = index;
        }
    }

    $scope.LoadMoreCategory = LoadMoreCategory;
    function LoadMoreCategory() {
        $scope.numberShowCateogires += 5;
        apiService.get("/category/getall", null, function (result) {
            $scope.categories = result.data;
            $scope.categories = $scope.categories.filter((x) => {
                if (x.ParentCategoryID == 0) {
                    return x;
                }
            })
            if ($scope.numberShowCateogires >= $scope.categories.length) {
                $scope.numberShowCateogires = $scope.categories.length;
                $scope.categories = $scope.categories.slice(0, $scope.numberShowCateogires);
            } else {
                $scope.categories = $scope.categories.slice(0, $scope.numberShowCateogires);
            }

        }, function (error) {

        });
    }

    $scope.LoadMoreBrand = LoadMoreBrand;
    function LoadMoreBrand() {
        $scope.numberShowBrands += 5;
        apiService.get("/brand/getall", null, function (result) {
            $scope.brands = result.data;

            if ($scope.numberShowBrands >= $scope.brands.length) {
                $scope.numberShowCateogires = $scope.brands.length;
                $scope.brands = $scope.brands.slice(0, $scope.numberShowBrands);
            } else {
                $scope.brands = $scope.brands.slice(0, $scope.numberShowBrands);
            }

        }, function (error) {

        });
    }

    $scope.FilterCategory = "";
    $scope.FilterBrand = "";

    $scope.FilterSuggest = FilterSuggest;
    function FilterSuggest(item, status) {
        if (status == 1) {
            $scope.FilterCategory = item;
        } else if (status == 2) {
            $scope.FilterBrand = item;
        }
        Filter();
    }

    function Filter() {
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

                if ($scope.FilterCategory != '') {
                    $scope.SuggestProduct = $filter('filter')($scope.SuggestProduct, { CategoryID: $scope.FilterCategory });
                }

                if ($scope.FilterBrand != '') {
                    $scope.SuggestProduct = $filter('filter')($scope.SuggestProduct, { BrandID: $scope.FilterBrand });
                }

            }, function (error) {

            });
        })
    }

    $scope.UpdateSuggest = UpdateSuggest;
    function UpdateSuggest() {
        console.log("ok")
        $scope.Suggest.SuggestProducts = [];
        $scope.SuggestProduct.map((x) => {
            if (x.SelectSuggest == 1) {
                var item = {
                    SuggestID: $scope.Suggest.ID,
                    ProductID: x.ID,
                    Suggest: null,
                    Product: null,
                }

                $scope.Suggest.SuggestProducts.push(item);
            }
        })

        apiService.put("/suggest/update", $scope.Suggest, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("suggest");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.category)
        });

        console.log($scope.Suggest)
    }
}