angularExample.app.controller('popupController', function ($scope, $rootScope, ngDialog, upida) {
		    $rootScope.jsonData = '{"foo": "bar"}';
		    $rootScope.theme = 'ngdialog-theme-default';
		    $scope.RecieptId = "6777";
		   
		    $scope.open = function () {
		        ngDialog.open({ template: 'firstDialogId', controller: 'InsideCtrl' });
		    };

		    $scope.openDefault = function (rec) {
		       // alert(rec);
		        window.location.href = ("../../Recept/Details/"+rec);
		        ngDialog.open({
		            template: 'firstDialogId',
		            controller: 'InsideCtrl',
		            className: 'ngdialog-theme-default'
		        });
		    };
		    $scope.openConfirm = function (id) {    
		        ngDialog.openConfirm({
		            template: 'modalDialogId',
		            className: 'ngdialog-theme-default',
		            Text: id,
		        }).then(function (value) {
		            console.log('Modal promise resolved. Value: ', value);
		            $scope.CancelReciepts(id);
		        }, function (reason) {
		            console.log('Modal promise rejected. Reason: ', reason);
		        });
		    };
		    $scope.CancelReciepts= function (id) {	      
		        upida.get("Recept/CancelReciept/"+id, $scope)
             .then(function () {
                 alert("Receipt was Canceled successfull");
                 window.location.href = ("../../Recept/Index");
             });
		        
		    }

		    $scope.openPlain = function () {
		        $rootScope.theme = 'ngdialog-theme-plain';

		        ngDialog.open({
		            template: 'firstDialogId',
		            controller: 'InsideCtrl',
		            className: 'ngdialog-theme-plain',
		            closeByDocument: false
		        });
		    };

		    $scope.openInlineController = function () {
		        $rootScope.theme = 'ngdialog-theme-plain';

		        ngDialog.open({
		            template: 'withInlineController',
		            controller: ['$scope', '$timeout', function ($scope, $timeout) {
		                var counter = 0;
		                var timeout;
		                function count() {
		                    $scope.exampleExternalData = 'Counter ' + (counter++);
		                    timeout = $timeout(count, 450);
		                }
		                count();
		                $scope.$on('$destroy', function () {
		                    $timeout.cancel(timeout);
		                });
		            }],
		            className: 'ngdialog-theme-plain'
		        });
		    };

		    $scope.openTemplate = function () {
		        $scope.value = true;

		        ngDialog.open({
		            template: 'externalTemplate.html',
		            className: 'ngdialog-theme-plain',
		            scope: $scope
		        });
		    };

		    $scope.openTimed = function () {
		        var dialog = ngDialog.open({
		            template: '<p>Just passing through!</p>',
		            plain: true,
		            closeByDocument: false,
		            closeByEscape: false
		        });
		        setTimeout(function () {
		            dialog.close();
		        }, 2000);
		    };

		    $scope.openNotify = function () {
		        var dialog = ngDialog.open({
		            template: '<p>You can do whatever you want when I close, however that happens.</p>' +
						'<div class="ngdialog-buttons"><button type="button" class="ngdialog-button ngdialog-button-primary" ng-click="closeThisDialog(1)">Close Me</button></div>',
		            plain: true
		        });
		        dialog.closePromise.then(function (data) {
		            console.log('ngDialog closed' + (data.value === 1 ? ' using the button' : '') + ' and notified by promise: ' + data.id);
		        });
		    };

		    $rootScope.$on('ngDialog.opened', function (e, $dialog) {
		        console.log('ngDialog opened: ' + $dialog.attr('id'));
		    });

		    $rootScope.$on('ngDialog.closed', function (e, $dialog) {
		        console.log('ngDialog closed: ' + $dialog.attr('id'));
		    });

		});