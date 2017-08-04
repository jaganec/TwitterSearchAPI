'use strict';
angular
    .module('Tweets')
    .factory('TweetData', factory);

function factory($http) {
    var service = {
        get: get,
       
    };
    return service;
    function get() {
        return $http({ method: 'GET', url: SERVICE_BASE + '/api/websearches' })
            .then(function (response) {
                return response.data;
            });

    }   

}
