// Register controller
var menuRecord = angular.module('DAGStore.menurecord');
menuRecord.controller('menuRecordAddController', menuRecordAddController);

// Controller
function menuRecordAddController($scope,apiService,notificationService,$state){
    $scope.menuRecord = {
        Template: "Navbar",
        WidgetZone:"",
        Published:true,
        DisplayOrder: 1,
    }

    $scope.AddMenuRecord = AddMenuRecord;
    function AddMenuRecord(){
        console.log($scope.menuRecord.WidgetZone);
        apiService.post("/menurecord/create",$scope.menuRecord,function(result){
                notificationService.displaySuccess("Thêm thông tin thành công!");
                console.log("ok")
                $state.go("menurecord");
        },function(error){
            notificationService.displaySuccess("Thêm mới không thành công!");
        });
    }
}