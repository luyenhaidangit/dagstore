// Register App
var app = angular.module('DAGStore', [
    'DAGStore.supplier',
    'DAGStore.brand',
    'DAGStore.category',
    'DAGStore.product',
    'DAGStore.discount',
    'DAGStore.importBill',
    'DAGStore.menurecord',
    'DAGStore.slider',
    'DAGStore.event',
    'DAGStore.common']);

// Config app
app.config(function($stateProvider, $urlRouterProvider){
    // Config Router
    var states = [
    {
        name: 'dashboard',
        url: '/dashboard',
        templateUrl: '/app/components/admin/home/homeView.html',
        controller: "homeController",
    },
    {
        name: 'signin',
        url: '/signin',
       
        templateUrl: '/app/components/admin/login/loginView.html',
        controller: "loginController",
    }
    ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/dashboard');
});

app.run(function ($rootScope) {
    //$rootScope.$on("$routeChangeStart", function () {
    //   /* $rootScope.progressbar = ngProgressFactory.createInstance();*/
    //    cfpLoadingBar.start();
    //  /*  $rootScope.progressbar.start();*/

    //});

    //$rootScope.$on("$routeChangeSuccess", function () {
    //    cfpLoadingBar.complete();
    //    /*$rootScope.progressbar.complete();*/
    //});
    //    apiService.get("/home/testmethod", null, function (result) {
    //    $scope.products = result.data;
    //    dataTableService.createDataTable($scope.config);

    //}, function (error) {
    //    console.log("Get data fail");
    //})
})

// Config app
//app.config(function ($httpProvider) {
//    // Config Router
//    $httpProvider.interceptors.push(function ($q, $location) {
//        return {
            
//            request: function (config) {
//                console.log(config);
//                return config;
//            },
//            requestError: function (rejection) {

//                return $q.reject(rejection);
//            },
//            response: function (response) {
                
//                if (response.status == "401") {
//                    $location.path('/login');
//                    window.location = "/login"
//                }
//                //the same response/modified/or a new one need to be returned.
//                return response;
//            },
//            responseError: function (rejection) {
//                console.log(rejection);
//                if (rejection.status == "401") {
//                    $location.path('/login');
//                    window.location = "/admin"
//                }
//                return $q.reject(rejection);
//            }
//        };
//    });
//});



// Register App Home
var app = angular.module('DAGStoreHome', [
    'DAGStoreHome.index',
    'DAGStoreHome.category',
    'DAGStoreHome.product',
    'DAGStoreHome.cart',
    'DAGStoreHome.suggest',
    'DAGStore.common']);

// Config App Home
app.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'index',
            url: '/index',
            templateUrl: '/app/components/client/index/indexView.html',
            controller: "indexController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
        ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/index');
});

app.run(function ($rootScope) {
    //angular.element(function () {
    //    console.log('page loading completed');
    //    $rootScope.load = true;
    //});
    
});

// Register App
var applogin = angular.module('DAGStoreLogin', [
    'DAGStore.common']);

// Config app
applogin.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'signin',
            url: '/signin',
            templateUrl: '/app/components/admin/login/loginView.html',
            controller: "loginController",
        }
    ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/signin');
});

applogin.config(function ($httpProvider) {
    // Config Router
    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            request: function (config) {

                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    });
});

