// Register module
var menuRecord = angular.module('DAGStore.menurecord', ['DAGStore.common']);
 
// Config module
menuRecord.config(function($stateProvider, $urlRouterProvider){
    // Config Router
    var states = [
    {
      name: 'menurecord',
      url: '/menurecord',
      templateUrl: '/app/components/menurecord/menuRecordListView.html',
      controller: "menuRecordListController",
    },
    {
      name: 'menu-record-add',
      url: '/menu-record-add',
      templateUrl: '/app/components/menurecord/menuRecordAddView.html',
      controller: "menuRecordAddController",
    },
    {
      name: 'menu-record-edit',
      url: '/menu-record-edit/:id',
      templateUrl: '/app/components/menurecord/menuRecordEditView.html',
      controller: "menuRecordEditController",
    }];
    states.forEach((state) => $stateProvider.state(state));
    });



  
