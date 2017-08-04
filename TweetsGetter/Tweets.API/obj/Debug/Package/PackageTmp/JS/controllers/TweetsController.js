'use strict';
angular.module('Tweets', [
    'auth0'])
    .controller('TweetsController', function ($scope, auth, $location, store, $timeout, TweetData) {
        $scope.tweets = [] ;
        $scope.auth = auth;

        $scope.viewTweet = function () {
            TweetData.get().then(function (data) {
                $scope.tweets = data;
            }, function () {
                alert("Error getting users");
                });

            $timeout(function () {
                $scope.viewTweet();
            }, 60000)
        }       
       
        $scope.logout = function () {
            auth.signout();
            store.remove('profile');
            store.remove('token');
            store.remove('refreshToken');
            $location.path('/login');
        }

        $scope.viewTweet();   
     

    });