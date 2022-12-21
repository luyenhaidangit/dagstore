// Register controller
var news = angular.module('DAGStore.news');
news.controller('newsAddController', newsAddController);

// Controller
function newsAddController($scope, apiService, notificationService, $state, ckeditorService, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Tin tức",
        urlManage: "news",
        namePage: "Thêm Mới",
    }

    // Load Parent news
    //$scope.newss = [];
    //apiService.get("/news/getall", null, function (result) {
    //    $scope.newss = result.data;
    //    dropdownService.createDefaultDropdown("#parentnews");
    //}, function (error) {
    //    console.log("Get data fail");
    //})

    // Default Value
    $scope.news = {
        ViewCount:0,
    }

    // Choose Image Product
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.news.PictureAvatar = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.news.PictureAvatar);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.news.PictureAvatar = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Add
    $scope.AddNews = AddNews;
    function AddNews() {
        // Set Value
        console.log("ok")
        $scope.news.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Add Value
        apiService.post("/news/create", $scope.news, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("news");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
        });
    }
}