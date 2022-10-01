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

            dataTableService.createDataTable("DAGStoreDatatable");

        }, function (error) {
            console.log("Get data fail");
        })
    };

    function deleteProduct(e, id) {
        //let x = $("tbody tr");
        //let y = x.children("td:nth-child(1)");

        //for (let i = 0; i < x.length; i++) {
        //    console.log(y);
        //}
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

                    $("#DAGStoreDatatable").DataTable().row($(e.currentTarget).parents('tr').index()).remove().draw();
               
                }, function (error) {
                    console.log(id);
                    console.log("Xóa không thành công!")
                })

                alertService.alertDeleteSuccess();


            }
        });



    }
    $scope.getItems();


}