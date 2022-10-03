// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryListController', categoryListController);

// Controller
function categoryListController($scope, apiService, dataTableService, notificationService, alertService) {

    // Get Data
    $scope.categorys = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/category/getall", null, function (result) {

            $scope.categorys = result.data;
            dataTableService.createDataTable("DAGStoreDatatable");
            
            console.log($scope.categorys);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.DeleteCategory = DeleteCategory;
    function DeleteCategory(e, id) {
        console.log($(e.currentTarget).parents('tr').index());
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