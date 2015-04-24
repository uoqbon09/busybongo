define(function () {
    return {
        pageHeading: "About",
        pageDescription : "",
        activate: function () {
            ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
        }
    };
});