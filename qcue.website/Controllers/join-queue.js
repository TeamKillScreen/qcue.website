function JoinQueueController($scope, $location, $routeParams, $http, $log, angularFire) {
    var queue = null;

    $http.get('/api/queues/' + $routeParams.shortCode).success(function (returnedQueue) {
        queue = returnedQueue;
    })
    .error(function () {
        $log.error('the api queue error');
    });

    $scope.queue = queue;

    $scope.queueMe = function () {
        var userId = null;

        // Check if user already exists.
        $http.get('/api/users/' + $scope.new.phonenumber).success(function (returnedUser) {

            // Add user as registered user if not already exists.
            if (returnedUser === "null") {
                // Insert user.
                userId = guid();
                var usersRef = new Firebase('https://qcue-live.firebaseio.com/users/' + userId + '/');
                usersRef.set({ 'fullName': $scope.new.fullname, 'mobile': $scope.new.phonenumber, 'registrationTextSent': 'false' });
            }
            else {
                userId = returnedUser.userId;
            };

            var now = new Date();
            var dateFormatted = now.toISOString().substring(0, 19);

            // Add user to queue.
            var queueRef = new Firebase('https://qcue-live.firebaseio.com/queues/' + queue.queueId + '/users/' + dateFormatted + '/');
            var newQueueUserRef = queueRef.set({ 'status': 'joined', 'userId': userId });
        })
        .error(function () {
            $log.error('the api user error');
        });

        // Now redirect.
        $location.path('/queue-detail');
        $location.search('id=' + queue.queueId);
    };
}

// Generate guid in javascript... seriously?
function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
function guid() {
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
}