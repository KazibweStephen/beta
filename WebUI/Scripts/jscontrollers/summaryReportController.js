angularExample.app.controller(
		"summaryReportController",
		["$scope", "$location", "$routeParams", "upida", function ($scope, $location, $routeParams, upida) {

		    $scope.Summary = [];
		    $scope.BranchSummary = [];
		    $scope.Branches = [];
		    $scope.loadSummary= function () {	     
		        upida.get("Admin/SummaryReports", $scope)
                .then(function (items) {
                   // alert(items);
                    $scope.Summary = items;
                    // console.Write(alert(items));
                    // alert($scope.BranchSummary.totalStake);
                });
		    };
		    $scope.LoadBranches = function () {
		        //alert("Test Branches");
		        upida.get("Admin/BranchDetails/", $scope)
                .then(function (items) {
                 //   alert(items);
                    $scope.Branches = items;
                  //  console.Write(alert(items));
                    // alert($scope.BranchSummary.totalStake);
                });
		    };
		    $scope.BranchReport = function (id) {
		      // alert(id);
		        upida.get("Admin/BranchSummaryReports/"+id, $scope)
                .then(function (items) {
                  //  alert(items);
                    $scope.BranchSummary = items;
                    console.Write(items);
                    // alert($scope.BranchSummary.totalStake);
                });
		    };



		}]);