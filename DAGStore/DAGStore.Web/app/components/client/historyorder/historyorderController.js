// Register controller
var historyorder = angular.module('DAGStoreHome.historyorder');
historyorder.controller('historyorderController', historyorderController);

// Controller
function historyorderController($scope, apiService, sliderService, $rootScope, $timeout, $state) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    
    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
