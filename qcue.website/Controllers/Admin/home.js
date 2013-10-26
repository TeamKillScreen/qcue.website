function HomeController($scope, angularFire) {
    var ref = new Firebase("https://qcue-live.firebaseio.com/queues");
    $scope.queues = [];
    angularFire(ref, $scope, "queues");
}