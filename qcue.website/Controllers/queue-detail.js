function QueueDetailController($scope, $routeParams, $log, angularFire, angularFireCollection) {

    var ref = new Firebase("https://qcue-live.firebaseio.com/queues/" + $routeParams.id);
    $scope.queue = null;
    angularFire(ref, $scope, "queue");

    $scope.$watch('queue', function (newQueueValue, oldQueueValue) {
        if (newQueueValue) {
            for (var key in newQueueValue.users) {
                $scope.$watch('queue.users["'+key+'"].status', function (newVal, oldVal) {
                    if (newVal != oldVal && newVal == 'servicing') {
                        var user = $scope.queue.users[key];

                        var url = new Firebase("https://qcue-live.firebaseio.com/users/" + user.userId);
                        var randomReturn = angularFireCollection(url, function (fullUserDetails) {
                            if (fullUserDetails.val()) {
                                speak(fullUserDetails.val().fullName + 'someone is now next in the queue.');
                            }
                        });
                    }
                });
            }
        }
    });
}