angularExample.app.controller(
		"userStatementController",
		["$scope", "$location", "$routeParams", "upida", function ($scope, $location, $routeParams, upida) {

		    $scope.statements = [];
		    $scope.loadReciepts = function (id) {
		 
		        upida.get("Manager/UserStatement/" + id, $scope)
                .then(function (items) {
                    $scope.statements = items;
                    console.log($scope.statements);

                });
		    };


		   
		}]);