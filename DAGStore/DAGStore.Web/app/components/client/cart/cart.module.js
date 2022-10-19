// Register module
var product = angular.module('DAGStoreHome.cart', ['DAGStore.common']);

// Config module
product.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'cart',
            url: '/cart',
            templateUrl: '/app/components/client/cart/cartView.html',
            controller: "cartController",
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




