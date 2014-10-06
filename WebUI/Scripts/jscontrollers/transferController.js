angularExample.app.controller(
		"transferController",
		["$scope", "$location", "$routeParams", "upida", '$modal', function ($scope, $location, $routeParams, upida, $modal) {

		    // keep watching the change in the filter text
		    $scope.$watch('transType', function (transType) {
		        $scope.transType = transType;
		    });

		    $scope.openDialog = function (size) {


		    };

		    $scope.addTransfer = function () {
		        var item = {};

		        if ($scope.amount > 0) {
		            var transferMessage = "";
		            if ($scope.transType == 'ToAccount') {
		                item.TransType = "To Account";
		                transferMessage = "to account";
		            } else if ($scope.transType == 'FromAccount') {
		                item.TransType = "From Account";
		                transferMessage = "from account";
		            }
		            item.AmountPaid = $scope.amount;
		            item.UserId = $scope.userName;

		            var modalInstance = $modal.open({
		                templateUrl: 'myModalContent.html',
		                controller: 'ModalInstanceCtrl',
		                size: 'sm',
		                resolve: {
		                    items: function () {
		                        return item;
		                    }
		                }
		            });

		            modalInstance.result.then(function (selectedItem) {
		                //$scope.selected = selectedItem;
		                upida.post("Transfers/AddPayment", item, $scope).then(function (response) {
                           if (JSON.stringify(response.Successful) == 'false') {
                               alert(response.Message);
                           } else {
                               alert(response.Message);
                               window.location.href = ("../../Manager/Index");
                           }
                    });
		            }, function () {
		                $log.info('Modal dismissed at: ' + new Date());
		            });


		        }
		        else {
		            alert("Payment should be greater than zero");
		        }
		    };


		    $scope.Users = null;

		    $scope.user = function (UserId) {
		        this.UserId = UserId;

		    };

		    $scope.loadUsers = function () {
		        //  alert("testuser");
		        upida.get("Transfers/getUsers", $scope)
                .then(function (items) {
                    // alert("out");
                    $scope.Users = new Array();
                    angular.forEach(items, function (p, i) {
                        var row = new $scope.user(p.UserId);
                        //alert(p.UserId);
                        $scope.Users.push(row);
                    });
                });
		    };
		}]);

angularExample.app.controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {

    
    $scope.selected = items;

    $scope.ok = function () {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});