// Register controller
var product = angular.module('DAGStore.product');
product.controller('productListController', productListController);

// Controller
function productListController($scope, apiService, dataTableService, notificationService, alertService) {

    $scope.products = [];

    $scope.deleteProduct = deleteProduct;

    $scope.getItems = function getItems() {
        apiService.get("/product/getall", null, function (result) {

            $scope.products = result.data;
            /*$scope.products.Price = $filter('formatCurrencyVND')($scope.product.Price);*/

            dataTableService.createDataTable("DAGStoreDatatable");

        }, function (error) {
            console.log("Get data fail");
        })
    };

    function deleteProduct(e, id) {
        console.log($(e.currentTarget).parents('tr').index());
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {

                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/product/delete", config, function (success) {
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
    $scope.getItems();


}