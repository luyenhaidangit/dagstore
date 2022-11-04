// Register controller
var importbill = angular.module('DAGStore.importBill');
importbill.controller('importbillInfoController', importbillInfoController);

// Controller
function importbillInfoController($scope, apiService, notificationService, $state, ckeditorService, dataTableService) {
    //Config
    $scope.config = {
        nameManage: "Hóa Đơn Nhập",
        urlManage: "info-import-bill",
        namePage: "Chi Tiết Hóa Đơn",
    }
    
    // Get Data
    $scope.importbill = {}
    apiService.get("/importbill/getinfo", $stateParams.id, function (result) {
        $scope.importbill = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

  
    
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


    $scope.AddImportBill = AddImportBill;
    function AddImportBill() {
        $scope.errorSupplier = $scope.importbill.SupplierID == 0 ? true : false;
        console.log($scope.importbill)
        apiService.post("/importbill/create", $scope.importbill, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("import-bill");
        }, function (error) {

        });
    }
}