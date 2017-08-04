angular.module('Tweets.login', ['auth0'])
.controller('LoginController', function ($scope, auth, $location, store) {
    $scope.login = function() {
        auth.signin({
            authParams: {
                scope: 'openid offline_access'
            }
        }, function (profile, token, access_token, state, refresh_token) {
            store.set('profile', profile);
            store.set('token', token);
            store.set('refreshToken', refresh_token);
            $location.path('/');
        }, function(error) {
            console.log("There was an error", error);
        });
    }
});