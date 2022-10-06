// Register module
var category = angular.module('DAGStoreHome.category', ['DAGStore.common']);

// Config module
category.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'category',
            url: '/category/:id',
            templateUrl: '/app/components/client/category/categoryView.html',
            controller: "categoryController",
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




