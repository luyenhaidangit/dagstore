// Register controller
var importBill = angular.module('DAGStore.importBill');
importBill.controller('importBillListController', importBillListController);

// Controller
function importBillListController($scope, apiService, dataTableService, notificationService, alertService) {

    // Get Data
    $scope.importBills = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/importBill/getdata", null, function (result) {

            $scope.importBills = result.data;
            dataTableService.createDataTable("DAGStoreDatatable");
            
            console.log($scope.importBills);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.DeleteimportBill = DeleteimportBill;
    function DeleteimportBill(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/importBill/delete", config, function (success) {
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