angular.module('app', ['firebase', 'ui.bootstrap'])
    .config(function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: 'views/admin/home.html', controller: HomeController }).
            when('/home', { templateUrl: 'views/admin/home.html', controller: HomeController }).
            when('/queue-detail', { templateUrl: 'views/queue-detail.html', controller: QueueDetailController })
        ;
    });

AppCntl.$inject = ['$scope', '$route']
function AppCntl($scope, $route, angularFire) {
    $scope.$route = $route;
}