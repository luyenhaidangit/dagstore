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

    // Get data
    $scope.orders = [];
    apiService.get("/order/getall", null, function (result) {
        $scope.orders = result.data;

        angular.element(document).ready(function () {
            $.fn.dataTable.ext.errMode = 'none';

            $("#DAGStoreDatatable").DataTable({
                
                order: [
                    [1, "asc"]
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