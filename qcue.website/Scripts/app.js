angular.module('app', ['firebase', 'ui.bootstrap'])
    .config(function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: 'views/home.html', controller: HomeController }).
            when('/home', { templateUrl: 'views/home.html', controller: HomeController }).
            when('/about', { templateUrl: 'views/about.html', controller: AboutController }).
            when('/contact', { templateUrl: 'views/contact.html', controller: ContactController });
    });

AppCntl.$inject = ['$scope', '$route']
function AppCntl($scope, $route, angularFire) {
    $scope.$route = $route;
}