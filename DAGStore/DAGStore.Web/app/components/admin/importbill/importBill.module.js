// Register module
var importBill = angular.module('DAGStore.importBill', ['DAGStore.common']);

// Config module
importBill.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'import-bill',
            url: '/import-bill',
            templateUrl: '/app/components/admin/importBill/importBillListView.html',
            controller: "importBillListController",
        },
        {
            name: 'add-import-bill',
            url: '/import-bill/add',
            templateUrl: '/app/components/admin/importBill/importBillAddView.html',
            controller: "importbillAddController",
        },
        {
            name: 'info-import-bill',
            url: '/import-bill/info/:id',
            templateUrl: '/app/components/admin/importbill/importBillInfoView.html',
            controller: "importBillInfoController",
        },
        //{
        //    name: 'edit-importBill',
        //    url: '/importBill/edit/:id',
        //    templateUrl: '/app/components/admin/importBill/importBillEditView.html',
        //    controller: "importBillEditController",
        //}

        ];
    states.forEach((state) => $stateProvider.state(state));
});




