// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandEditController', brandEditController);

// Controller
function brandEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {

    // Load brand Detail
    $scope.brand = {
    }
    $scope.LoadbrandDetail = LoadbrandDetail;
    function LoadbrandDetail() {
        apiService.get("/brand/getbyid/" + $stateParams.id, null, function (result) {
            $scope.brand = result.data;
            /*console.log($scope.brand);*/
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadbrandDetail();

    // Load Parent brand
    $scope.parentbrand = {};
    $scope.brands = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/brand/getall", null, function (result) {
            $scope.brands = result.data.filter(x => x.ID !== $scope.brand.ID);
            $scope.parentbrand = $scope.brands.filter(x => x.ID === $scope.brand.ParentbrandID)[0];
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
                $scope.brand.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.brand.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.brand.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit
    $scope.Updatebrand = Updatebrand;
    function Updatebrand() {
        // Set Value
        $scope.brand.ParentbrandID = document.getElementsByName("parentbrandid")[0].value;
        $scope.brand.Description = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Edit Value
        apiService.put("/brand/update", $scope.brand, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("brand");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.brand)
        });
    }
}