// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandAddController', brandAddController);

// Controller
function brandAddController($scope, apiService, notificationService, $state, ckeditorService) {
    // Default Value
    $scope.brand = {
        DisplayOrder: -1,
        Published: true,
    }

    // Choose Image Avatar
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        console.log($scope.brands)
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.brand.PicturePath = fileUrl;
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }
            finder.popup();
        }
        if (status === false) {
            $scope.brand.PicturePath = null;
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }
    

    // Submit Add
    $scope.AddBrand = AddBrand;
    function AddBrand() {
        console.log("ok")
        // Add Value
        apiService.post("/brand/create", $scope.brand, function (result) {
            
            notificationService.displaySuccess("Thêm thông tin thành công!");

            $state.go("brand");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.brand);
        });
    }
}