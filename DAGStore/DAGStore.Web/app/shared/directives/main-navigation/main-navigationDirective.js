var app = angular.module("DAGStore.common");
app.directive("mainNavigationDirective", function () {
    console.log("okdsfajkldfj")
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/main-navigation/main-navigationView.html',
        controller: 'mainNavigationController',
    };
});