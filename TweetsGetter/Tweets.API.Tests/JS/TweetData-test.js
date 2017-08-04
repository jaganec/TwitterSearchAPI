describe('Testing services with $http dependency', function () {

    var service, httpBackend, data;

    beforeEach(module('Tweets'));

    beforeEach(inject(function (testService, _$httpBackend_) {
        service = testService;
        httpBackend = _$httpBackend_;
    }));

    it('should be loaded', function () {
        expect(service).toBeDefined();
    });

    it('should return get data when calling getData', function () {
        httpBackend.expectGET('/api/websearches').respond('some data');

        service.getData(1).then(function (result) {
            data = result;
        });

        httpBackend.flush();

        expect(data).toBe('some data');
    });

    afterEach(function () {
        // make sure all requests where handled as expected.
        httpBackend.verifyNoOutstandingRequest();
        httpBackend.verifyNoOutstandingExpectation();
    });
});

