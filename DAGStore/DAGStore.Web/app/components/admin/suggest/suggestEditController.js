// Register controller
var suggest = angular.module('DAGStore.suggest');
suggest.controller('suggestEditController', suggestEditController);

// Controller
function suggestEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Trình Tạo Trang",
        urlManage: "suggest",
        namesuggest: "Sửa Thông Tin",
    }

    
}