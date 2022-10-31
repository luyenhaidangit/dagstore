// Register module
var product = angular.module('DAGStore.product', ['DAGStore.common']);

// Config module
product.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'product',
            url: '/product',
            templateUrl: '/app/components/admin/product/productListView.html',
            controller: "productListController",
        },
        {
            name: 'info-product',
            url: '/product/info/:id',
            templateUrl: '/app/components/admin/product/productInfoView.html',
            controller: "productInfoController",
        },
        {
            name: 'add-product',
            url: '/product/add',
            templateUrl: '/app/components/admin/product/productAddView.html',
            controller: "productAddController",
        },
        {
            name: 'edit-product',
            url: '/product/edit/:id',
            templateUrl: '/app/components/admin/product/productEditView.html',
            controller: "productEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




