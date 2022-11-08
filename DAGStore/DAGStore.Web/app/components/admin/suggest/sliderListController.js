// Register controller
var slider = angular.module('DAGStore.slider');
slider.controller('sliderListController', sliderListController);

// Controller
function sliderListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Slider",
        urlPage: "slider",
        nameDataTable: "DAGStoreDatatable",
        data: "/slider/getdata",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Tiêu đề" },
            { targets: 3, name: "Vị trí" },
            { targets: 4, name: "Trang" },
            { targets: 5, name: "Kiểu slider" },
            { targets: 6, name: "Màu nền", visible: false },
            { targets: 7, name: "Độ ưu tiên", visible: false },
            { targets: 8, name: "Trạng thái" },
            { targets: 9, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7,8],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.sliders = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/slider/getall", null, function (result) {

            $scope.sliders = result.data;
            dataTableService.createDataTable($scope.config);
            
            console.log($scope.sliders);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.DeleteSlider = DeleteSlider;
    function DeleteSlider(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/slider/delete", config, function (success) {
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