var $upida = $upida || {};
$upida.settings = {};
$upida.settings.baseUrl = "/";
$upida.settings.errorLine = "<br />";

$upida.module = angular.module("upidamodule", []);
$upida.module.factory
    ("upida", ["$http", "$q", function ($http, $q) {
    var service = { onBeforeAjax: null, onAfterAjax: null };
    service.$http = $http;


    service.url = function (link) {
 
     
       // link = "http://192.168.2.112/betway.ug/" + link;
       //link= $upida.settings.baseUrl + link;
      //  alert( link);
        return $upida.settings.baseUrl + link;

    };

    service.navigate = function (link) {
        window.location.replace(service.url(link));
    };

    service.getReff = function (id, version) {
        if (!service.isEmpty(id)) {
            return { id: id, version: version };
        }
    };

    service.isEmpty = function (val) {
        return undefined === val || null == val || "" === val;
    };

    service.getDirectPromise = function (data) {
        var deferred = $q.defer();
        deferred.resolve(data);
        return deferred.promise;
    };
    updatePerson = function (person) {
        return $http({
            method: 'PUT',
            url: '/api/LandLord',
            data: person
        });
    };
  
    service.post = function (method, input, $scope) {
        service.ajaxStart();
        var deferred = $q.defer();
        service.$http({
            method: 'POST',
            url: service.url(method),
            data: input
        })
		.success(function (data, status, headers, config) {
		 
		    service.clearErrors($scope);
		    deferred.resolve(data);	  
		    service.ajaxEnd();
		  
		})
		.error(function (data, status, headers, config) {
		    alert(status);
		    deferred.reject();
		    service.ajaxEnd();
		    service.showErrors($scope, data);
		});
        return deferred.promise;
    };

    service.get = function (method, $scope) {
        service.ajaxStart();
        var deferred = $q.defer();
        service.$http({
            method: 'GET',
            url: service.url(method)
            //url: '@Url.Action("getapartments", "LandLord")'
        })
		.success(function (data, status, headers, config) {
		    service.clearErrors($scope);	    
		    deferred.resolve(data);
		    service.ajaxEnd();
		    return deferred.promise();
		  //alert(status+" success");
		})
		.error(function (data, status, headers, config) {
		   alert(status + " failed");
		    deferred.reject();
		    service.ajaxEnd();
		    service.showErrors($scope, data);
		 
		});
        return deferred.promise;
    };

    service.all = function (promises) {
        return $q.all(promises);
    };

    service.ajaxCallCount = 0;

    service.ajaxStart = function () {
        if (0 == service.ajaxCallCount) {
            if (service.onBeforeAjax) service.onBeforeAjax();
        }

        service.ajaxCallCount++;
    };

    service.ajaxEnd = function () {
        service.ajaxCallCount--;
        if (0 == service.ajaxCallCount) {
            setTimeout(function () {
                if (0 == service.ajaxCallCount) {
                    if (service.onAfterAjax) service.onAfterAjax();
                }
            }, 200);
        }
    };

    service.showErrors = function ($scope, fail) {
        if (!$scope) return;
        var errors = new Array();
        errors.main = fail.main;
        angular.forEach(fail.failures, function (p, i) {
            var current = service.find(errors, function (m) { return m.key == p.key; });
            if (current) {
                current.text = current.text + $upida.settings.errorLine + p.text;
            }
            else {
                errors.push(p);
            }
        });
        $scope.$$errors = errors;
    };

    service.clearErrors = function ($scope) {
        if (!$scope) return;
        $scope.$$errors = new Array();
        $scope.$$errors.main = "";
    };

    service.find = function (obsArray, isItemFunc) {
        var foundItem = null;
        angular.forEach(obsArray, function (item, i) {
            if (true == isItemFunc(item)) {
                foundItem = item;
                return;
            }
        });

        return foundItem;
    };

    return service;
}]);

$upida.module.directive("mainerror", function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            scope.$watch('$$errors', function (errors, oldVal) {
                if (!errors) return;
                element.text(errors.main);
            });
        }
    };
});

$upida.module.directive("errorkey", function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            scope.$watch('$$errors', function (errors, oldVal) {
                element.text("");
                if (!errors) return;
                var key = attrs.errorkey;
                if (errors) {
                    for (var i = 0; i < errors.length; i++) {
                        if (key == errors[i].key) {
                            element.html(errors[i].text);
                            break;
                        }
                    }
                }
            });
        }
    };
});