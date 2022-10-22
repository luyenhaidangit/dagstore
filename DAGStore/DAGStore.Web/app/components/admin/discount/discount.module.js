// Register module
var discount = angular.module('DAGStore.discount', ['DAGStore.common']);

// Config module
discount.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'discount',
            url: '/discount',
            templateUrl: '/app/components/admin/discount/discountListView.html',
            controller: "discountListController",
        },
        {
            name: 'add-discount',
            url: '/discount/add',
            templateUrl: '/app/components/admin/discount/discountAddView.html',
            controller: "discountAddController",
        },
        {
            name: 'info-discount',
            url: '/discount/info/:id',
            templateUrl: '/app/components/admin/discount/discountInfoView.html',
            controller: "discountInfoController",
        },
        {
            name: 'edit-discount',
            url: '/discount/edit/:id',
            templateUrl: '/app/components/admin/discount/discountEditView.html',
            controller: "discountEditController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




