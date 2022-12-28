// Register controller
var historyorder = angular.module('DAGStoreHome.historyorder');
historyorder.controller('historyorderController', historyorderController);

// Controller
function historyorderController($scope, apiService, sliderService, $rootScope, $timeout, $state, alertService) {
    //Load Page
    $rootScope.LoadPageSuccess = false;

    

    $scope.statusForm = 1;

    $scope.emailverifi = {}
    $scope.SendCodeSuccess = false;
    $scope.customerExist = false;
    $scope.notFindExist = false;
    $scope.notCodeExist = false;

    $scope.login = {}

    apiService.get("/historyorder/GetLogin", null, function (success) {
        var login = success.data;

        console.log(login)
        if (login.email == "") {
            $scope.statusForm = 1;
        } else {

            apiService.get("/customer/GetCustomerByEmail?email=" + login.email, null, function (success) {
                $scope.login = success.data;
                console.log($scope.login)
            }, function (error) {
                console.log("không thành công!")
            })

            $scope.emailverifi.email = login.email
            apiService.get("/historyorder/GetOrderCustomer?email=" + $scope.emailverifi.email, null, function (result) {
                $scope.OrderCustomer = result.data;
                console.log($scope.OrderCustomer)
            }, function (error) {
                console.log("Get data fail");
            })
            $scope.statusForm = 3;
        }
    }, function (error) {
        console.log("không thành công!")
    })


   
    $scope.SendCode = SendCode;
    function SendCode() {
        apiService.get("/customer/FindCustomerExist?email=" + $scope.emailverifi.email, null, function (success) {
            $scope.customerExist = success.data;
            $scope.notFindExist = $scope.customerExist == false ? true : false;
            if ($scope.customerExist) {
                $scope.statusForm = 2;
                apiService.get("/historyorder/sendcode?email=" + $scope.emailverifi.email, null, function (success) {
                    $scope.SendCodeSuccess = true;
                    apiService.get("/historyorder/getall", null, function (result) {
                        var data = result.data.data;
                        console.log(data)


                        
                    }, function (error) {
                        console.log("Get data fail");
                    })
                    
                }, function (error) {
                    console.log("không thành công!")
                })
            }
        }, function (error) {
            console.log("không thành công!")
        })
    }

    

    

    $scope.ReturnEmailForm = ReturnEmailForm;
    function ReturnEmailForm() {
        $scope.statusForm = 1;
        $scope.notFindExist = false;
    }

    apiService.get("/historyorder/GetLogin", null, function (result) {

        console.log(result.data)


    }, function (error) {
        console.log("Get data fail");
    })

    $scope.OrderCustomer = [];
    $scope.SubmitForm = SubmitForm;
    function SubmitForm() {
        apiService.get("/historyorder/getall", null, function (result) {
            var data = result.data.data;
            console.log(data)
            

            var resultCode = data.filter((obj) => {
                return obj.Email === $scope.emailverifi.email && obj.Otp === $scope.emailverifi.code;
            })

            if (resultCode.length > 0) {

                apiService.get("/historyorder/CreateLogin?email=" + $scope.emailverifi.email, null, function (result) {
                    console.log("crate thanh cong")
                   
                }, function (error) {
                    console.log(error)
                });

                apiService.get("/historyorder/GetOrderCustomer?email=" + $scope.emailverifi.email, null, function (result) {
                    $scope.OrderCustomer = result.data;
                    console.log($scope.OrderCustomer)
                }, function (error) {
                    console.log("Get data fail");
                })

                

                $scope.statusForm = 3;
                
                
            } else {
                $scope.notCodeExist = true;
            }
        }, function (error) {
            console.log("Get data fail");
        })
    }

    $scope.CancelOrder = CancelOrder;
    function CancelOrder(order, status) {
        alertService.alertStatusOrder("B?n có mu?n h?y ??n hàng?").then((result) => {
            if (result.isConfirmed) {
                order.OrderStatus = status;
                order.CreateOn = "20-12-2022";
                apiService.put("/order/update", order, function (result) {
                 

                }, function (error) {
                   

                });

            }
        })
    }


    $scope.CustomerAndress = {
        Name: "",
        NumberPhone: "",
        Andress: "",
        CustomerID:0,
    }

    $scope.AddCustomerAndress = AddCustomerAndress;
    function AddCustomerAndress() {
        $scope.CustomerAndress.CustomerID = $scope.login.ID;

        console.log($scope.CustomerAndress)

        apiService.post("/customerandress/create", $scope.CustomerAndress, function (success) {
            console.log("thanhcong")
        }, function (error) {
            console.log("không thành công!")
        })

        $scope.login.CustomerAndresss.push($scope.CustomerAndress)
    }

    $scope.Default = 0;
    $scope.SetDefault = SetDefault;
    function SetDefault(index) {
        alertService.alertStatusOrder("B?n có mu?n h?y ??n ??t hàng?").then((result) => {
            if (result.isConfirmed) {
                $scope.Default = 3;

            }
        })
    }
    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
