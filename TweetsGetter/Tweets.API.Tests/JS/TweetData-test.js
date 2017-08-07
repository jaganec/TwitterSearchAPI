describe('Testing factory method ', function () {

    var service, httpBackend, data;

    beforeEach(module('Tweet'));

    beforeEach(inject(function (TweetData, _$httpBackend_) {
        service = TweetData;
        httpBackend = _$httpBackend_;
    }));

    it('should be loaded', function () {
        expect(service).toBeDefined();
    });

    it('should return get data when calling getData', function () {
        httpBackend.expectGET('/api/websearches').respond('some data');

        service.getData().then(function (result) {
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

