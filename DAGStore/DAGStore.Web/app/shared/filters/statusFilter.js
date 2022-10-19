

(function (app) {
    app.filter("statusFilter",function(){
        return function(input){
            if(input===true){
                return "Hoạt động";
            }else{
                return "Ngừng hoạt động";
            }
        }
    })

    app.filter("existDataFilter", function () {
        return function (input) {
            if (input === null) {
                return "---";
            } else {
                return input;
            }
        }
    });

    app.filter("formatJsonDate", function () {
        return function (input) {

            function convert(str) {
                var date = new Date(str),
                    mnth = ("0" + (date.getMonth() + 1)).slice(-2),
                    day = ("0" + date.getDate()).slice(-2);
                 return [date.getFullYear(), mnth, day].join("-");
                /*return [day, mnth, date.getFullYear()].join("-");*/
            }

            return convert(new Date(parseInt(input.substr(6))));
        }
    });

    app.filter("formatCurrencyVND", function () {
        return function (input) {
            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(input);
        }
    });

    

    
})(angular.module('DAGStore.common'));