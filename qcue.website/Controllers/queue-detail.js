function QueueDetailController($scope, $routeParams, angularFire) {
    var ref = new Firebase('https://qcue-live.firebaseio.com/queues/' + $routeParams.id);
    $scope.queue = null;
    angularFire(ref, $scope, "queue");
}