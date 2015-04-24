define(function () {
    return {
        pageHeading: "Welcome!",
        pageDescription: "This website is still a work in progress...",
        activate: function () {
            ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
        }
    };
});