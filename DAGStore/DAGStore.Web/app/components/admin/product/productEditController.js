// Register controller
var product = angular.module('DAGStore.product');
product.controller('productEditController', productEditController);

// Controller
function productEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService,$filter) {
    //Load Product Discount
    $scope.productDiscountID = [];
    $scope.productDiscount = [];
    apiService.get("/discount/GetDiscountByProduct/" + $stateParams.id, null, function (result) {
        $scope.productDiscount = result.data;
        for (let i = 0; i < $scope.productDiscount.length; i++) {
            $scope.productDiscountID.push($scope.productDiscount[i].ID.toString());
        }

    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    //Load Product Detail
    $scope.product = {
    }
    apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        $scope.product.CreateOn = $filter('formatJsonDate')($scope.product.CreateOn);
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    //Load List Brand
    $scope.brand = {};
    $scope.brands = [];
    apiService.get("/brand/getall", null, function (result) {
        $scope.brands = result.data;
        $scope.brand = $scope.brands.filter(x => x.ID === $scope.product.BrandID)[0];
    }, function (error) {
        console.log("Get data fail");
    })

    //Load List Category
    $scope.category = {};
    $scope.categorys = [];
    apiService.get("/category/getall", null, function (result) {
        $scope.categorys = result.data;
        $scope.category = $scope.categorys.filter(x => x.ID === $scope.product.CategoryID)[0];
        console.log($scope.category)
    }, function (error) {
        console.log("Get data fail");
    })

    //Load List Discount
    $scope.discounts = [];
    apiService.get("/discount/GetListDiscountProduct", null, function (result) {
        $scope.discounts = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    // Choose Avatar Product
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.product.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Regster Ckeditor
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit Product
    $scope.UpdateProduct = UpdateProduct;
    function UpdateProduct() {
        $scope.product.BrandID = document.getElementsByName("brandid")[0].value;
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
        $scope.product.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();
        $scope.product.UpdateOn = new Date().toJSON().slice(0, 10);

        apiService.put("/product/update", $scope.product, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });

        //Edit Discount Product
        var config = {
            params: {
                id: $scope.product.ID
            }
        }
        apiService.del("/ProductDiscont/DeleteMultiByProductID", config, function (success) {
            console.log("Ok nha")
        }, function (error) {
            console.log("Xóa không thành công!")
        })
        console.log($scope.productDiscountID)
        for (var i = 0; i < $scope.productDiscountID.length; i++) {

            var obj = {
                "ProductID": $scope.product.ID,
                "DiscountID": $scope.productDiscountID[i],
                "Product": null,
                "Discount": null
            }
            apiService.post("/ProductDiscont/create", obj, function (result) {
                console.log("Thêm khuyến mãi thành công")

            }, function (error) {
                console.log(obj)
                notificationService.displaySuccess("Thêm mới không thành công!");

            });
        }
    }
}