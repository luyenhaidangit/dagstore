// Register module
var event = angular.module('DAGStore.event', ['DAGStore.common']);

// Config module
event.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name:'event',
            url: '/event',
            templateUrl: '/app/components/admin/event/eventListView.html',
            controller: "eventListController",
        }];
    states.forEach((state) => $stateProvider.state(state));
});




