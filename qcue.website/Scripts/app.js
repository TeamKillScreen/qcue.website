angular.module('app', ['ngRoute', 'ngAnimate', 'firebase'])
    .config(function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: 'views/home.html', controller: HomeController }).
            when('/home', { templateUrl: 'views/home.html', controller: HomeController }).
            when('/about', { templateUrl: 'views/about.html', controller: AboutController }).
            when('/contact', { templateUrl: 'views/contact.html', controller: ContactController }).
            when('/queue-detail', { templateUrl: 'views/queue-detail.html', controller: QueueDetailController }).
            when('/join-queue', { templateUrl: 'views/join-queue.html', controller: JoinQueueController })
        ;
    });

AppCntl.$inject = ['$scope', '$route']
function AppCntl($scope, $route, angularFire) {
    $scope.$route = $route;
}