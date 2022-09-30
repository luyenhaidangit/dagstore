// Register controller
var menuRecord = angular.module('DAGStore.menurecord');
menuRecord.controller('menuRecordEditController', menuRecordEditController);

// Controller
function menuRecordEditController($scope,apiService,notificationService,$state,$stateParams){
    $scope.menuRecord = {
        
    }

    function loadMenuRecordDetail(){
        apiService.get("/menurecord/getbyid/"+$stateParams.id,null,function(result){
            $scope.menuRecord = result.data;
        },function(error){
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }

    $scope.UpdateMenuRecord = UpdateMenuRecord;
    function UpdateMenuRecord() {
        apiService.put("/menurecord/update", $scope.menuRecord, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("menurecord");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });
    }

    loadMenuRecordDetail();
}