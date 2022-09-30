

(function (app) {
    app.factory('alertService', alertService);

    // apiService.$inject = ['$http'];

    function alertService() {

        function alertSubmitDelete() {
            var alertSubmitDelete = Swal.fire({
                title: "Bạn có chắc muốn xóa thông tin bản ghi?"
                , text: "Bạn sẽ không thể khôi phục thông tin bản ghi sau khi xác nhận!"
                , icon: "warning"
                , showCancelButton: !0
                , confirmButtonColor: "#34c38f"
                , cancelButtonColor: "#ff3d60"
                , confirmButtonText: "Xác nhận"
                , cancelButtonText: "Bỏ qua"
            })
                //.then((result) => {
                //    if (result.isConfirmed) {
                //        Swal.fire(
                //            'Đã xóa!',
                //            'Bản ghi đã xóa thành công!',
                //            'success'
                //        )
                //    }
                //})
            return alertSubmitDelete;
        }

        function alertDeleteSuccess() {
            var alertDeleteSuccess = Swal.fire(
                  'Đã xóa!',
                  'Bản ghi đã xóa thành công!',
                  'success'
            )
            return alertDeleteSuccess;
        }

        return {
            alertSubmitDelete: alertSubmitDelete,
            alertDeleteSuccess: alertDeleteSuccess,
        }
    }
})(angular.module('DAGStore.common'));
