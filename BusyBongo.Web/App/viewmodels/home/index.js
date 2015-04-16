define(['plugins/router','durandal/system'], function (router, sys) {   
    return {
        convertRouteToHash: router.convertRouteToHash,

        activate: function () {
            self = this;
           
            sys.log('*** soon...');
        }    
    }
})