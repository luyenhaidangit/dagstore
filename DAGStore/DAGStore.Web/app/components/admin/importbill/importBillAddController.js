// Register controller
var importbill = angular.module('DAGStore.importBill');
importbill.controller('importbillAddController', importbillAddController);

// Controller
function importbillAddController($scope, apiService, notificationService, $state, ckeditorService, dataTableService) {
    //Config
    $scope.config = {
        nameManage: "Hóa Đơn Nhập",
        urlManage: "add-import-bill",
        namePage: "Thêm Mới",
    }
    $scope.importbill = {
        ImportBillDetails: [],
    }

    // Get data
    $scope.products = [];
    apiService.get("/product/getdata", null, function (result) {
        $scope.products = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    $scope.AddImportBillDetail = AddImportBillDetail;
    function AddImportBillDetail(item) {
        
        var item = {
            PicturePath: item.PicturePath,
            ProductName: item.Name,
            Quantity: 0,
            ImportPrice: 0,
            Discount: 0,
            TotalImportPrice:0,
        }

        $scope.importbill.ImportBillDetails.push(item);
        $scope.products.splice($scope.products.findIndex(a => a.ID === item.ID), 1)
    }

    $scope.InvoiceProcessing = InvoiceProcessing;
    function InvoiceProcessing(index) {
        console.log($scope.importbill.ImportBillDetails[index])
        var quantity = $scope.importbill.ImportBillDetails[index].Quantity === null ? 0 : ($scope.importbill.ImportBillDetails[index].Quantity);
        var importprice = $scope.importbill.ImportBillDetails[index].ImportPrice === null ? 0 : $scope.importbill.ImportBillDetails[index].ImportPrice;
        var discount = $scope.importbill.ImportBillDetails[index].Discount === null ? 0 : $scope.importbill.ImportBillDetails[index].Discount;
        $scope.importbill.ImportBillDetails[index].Quantity = $scope.importbill.ImportBillDetails[index].Quantity < 0 ? 0 : $scope.importbill.ImportBillDetails[index].Quantity;
        $scope.importbill.ImportBillDetails[index].ImportPrice = $scope.importbill.ImportBillDetails[index].ImportPrice < 0 ? 0 : $scope.importbill.ImportBillDetails[index].ImportPrice;
        $scope.importbill.ImportBillDetails[index].Discount = $scope.importbill.ImportBillDetails[index].Discount < 0 ? 0 : $scope.importbill.ImportBillDetails[index].Discount;
        var result = $scope.importbill.ImportBillDetails[index].Quantity * $scope.importbill.ImportBillDetails[index].ImportPrice - $scope.importbill.ImportBillDetails[index].Discount;
        console.log(result)
        $scope.importbill.ImportBillDetails[index].TotalImportPrice = result;
        

        
    }

    


   

    

    // Load List Brand
    $scope.suppliers = [];
    $scope.GetSuppliers = GetSuppliers;
    function GetSuppliers() {
        apiService.get("/supplier/getall", null, function (result) {
            $scope.suppliers = result.data;
          
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetSuppliers();

    

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