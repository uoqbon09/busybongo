﻿define(['plugins/router', 'durandal/app'], function (router, app) {
    var viewModel = {
        activate: function () {
            var self = this;
            router.makeRelative({ moduleId: 'viewmodels' });

            router.map([
                { route: ['', 'home/index'], title: 'Home', moduleId: 'home/index', nav: true, hash: "#home/index" }
            ])
            .buildNavigationModel()
            .activate({ pushState: true });
            
        }
    }

    return viewModel;
});