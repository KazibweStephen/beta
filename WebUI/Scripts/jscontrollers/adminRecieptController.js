angularExample.app.controller(
		"adminRecieptController",
		["$scope", "$location", "$routeParams", "upida", function ($scope, $location, $routeParams, upida) {

		    $scope.Reciepts = [];

		    $scope.loadReciepts = function (date) {

		        upida.get("Recept/GetDailyReciepts/"+date, $scope)
                .then(function (items) {
                    $scope.Reciepts = items;

                });
		    };



		}]);