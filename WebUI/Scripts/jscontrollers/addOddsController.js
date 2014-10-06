angularExample.app.controller(
		"addOddsController",
		["$scope", "$location", "$routeParams", "upida", function ( $scope, $location, $routeParams, upida) {
		  
		    $scope.loadMatch = function (id) {
		  
		        $scope.MatchNo = id;
		   
		    };
		    $scope.addodds = function (id) {
		        var item = {};
		        alert(id);
		           item.Mat= $scope.MatchNo;
		            item.oddFT1 = $scope.FT1;
		            item.oddFTX = $scope.FTX;
		            item.oddFT2 = $scope.FT2;
		            
		            item.oddHT1 = $scope.HT1;
		            item.oddHTX = $scope.HTX;
		            item.oddHT2 = $scope.HT2;
		            
		            item.odd1X = $scope.DC1X;
		            item.oddX2= $scope.DCX2;
		            item.odd12 = $scope.DC12;
		            item.oddHC1 = $scope.HC1;
		            item.oddHCX = $scope.HCX;
		            item.oddHC2 = $scope.HC2;
		            item.HomeGoal = $scope.HomeGoal;
		            item.AwayGoal= $scope.AwayGoal;
		            item.oddHtUnder05 = $scope.oddHtUnder05;	         
		            item.oddHtOver05 = $scope.oddHtOver05;
		            item.oddHtOver15  =$scope.oddHtOver15;
		            item.oddHtUnder15  =$scope.oddHtUnder15;
		            item.oddHtOver25 = $scope.oddHtOver25;
		            item.oddHtUnder25 = $scope.oddHtUnder25;
		            item.oddHtOver35 =  $scope.oddHtOver35;
		            item.oddHtUnder35 = $scope.oddHtUnder35;           
		            item.oddFtUnder05 = $scope.FTUNDER05;
		            item.oddFtOver05 = $scope.FTOVER05;
		            item.oddFtUnder15 = $scope.FTUNDER15;
		            item.oddFtOver15 = $scope.FTOVER15;
		            item.oddFtUnder25 = $scope.FTUNDER25;
		            item.oddFtOver25 = $scope.FTOVER25;
		            item.oddFtOver35 = $scope.FTOVER35;
		            item.oddFtUnder35 = $scope.FTUnder35;
		            item.oddFtUnder45 = $scope.FTUNDER45;
		            item.oddFtOver45 = $scope.FTOVER45;
		            item.oddFtOver55 = $scope.FTOVER55;
		            item.oddFtUnder55 = $scope.FTUNDER55;
		            item.oddGG= $scope.GG;
		            item.oddNG = $scope.NG;
		            alert($scope.FTOVER35);
		         
		            upida.post("Fixture/AddOdd", item, $scope)
             .then(function () {
            
                 window.location.href = ("../../Match/Fixtures");
              
             });
		       
		    };
		    $scope.Users = null;

		
		
		}]);