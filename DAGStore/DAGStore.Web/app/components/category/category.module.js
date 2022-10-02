// Register module
var category = angular.module('DAGStore.category', ['DAGStore.common']);

// Config module
category.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'category',
            url: '/category',
            templateUrl: '/app/components/category/categoryListView.html',
            controller: "categoryListController",
        },
        {
            name: 'category-add',
            url: '/category-add',
            templateUrl: '/app/components/category/categoryAddView.html',
            controller: "categoryAddController",
        },
        {
            name: 'category-edit',
            url: '/category-edit/:id',
            templateUrl: '/app/components/category/categoryEditView.html',
            controller: "categoryEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




