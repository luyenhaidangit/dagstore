// Register controller
var brand = angular.module('DAGStore.importBill');
brand.controller('importBillEditController', importBillEditController);

// Controller
function importBillEditController($scope, apiService, notificationService, $state, $stateParams) {
    //Config
    $scope.config = {
        nameManage: "Hóa Đơn Nhập",
        urlManage: "edit-import-bill",
        namePage: "Sửa Thông Tin",
    }

    //Load List Product
    $scope.products = [];
    apiService.get("/product/getall", null, function (result) {
        $scope.products = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    // Load Import Bill Detail
    $scope.importbill = {
        
    }
    apiService.get("/importbill/getinfo/" + $stateParams.id, null, function (result) {
        $scope.importbill = result.data;
        console.log($scope.importbill)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Add ImportBillDetail
    $scope.AddImportBillDetail = AddImportBillDetail;
    function AddImportBillDetail(item) {
        $scope.products.splice($scope.products.findIndex(a => a.ID === item.ID), 1)
        console.log(item)
        var item = {
            PicturePath: item.PicturePath,
            ProductName: item.Name,
            ImportBillID: null,
            ProductID: item.ID,
            Quantity: 1,
            ImportPrice: item.CostPrice,
            Discount: 0,
            TotalImportPrice: 0,
        }
        item.TotalImportPrice = item.Quantity * item.ImportPrice - item.Discount
        $scope.importbill.ImportBillDetails.push(item);
        InvoiceTotalProcessing();
    }

    // Invoice Processing
    $scope.InvoiceProcessing = InvoiceProcessing;
    function InvoiceProcessing(index) {
        var result = ($scope.importbill.ImportBillDetails[index].Quantity * $scope.importbill.ImportBillDetails[index].ImportPrice) * (100 - $scope.importbill.ImportBillDetails[index].Discount) / 100;
        $scope.importbill.ImportBillDetails[index].TotalImportPrice = result;

        InvoiceTotalProcessing();
    }

    // Invoice Total Processing
    function Sum(items, prop) {
        return items.reduce(function (a, b) {
            return a + b[prop];
        }, 0);
    };
    $scope.InvoiceTotalProcessing = InvoiceTotalProcessing;
    function InvoiceTotalProcessing() {
        $scope.importbill.ActualPriceBill = Sum($scope.importbill.ImportBillDetails, 'TotalImportPrice');
        var TotalPriceBill = 0;
        $scope.importbill.ImportBillDetails.forEach(item => {
            TotalPriceBill += item.Quantity * item.ImportPrice;
        });
        $scope.importbill.TotalPriceBill = TotalPriceBill;
        $scope.importbill.TotalDiscount = $scope.importbill.TotalPriceBill - $scope.importbill.ActualPriceBill;
    }

    // Remove Detail Bill
    $scope.RemoveDetailBill = RemoveDetailBill;
    function RemoveDetailBill(value) {
        $scope.importbill.ImportBillDetails = $scope.importbill.ImportBillDetails.filter(function (item) {
            return item !== value
        })
        InvoiceTotalProcessing();
    }

    //Choose Supplier Import Bill
    $scope.ChooseSupplierImportBill = ChooseSupplierImportBill;
    function ChooseSupplierImportBill(item) {
        $scope.importbill.SupplierID = item.ID;
        $scope.errorSupplier = false;
    }

    // Load List Brand
    $scope.suppliers = [];
    apiService.get("/supplier/getall", null, function (result) {
        $scope.suppliers = result.data;
    }, function (error) {
        console.log("Get data fail");
    })
   

    // Submit Edit
    $scope.EditImportBill = EditImportBill;
    function EditImportBill () {
       
        $scope.importbill.ImportBillDetails = [];
        apiService.put("/importbill/update", $scope.importbill, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("import-bill");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.importbill)
        });
    }
}