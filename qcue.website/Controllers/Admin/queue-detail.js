function QueueDetailController($scope, $routeParams, angularFire) {
    var ref = new Firebase("https://qcue-live.firebaseio.com/queues/" + $routeParams.id);
    $scope.queue = null;
    angularFire(ref, $scope, "queue");

    $scope.holding = function(key)
    {
        var user = $scope.queue.users[key];
        user.status = "holding";
    };

    $scope.servicing = function (key)
    {
        var user = $scope.queue.users[key];
        user.status = "servicing";
    };

    $scope.serviced = function (key)
    {
        var user = $scope.queue.users[key];
        user.status = "serviced";
    };

    $scope.waiting = function (key) {
        var user = $scope.queue.users[key];
        user.status = "waiting";
    };
}