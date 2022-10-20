// Register module
var category = angular.module('DAGStore.category', ['DAGStore.common']);

// Config module
category.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'category',
            url: '/category',
            templateUrl: '/app/components/admin/category/categoryListView.html',
            controller: "categoryListController",
        },
        {
            name: 'add-category',
            url: '/category/add',
            templateUrl: '/app/components/admin/category/categoryAddView.html',
            controller: "categoryAddController",
        },
        {
            name: 'info-category',
            url: '/category/info/:id',
            templateUrl: '/app/components/admin/category/categoryInfoView.html',
            controller: "categoryInfoController",
        },
        {
            name: 'edit-category',
            url: '/category/edit/:id',
            templateUrl: '/app/components/admin/category/categoryEditView.html',
            controller: "categoryEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




