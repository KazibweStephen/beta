angularExample.app.controller(
		"recieptController",
		["$scope", "$location", "$routeParams", "upida", function ($scope, $location, $routeParams, upida) {

		    $scope.Reciepts= [];
		  
		    $scope.loadReciepts = function () {
		     
		        upida.get("Recept/GetReciepts", $scope)
                .then(function (items) {
                    $scope.Reciepts = items;
                   
                });
		    };
		


		}]);