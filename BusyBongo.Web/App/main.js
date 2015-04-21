requirejs.config({
    baseUrl: "/App",
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', ko);

define(['durandal/app', 'durandal/viewLocator'],
	function (app, viewLocator) {
	    //>>excludeStart("build", true);
	    //system.debug(false);
	    //>>excludeEnd("build");

	    app.title = 'theBusyBongo';

	    app.configurePlugins({
	        router: true,
	        dialog: true,
	        widget: true,
	        observable: true
	    });

	    app.start().then(function () {
	        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
	        //Look for partial views in a 'views' folder in the root.
	        viewLocator.useConvention();

	        ////Show the app by setting the root view model for our application with a transition.
	        app.setRoot('viewmodels/shell', 'entrance');
	    });
	});