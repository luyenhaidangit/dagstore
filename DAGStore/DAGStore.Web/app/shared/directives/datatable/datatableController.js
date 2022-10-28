// Register controller
var app = angular.module("DAGStore.common");
app.controller("datatableController", datatableController);

// Controller
function datatableController($scope, apiService, $ocLazyLoad, dataTableService) {
    //Load Resource
    $ocLazyLoad.load({
        insertBefore: '#resource',
        files: [
            '/assets/libs/datatables.net/js/jquery.dataTables.min.js',
            '/assets/libs/datatables.net-bs4/js/dataTables.bootstrap4.min.js',
            '/assets/libs/datatables.net-responsive/js/dataTables.responsive.min.js',
            '/assets/libs/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js',
        ]
    });
    dataTableService.createDataTable("DAGStoreDatatable");
    $scope.SiteMenu = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/category/getall", null, function (result) {

            $scope.SiteMenu = result.data;



        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

};