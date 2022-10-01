// Register module
var product = angular.module('DAGStore.product', ['DAGStore.common']);

// Config module
product.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'product',
            url: '/product',
            templateUrl: '/app/components/product/productListView.html',
            controller: "productListController",
        },
        {
            name: 'product-add',
            url: '/product-add',
            templateUrl: '/app/components/product/productAddView.html',
            controller: "productAddController",
        },
        {
            name: 'product-edit',
            url: '/product-edit/:id',
            templateUrl: '/app/components/product/productEditView.html',
            controller: "productEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




