function JoinQueueController($scope, $routeParams, $http, $log, angularFire) {
    var queue = null;

    $http.get('/api/queues/' + $routeParams.shortCode).success(function (returnedQueue) {
        queue = returnedQueue;
    })
    .error(function () {
        $log.error('the api errored');
    });

    $scope.queue = queue;

    $scope.queueMe = function () {
        var newUser = $scope.new;

        $scope.path("/queue-details?id=" + queue);
    };
}