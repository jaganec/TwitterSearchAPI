var app = angular.module('Tweet', []);

 app.factory('TweetData', ['$http', function ($http) {    
     return {
         getData: function () {
             return $http.get('/api/websearches')
                 .then(function (result) {
                     return result.data;
                 });
         }
     };
 }]);