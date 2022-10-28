var app = angular.module("DAGStore.common");
app.directive("datatable", function () {
    return {
        restrict: "EA",
        /*templateUrl: '/app/shared/directives/datatable/datatableView.html',*/
        controller: 'datatableController',
    };
});