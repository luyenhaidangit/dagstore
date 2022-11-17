// Register controller
var app = angular.module("DAGStore.common");
app.controller("topSliderController", topSliderController);

// Controller
function topSliderController($scope, apiService) {
    // Get Slider
    $scope.sliders = [];
    apiService.get("/index/showslider", null, function (result) {
        $scope.sliders = result.data;
    }, function (error) {
        console.log("Get data fail");
    })
};