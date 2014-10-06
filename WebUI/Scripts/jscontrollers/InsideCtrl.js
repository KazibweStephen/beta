angularExample.app.controller(
		"InsideCtrl",
		["$scope", "ngDialog", function ($scope, ngDialog) {
		   // alert("test2");
		    $scope.dialogModel = {
		        message: 'message from passed scope'
		    };
		    $scope.openSecond = function () {
		        ngDialog.open({
		            template: '<h3><a href="" ng-click="closeSecond()">Close all by click here!</a></h3>',
		            plain: true,
		            closeByEscape: false,
		            controller: 'SecondModalCtrl'
		        });
		    };



		}]);