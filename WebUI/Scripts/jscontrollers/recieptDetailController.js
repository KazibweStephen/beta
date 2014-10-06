angularExample.app.controller(
		"recieptDetailController",
		["$scope", "$location", "$routeParams", "upida", function ($scope, $location, $routeParams, upida) {

		    $scope.Reciepts = [];

		    $scope.loadReciepts = function (id) {
		        upida.get("Recept/RecieptData/" + id, $scope)
                .then(function (items) {
                    $scope.Reciepts = items;

                });
		    };



		}]);