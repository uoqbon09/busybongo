define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,    
        
        attached: function () {
            $(document).find("footer").show();            
        },

        activate: function () {
            var self = this;
            router.makeRelative({ moduleId: 'viewmodels' });

            router.map([
                { route: ['', 'home/index'], title: 'Home', moduleId: 'home/index', nav: true, hash: "#home/index" },
                { route: ['home/about'], title: 'About', moduleId: 'home/about', nav: true, hash: "#home/about" }
            ])
            .buildNavigationModel();

            return router.activate();
        }
    }   
});