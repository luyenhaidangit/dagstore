// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryListController', categoryListController);

// Controller
function categoryListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Loại Sản Phẩm",
        urlPage: "category",
        nameDataTable: "DAGStoreDatatable",
        data: "/category/getdata",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data ==='"' ? null:data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }},
            { targets: 3, name: "Tên loại sản phẩm"},
            { targets: 4, name: "Loại sản phẩm cha", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                } },
            { targets: 5, name: "Mô tả", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                } },
            { targets: 6, name: "Độ ưu tiên" },
            { targets: 7, name: "Trạng thái" },
            { targets: 8, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7],
            orthogonal: 'export'
        },
    }
        
    // Get Data
    $scope.categorys = [];
    apiService.get("/category/getdata", null, function (result) {
        $scope.categorys = result.data;
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.DeleteCategory = DeleteCategory;
    function DeleteCategory(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/category/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                }, function (error) {
                    console.log("Xóa không thành công!")
                })
                alertService.alertDeleteSuccess();
            }
        });
    }
}