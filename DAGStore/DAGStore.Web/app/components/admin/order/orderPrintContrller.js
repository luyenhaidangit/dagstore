// Register controller
var order = angular.module('DAGStore.order');
order.controller('orderPrintController', orderPrintController);

// Controller
function orderPrintController($scope, apiService, dataTableService, notificationService, alertService, $stateParams) {
    //Config
    $scope.config = {
        namePage: "Xuất Hóa Đơn",
        urlPage: "print-order",
        nameDataTable: "DAGStoreDatatable",
        data: "/order/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Mã đơn hàng" },
            { targets: 3, name: "Khách hàng" },
            { targets: 4, name: "Địa chỉ" },
            { targets: 5, name: "Thanh toán" },
            { targets: 6, name: "Trạng thái đơn" },
            { targets: 7, name: "Tổng tiền" },
            { targets: 8, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7],
            orthogonal: 'export'
        },
    }



    // Get data
    $scope.bill = {};
    apiService.get("/order/getorderprint?id=" + $stateParams.id, null, function (result) {
        $scope.bill = result.data;
      
    }, function (error) {
        console.log("Get data fail");
    })

    $scope.printBill = printBill;
    function printBill() {
        printJS('demo', 'html');
    }

    //$scope.printBill = printBill;
    //function printBill(order) {
    //    $scope.bill = order;
    //    $scope.print = true;
    //    console.log($scope.bill)
    //    printJS('demo', 'html');
    //}
    /* printJS('bill', 'html');*/


    // Delete Object
    //$scope.Deleteorder = Deleteorder;
    //function Deleteorder(e, id) {
    //    console.log($(e.currentTarget).parents('tr').index());
    //    alertService.alertSubmitDelete().then((result) => {
    //        if (result.isConfirmed) {

    //            var config = {
    //                params: {
    //                    id: id
    //                }
    //            }
    //            apiService.del("/order/delete", config, function (success) {
    //                notificationService.displaySuccess("Xóa thành công bản ghi!");
    //                let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
    //                let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
    //                let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
    //                let index = pageIndex * recordOfPage + recordIndexOfPage;
    //                console.log($(e.currentTarget).parents('tr').index());
    //                $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
    //            }, function (error) {
    //                console.log("Xóa không thành công!")
    //            })
    //            alertService.alertDeleteSuccess();
    //        }
    //    });
    //}
}