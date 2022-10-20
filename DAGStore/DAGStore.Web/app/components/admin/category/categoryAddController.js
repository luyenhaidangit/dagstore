// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryAddController', categoryAddController);

// Controller
function categoryAddController($scope, apiService, notificationService, $state, ckeditorService) {
    // Default Value
    $scope.category = {
        DisplayOrder: -1,
        Published: true,
    }

    // Load Parent Category
    $scope.categorys = [];
    $scope.getItems = function getItems() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data;
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Choose Image Avatar
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        console.log($scope.categorys)
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.category.PicturePath = fileUrl;
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

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Add
    $scope.AddCategory = AddCategory;
    function AddCategory() {
        // Set Value
        $scope.category.ParentCategoryID = document.getElementsByName("parentcategoryid")[0].value;
        $scope.category.Description = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Add Value
        apiService.post("/category/create", $scope.category, function (result) {
            console.log($scope.category);
            notificationService.displaySuccess("Thêm thông tin thành công!");

            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.category);
        });
    }
}