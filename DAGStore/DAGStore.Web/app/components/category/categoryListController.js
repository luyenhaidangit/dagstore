// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryListController', categoryListController);

// Controller
function categoryListController($scope, apiService, dataTableService, notificationService, alertService) {

    $scope.categorys = [];

    $scope.deletecategory = deletecategory;

    $scope.getItems = function getItems() {
        apiService.get("/category/getall", null, function (result) {
            
            $scope.categorys = result.data;

            dataTableService.createDataTable("DAGStoreDatatable");
            console.log($scope.categorys);
        }, function (error) {
            console.log("Get data fail");
        })
    };

    function deletecategory(e, id) {
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

                apiService.del("/category/delete", config, function (success) {
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