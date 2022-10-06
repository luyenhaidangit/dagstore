// Register App
var app = angular.module('DAGStore', [
    'DAGStore.menurecord',
    'DAGStore.category',
    'DAGStore.product',
    'DAGStore.common']);

// Config app
app.config(function($stateProvider, $urlRouterProvider){
    // Config Router
    var states = [
    {
      name: 'home',
      url: '/home',
      templateUrl: '/app/components/home/homeView.html',
      controller: "homeController",
    },
    {
      name: 'error',
      url: '/error',
      templateUrl: '/app/components/error/errorView.html'
    }];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/home');
});

// Register App Home
var app = angular.module('DAGStoreHome', ['DAGStoreHome.index','DAGStoreHome.category','DAGStore.common']);

// Config App Home
app.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'index',
            url: '/index',
            templateUrl: '/app/components/index/indexView.html',
            controller: "indexController",
        },
        ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/index');
});

