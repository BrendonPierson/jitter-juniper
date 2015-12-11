(function () {
    angular
        .module("jitter")
        .controller("TestController", TestController);

    function TestController() {
        var vm = this;
        vm.hello = function() {
            $http.get("/api/Test")
                .success(function (data) {
                    vm.test = data;
                })
                .error(function (error) {
                    alert(error.error)
                });
        }
    }
})();