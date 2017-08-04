var app = angular.module('Tweets', []);

app.factory('testService', ['$http', function ($http) {
    return {
        getData: function (id) {
            return $http.get('/api/websearches' )
                .then(function (result) {
                    return result.data;
                });
        }
    };
}]);