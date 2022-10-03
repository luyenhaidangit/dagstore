// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryEditController', categoryEditController);

// Controller
function categoryEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {

    // Load Category Detail
    $scope.category = {
    }
    $scope.LoadCategoryDetail = LoadCategoryDetail;
    function LoadCategoryDetail() {
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
            /*console.log($scope.category);*/
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadCategoryDetail();

    // Load Parent Category
    $scope.parentCategory = {};
    $scope.categorys = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data.filter(x => x.ID !== $scope.category.ID);
            $scope.parentCategory = $scope.categorys.filter(x => x.ID === $scope.category.ParentCategoryID)[0];
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Choose Image Avatar
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.category.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.category.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.category.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit
    $scope.UpdateCategory = UpdateCategory;
    function UpdateCategory() {
        console.log($scope.parentCategory);
        apiService.put("/category/update", $scope.category, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.category)
        });
    }
}