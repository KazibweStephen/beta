angularExample.app.controller(
		"SecondModalCtrl",
		["$scope", "$location", "$routeParams", "upida", "ngDialog", function ($scope, $location, $routeParams, upida, ngDialog) {

		    $scope.closeSecond = function () {
		        ngDialog.close();
		    };


		}]);