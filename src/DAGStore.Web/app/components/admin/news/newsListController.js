// Register controller
var news = angular.module('DAGStore.news');
news.controller('newsListController', newsListController);

// Controller
function newsListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Tin Tức",
        urlPage: "news",
        nameDataTable: "DAGStoreDatatable",
        data: "/news/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            {
                targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }
            },
            { targets: 3, name: "Tiêu đề" },
            {
                targets: 4, name: "Nội dung", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            { targets: 5, name: "Ngày đăng" },
            { targets: 6, name: "Lượt xem" },
            { targets: 7, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6,7],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.news = [];
    apiService.get("/news/getall", null, function (result) {
        $scope.news = result.data;
        console.log($scope.news)
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.DeleteNews = DeleteNews;
    function DeleteNews(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/news/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                    alertService.alertDeleteSuccess();
                }, function (error) {
                  
                })
            }
        });
    }
}