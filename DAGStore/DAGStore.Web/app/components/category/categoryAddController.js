// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryAddController', categoryAddController);

// Controller
function categoryAddController($scope, apiService, notificationService, $state, ckeditorService) {
    $scope.statusChooseAvatar = false;

    $scope.ChooseImage = ChooseImage;

    // Load parent category
    $scope.categorys = [];
    $scope.getItems = function getItems() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data;  
        }, function (error) {
            console.log("Get data fail");
        })
    };

    // Choose Image Avatar
    function ChooseImage(status) {
        console.log($scope.categorys)
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {

                $scope.category.PicturePath = fileUrl;
             /*   $("img[name=picturepath]").attr("src", $scope.category.PicturePath);*/
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.category.PicturePath = null;
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    $scope.category = {
        DisplayOrder: -1,  
    }

    $scope.AddCategory = AddCategory;
    function AddCategory() {
        $scope.category.Description = CKEDITOR.instances['DAGStoreTextArea'].getData();
        apiService.post("/category/create", $scope.category, function (result) {
            console.log($scope.category);
            notificationService.displaySuccess("Thêm thông tin thành công!");

            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.category);
        });
    }

    $scope.getItems();
}