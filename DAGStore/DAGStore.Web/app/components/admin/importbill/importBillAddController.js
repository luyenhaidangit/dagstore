// Register controller
var importbill = angular.module('DAGStore.importBill');
importbill.controller('importbillAddController', importbillAddController);

// Controller
function importbillAddController($scope, apiService, notificationService, $state, ckeditorService) {
    // Default Value
    $scope.importbill = {
        Quantity: 1,
        ImportPrice: 12000000,
    }

    $scope.product = {
        "ID": 2,
        "Name": "Samsung Galaxy Z Fold4 256GB",
        "CategoryID": 5,
        "Category": null,
        "BrandID": 2,
        "Brand": null,
        "PicturePath": "/Upload/images/Product/samsung-galaxy-z-fold4-5g-thumb-1a-600x600%20(1).jpg",
        "ShortDescription": "Samsung Galaxy Z Fold4 256GB",
        "ShortDescriptionEndow": null,
        "FullDescription": null,
        "ShowOnHomePage": true,
        "MetaKeywords": "samsung-galaxy-z-fold4-256gb",
        "MetaDescription": "samsung-galaxy-z-fold4-256gb",
        "MetaTitle": "samsung-galaxy-z-fold4-256gb",
        "Alias": "samsung-galaxy-z-fold4-256gb",
        "StockQuantity": 10,
        "Price": 40990000,
        "OldPrice": 38000000,
        "HasDiscountsApplied": true,
        "DisplayOrder": -1,
        "Published": true,
        "CreateOn": "/Date(1664989200000)/",
        "UpdateOn": "/Date(1666544400000)/",
    }

    // Load List Brand
    $scope.suppliers = [];
    $scope.GetSuppliers = GetSuppliers;
    function GetSuppliers() {
        apiService.get("/supplier/getall", null, function (result) {
            $scope.suppliers = result.data;
            console.log($scope.suppliers[0].ID);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetSuppliers();

    // Choose Image Avatar
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        console.log($scope.importbills)
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.importbill.PicturePath = fileUrl;
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }
            finder.popup();
        }
        if (status === false) {
            $scope.importbill.PicturePath = null;
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }
    

    // Submit Add
    $scope.Addimportbill = Addimportbill;
    function Addimportbill() {
        console.log("ok")
        // Add Value
        apiService.post("/importbill/create", $scope.importbill, function (result) {
            
            notificationService.displaySuccess("Thêm thông tin thành công!");

            $state.go("importbill");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.importbill);
        });
    }
}