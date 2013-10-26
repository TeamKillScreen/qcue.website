function UserController($scope, angularFire) {
    $scope.init = function (userId) {
        var ref = new Firebase("https://qcue-live.firebaseio.com/users/" + userId);
        $scope.user = null;
        angularFire(ref, $scope, "user");
    };
}