// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    // for fav
    $(".fa-shopping-basket").toggleClass("fav");
    $(".fa-shopping-basket").click(function () {
        $(this).toggleClass("fav");
    });
    // flop
    $(".quick-detail").click(function () {
        id = ".product#p" + $(this).attr("data");
        $(id).toggleClass("flip");
    });
});
