// Register module
var brand = angular.module('DAGStore.brand', ['DAGStore.common']);

// Config module
brand.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'brand',
            url: '/brand',
            templateUrl: '/app/components/admin/brand/brandListView.html',
            controller: "brandListController",
        },
        {
            name: 'add-brand',
            url: '/brand/add',
            templateUrl: '/app/components/admin/brand/brandAddView.html',
            controller: "brandAddController",
        },
        {
            name: 'info-brand',
            url: '/brand/info/:id',
            templateUrl: '/app/components/admin/brand/brandInfoView.html',
            controller: "brandInfoController",
        },
        {
            name: 'brand-edit',
            url: '/brand-edit/:id',
            templateUrl: '/app/components/brand/brandEditView.html',
            controller: "brandEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




