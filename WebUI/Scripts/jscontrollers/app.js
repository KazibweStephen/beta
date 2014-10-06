var angularExample = angularExample || {};
angularExample.app = angular.module("angularExample", ["ngRoute", "upidamodule", 'ngCookies', 'ngDialog','ui.bootstrap']);


//angularExample.app.directive('datetimeConverter', function (utils) {
//    return {
//        restrict: 'A',
//        scope: true,
//        link: function ($scope, element, attrs) {
//            var date = new Date($scope[attrs.date]);
//            var minutes = date.getMinutes(); if (minutes < 10) minutes = "0" + minutes;
//            var hours = date.getHours(); if (hours < 10) hours = "0" + hours;
//            var month = date.getMonth(); if (month < 10) month = "0" + month;
//            var day = date.getDate(); if (day < 10) day = "0" + day;
//            return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + day;
//        }
//    };

//});
    angularExample.app.directive('barchart', function () {

        return {

            // required to make it work as an element
            restrict: 'E',
            template: '<div></div>',
            replace: true,
            // observe and manipulate the DOM
            link: function ($scope, element, attrs) {

                var data = $scope[attrs.data],
                    xkey = $scope[attrs.xkey],
                    ykeys = $scope[attrs.ykeys],
                    labels = $scope[attrs.labels];

                Morris.Bar({
                    element: element,
                    data: data,
                    xkey: xkey,
                    ykeys: ykeys,
                    labels: labels
                });
                $scope.$apply();
            }

        };

    });
    angularExample.app.config(['ngDialogProvider', function (ngDialogProvider) {
        ngDialogProvider.setDefaults({
            className: 'ngdialog-theme-default',
            plain: false,
            showClose: true,
            closeByDocument: true,
            closeByEscape: true,
            appendTo: false
        });
    }]);
    angularExample.app.filter('sumByKey', function () {
        return function (data, key) {
            if (typeof (data) === 'undefined' || typeof (key) === 'undefined') {
                return 0;
            }

            var sum = 0;
            for (var i = data.length - 1; i >= 0; i--) {
                sum += parseInt(data[i][key]);
            }

            return sum;
        };
    })


angularExample.app.config(function ($routeProvider) {
    $routeProvider
        		.when("/", {
        		    templateUrl: "Home/Home",
        		    controller: "clientListController"
        		}) 
              .when("/LandLord/ApartmentHome/:Id", {
                  templateUrl: "LandLord/ApartmentHome",
                  controller: "ApartmentDetailsController"
              })
           .when("/LandLord/Tenants/:Id", {
               templateUrl: "LandLord/Tenants",
               controller: "tenantController"
           })
            .when("/LandLord/ChargeDetails/:Id", {            
                templateUrl: "LandLord/ChargeDetails",
                controller: "billingListController"             
            })
           .when("/Client/CreateClient", {
               templateUrl: "Client/CreateClient",
               controller: "JsClientController"
           })
          .when("/Client/Statement/:Id", {
              templateUrl: "Client/Statement",
              controller: "statementController"
          })
            .when("/Client/CreateClient/:Id", {
                templateUrl: "Client/CreateClient",
                controller: "JsClientController"
            })
          .when("/Client/Index", {
              templateUrl: "client/Index",
              controller: "clientListController"
          })
        .when("/Lease/Create/:Id", {
            templateUrl: "Lease/Create",
            controller: "createLeaseController"
        })
		.when("/ApartmentOwner/ApartmentOwner", {
		    templateUrl: "ApartmentOwner/ApartmentOwner",
		    controller: "privateOwnerController"
		})
            .when("/ApartmentOwner/PrivateOwner", {
                templateUrl: "ApartmentOwner/PrivateOwner",
                controller: "privateOwnerController"
            })
        		.when("/ApartmentOwner/Index", {
        		    templateUrl: "ApartmentOwner/Index",
        		    controller: "privateOwnerController"
        		})
		.when("/Test/Index", {
			templateUrl: "Test/index",
			controller: "davidCreateController"
		})
 
		.when("/Apartment/Create/:Id", {
			templateUrl: "Apartment/Create",
			controller: "apartmentController"
		})
          .when("/LandLord/UnitDetails/:Id", {
              templateUrl: "LandLord/UnitDetails ",
              controller: "apartmentController"
          })
             .when("/LandLord/PaymentReport/:Id", {
                 templateUrl: "LandLord/PaymentReport ",
                 controller: "paymentListController"
             })
          .when("/Lease/LeaseDetails/:Id", {
              templateUrl: "Lease/LeaseDetails ",
              controller: "leaseController"
          })
              .when("/Lease/CreateMortgage", {
                  templateUrl: "Lease/CreateMortgage ",
                  controller: "mortgageController"
              })
                 .when("/Lease/LeasePaymentType", {
                      templateUrl: "Lease/LeasePaymentType",
                      controller: "leasePaymentTypeController"
                 })
         .when("/Lease/LeaseTypes", {
             templateUrl: "Lease/LeaseTypes",
             controller: "leaseTypeController"
         })
        	.when("/Apartment/Create", {
        	    templateUrl: "Apartment/Create",
        	    controller: "apartmentController"
        	})
        .when("/Apartment/Apartments", {
            templateUrl: "Apartment/Apartments",
            controller: "apartmentController"
        })
        	.when("/Apartment/CreateApartmentType/:clientId", {
        	    templateUrl: "Apartment/CreateApartmentType",
        	    controller: "apartmentController"
        	})
            .when("/Apartment/CreateRoom/:clientId", {
        	    templateUrl: "Apartment/CreateRoom",
        	    controller: "apartmentController"
            })
              .when("/Apartment/CreateRoomItem/:clientId", {
                  templateUrl: "Apartment/CreateRoomItem ",
                  controller: "apartmentController"
              })
        	.when("/Apartment/CreateApartmentUnitType/:Id", {
        	    templateUrl: "Apartment/CreateApartmentUnitType",
        	    controller: "apartmentController"
        	})
        	.when("/Apartment/CreateApartmentUnit/:Id", {
        	    templateUrl: "Apartment/CreateApartmentUnit",
        	    controller: "apartmentUnitController"
        	})
         .when("/Apartment/ViewApartmentUnits/:Id", {
                  templateUrl: "Apartment/ViewApartmentUnits",
                  controller: "apartmentController"
         })
         .when("/Apartment/ViewApartmentUnitTypes/:Id", {
             templateUrl: "Apartment/ViewApartmentUnitTypes",
             controller: "apartmentController"
         })
         .when("/Apartment/ViewApartmentTypes/", {
             templateUrl: "Apartment/ViewApartmentTypes",
             controller: "apartmentController"
         })
    
              .when("/Apartment/UnitPaymentType/", {
                  templateUrl: "Apartment/UnitPaymentType",
                  controller: "unitPaymentModeController"
              })
           .when("/LandLord/UnitListing/:Id", {
               templateUrl: "/LandLord/UnitListing",
               controller: "unitListController"
           })
          .when("/LandLord/ApartmentBooking/:Id", {
              templateUrl: "/LandLord/ApartmentBooking",
              controller: "bookingListController"
          })
           .when("/LandLord/PaymentChart/:Id", {
               templateUrl: "/LandLord/PaymentChart",
               controller: "chartController"
           })
           .when("/Apartment/CreateRoom/:Id", {
               templateUrl: "Apartment/CreateRoom",
               controller: "apartmentController"
           })
              .when("/Apartment/CreateRoomItem/", {
                  templateUrl: "Apartment/CreateRoomItem ",
                  controller: "apartmentController"
              })
            .when("/Billings/Create/", {
                templateUrl: "Billings/Create",
                controller: "apartmentController"
            })
                	.when("/Billings/Create/:Id", {
                	    templateUrl: "Billings/Create",
                	    controller: "billingController"
                	})
           .when("/Payments/Create/", {
               templateUrl: "Payments/Create",
               controller: "apartmentController"
           })
            .when("/Payments/Create/:Id", {
                templateUrl: "Payments/Create",
                controller: "paymentController"
            })
           .when("/Booking/Create/:Id", {
               templateUrl: "Booking/Create",
               controller: "bookingController"
           })
              .when("/MoveIn/MoveInList/:Id", {
                  templateUrl: "MoveIn/MoveInList",
                  controller: "bookingController"
              })
		.when("/order/create/:clientId", {
			templateUrl: "order/create",
			controller: "orderCreateController"
		})

		.when("/order/edit/:id", {
			templateUrl: "order/edit",
			controller: "orderEditController"
		})
		.when("/order/edititems/:id", {
			templateUrl: "order/edititems",
			controller: "orderItemsEditController"
		})
		.when("/order/show/:id", {
			templateUrl: "order/show",
			controller: "orderShowController"
		})
        	.when("/Account/Login", {
        	    templateUrl: "Account/Login",
        	    controller: "LoginCtrl"
        	})
        .when("/LandLord/ApartmentList", {
            templateUrl: "LandLord/ApartmentList",
            controller: "apartmentListController"
        })
          .when("/LandLord/ApartmentList/:Id", {
              templateUrl: "LandLord/ApartmentList",
              controller: "apartmentListController"
          })
             .when("/Upload/Index", {
                 templateUrl: 'app/views/upload.html',
                 controller: "UploadCtrl"
             })
             .when("/Gallery/Index", {
                 templateUrl: 'Gallery/Index',
                 controller: "UploadCtrl"
             })
          .when("/Home/About", {
              templateUrl: 'Home/About',
              controller: "myController"
          })
             .when("/Gallery/Delete/:id", {
                 templateUrl: "Gallery/Index"

             })
           .when("/Gallery/Index/:Id", {
               templateUrl: "Gallery/Index",
               controller: "UploadCtrl"
           })

           
		.otherwise({
		    templateUrl: "home/Index",
		    controller: "clientListController"
		});
});



upida.settings.baseUrl = "http://shop.betway.ug/";
 //$upida.settings.baseUrl = "http://localhost:49193/";
