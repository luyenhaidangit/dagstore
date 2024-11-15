// Register controller
var order = angular.module('DAGStore.order');
order.controller('orderListController', orderListController);

// Controller
function orderListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Hóa Đơn",
        urlPage: "order",
        nameDataTable: "DAGStoreDatatable",
        data: "/order/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Mã đơn hàng" },
            { targets: 3, name: "Khách hàng" },
            { targets: 4, name: "Địa chỉ" },
            { targets: 5, name: "Thanh toán" },
            { targets: 6, name: "Trạng thái đơn"},
            { targets: 7, name: "Tổng tiền" },
            { targets: 8, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7],
            orthogonal: 'export'
        },
    }

    $scope.print = false;


    // Get data
    $scope.orders = [];
    apiService.get("/order/getall", null, function (result) {
        $scope.orders = result.data;
        console.log($scope.orders)

        angular.element(document).ready(function () {
            $.fn.dataTable.ext.errMode = 'none';

            $("#DAGStoreDatatable").DataTable({
                /*ordering: false,*/
                order: [
                    [0, "asc"]
                ],
                columnDefs: [
                    { targets: 0, name: "STT", visible: false },
                ],
                language: {
                    paginate: {
                        previous: "<i class='mdi mdi-chevron-left'>",
                        next: "<i class='mdi mdi-chevron-right'>"
                    },
                    info: "Hiển thị từ _START_ đến _END_ trong _TOTAL_ bản ghi",
                    search: "Tìm kiếm",
                    infoEmpty: "Không tìm thấy bản ghi",
                    infoFiltered: "(Trong tổng số _MAX_ bản ghi)",
                    lengthMenu: "Hiển thị _MENU_ bản ghi",
                },
                drawCallback: function () {
                    $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
                },
               /* columnDefs: $scope.config.columnDefs,*/
            })
        });

        
    }, function (error) {
        console.log("Get data fail");
    })

    $scope.ProcessingOrder = ProcessingOrder;
    function ProcessingOrder(order, status) {
        if (order.PaymentStatus != 1 && order.OrderStatus == 1) {
            alertService.alertChangeStatusOrderError("Vui lòng xác nhận thanh toán trước khi giao hàng!").then((result) => {

            });
        } else {
            order.CreateOn = "20-12-2022";
            $scope.message = "";
            if (status == 1) {
                $scope.message = "Bạn có muốn xác nhận duyệt đơn hàng?";
            } else if (status == 2) {
                $scope.message = "Bạn có muốn xác nhận đã giao hàng đơn hàng?";
            }

            alertService.alertStatusOrder($scope.message).then((result) => {
                if (result.isConfirmed) {
                    order.OrderStatus = status;
                    apiService.put("/order/update", order, function (result) {
                        notificationService.displaySuccess("Cập nhật thông tin thành công!");

                    }, function (error) {
                        notificationService.displaySuccess("Cập nhật thông tin không thành công!");

                    });

                }
            });  
        }
        
       
        
    }

    $scope.ProcessingPaymentOrder = ProcessingPaymentOrder;
    function ProcessingPaymentOrder(order, status) {
        
        $scope.message = "";
        if (status == 1) {
            $scope.message = "Bạn có muốn xác nhận đã nhận tiền thanh toán?";
        } else if (status == 2) {
            $scope.message = "Bạn có muốn xác nhận đã giao hàng đơn hàng?";
        }

        alertService.alertStatusOrder($scope.message).then((result) => {
            if (result.isConfirmed) {
                order.CreateOn = "20-12-2022";
                order.PaymentStatus = status;
                apiService.put("/order/update", order, function (result) {
                    notificationService.displaySuccess("Cập nhật thông tin thành công!");

                }, function (error) {
                    notificationService.displaySuccess("Cập nhật thông tin không thành công!");

                });

            }
        });
    }

    $scope.CancelOrder = CancelOrder;
    function CancelOrder(order, status) {
        alertService.alertStatusOrder("Bạn có muốn hủy đơn đặt hàng?").then((result) => {
            if (result.isConfirmed) {
                order.OrderStatus = status;
                order.CreateOn = "20-12-2022";
                apiService.put("/order/update", order, function (result) {
                    notificationService.displaySuccess("Cập nhật thông tin thành công!");

                }, function (error) {
                    notificationService.displaySuccess("Cập nhật thông tin không thành công!");

                });

            }
        })
    }
    
    $scope.bill = {}
    $scope.printBill = printBill;
    function printBill(order) {
        $scope.bill = order;
        $scope.print = true;
        console.log($scope.bill)
        printJS('demo', 'html');
    }
   /* printJS('bill', 'html');*/
    

    // Delete Object
    $scope.Deleteorder = Deleteorder;
    function Deleteorder(e, id) {
        console.log($(e.currentTarget).parents('tr').index());
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {

                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/order/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    console.log($(e.currentTarget).parents('tr').index());
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                }, function (error) {
                    console.log("Xóa không thành công!")
                })
                alertService.alertDeleteSuccess();
            }
        });
    }
}