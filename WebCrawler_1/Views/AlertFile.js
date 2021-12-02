$(function () {
    $(".control-label").hover(function (event) {
        alert(event.pageX);
        event.preventDefault();
    });
});