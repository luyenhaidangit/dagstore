// Register controller
var menuRecord = angular.module('DAGStore.menurecord');
menuRecord.controller('menuRecordListController', menuRecordListController);

// Controller
function menuRecordListController($scope, apiService, dataTableService, notificationService, alertService) {
  
    $scope.menuRecords = [];

    $scope.deleteMenuRecord = deleteMenuRecord;

    $scope.getItems = function getItems() {
        apiService.get("/menurecord/getall", null, function (result) {

            $scope.menuRecords = result.data;

            dataTableService.createDataTable("DAGStoreDatatable");

        }, function (error) {
            console.log("Get data fail");
        })
    };

    function deleteMenuRecord(e,id) {
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
                        id:id
                    }
                }
               
                apiService.del("/menurecord/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    
                    $("#DAGStoreDatatable").DataTable().row($(e.currentTarget).parents('tr').index()).remove().draw();
                    /*$scope.$apply();*/
                    //dataTableService.desTroyDataTable("DAGStoreDatatable");
                    //$scope.getItems();
                    
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