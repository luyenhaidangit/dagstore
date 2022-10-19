// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandListController', brandListController);

// Controller
function brandListController($scope, apiService, dataTableService, notificationService, alertService) {

    // Get Data
    $scope.brands = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/brand/getall", null, function (result) {

            $scope.brands = result.data;
            dataTableService.createDataTable("DAGStoreDatatable");
            
            console.log($scope.brands);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.Deletebrand = DeleteBrand;
    function DeleteBrand(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/brand/delete", config, function (success) {
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