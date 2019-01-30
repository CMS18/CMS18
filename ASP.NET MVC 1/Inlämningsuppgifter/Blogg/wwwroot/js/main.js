

var overlay = document.getElementById('overlay');
var closeMenu = document.getElementById('close-menu');

document.getElementById('open-menu').addEventListener('click', function () {
    overlay.classList.add('show-menu');
});
document.getElementById('close-menu').addEventListener('click', function () {
    overlay.classList.remove('show-menu');
    overlay.classList.add('close-menu');
    
});
$(function () {
    $("#blog").click(function () {
        $("#content").fadeOut(200, function () {
            $(this).html("blog").fadeIn(200);
        });
    });
});
$(function () {
    $("#shop").click(function () {
        $("#content").fadeOut(200, function () {
            $(this).html("webshop").fadeIn(200);
        });
    });
});
$(function () {
    $("#home").click(function () {
        $("#content").fadeOut(200, function () {
            $(this).html("home").fadeIn(200);
        });
    });
});
$(function () {
    $("#about").click(function () {
        $("#content").fadeOut(200, function () {
            $(this).html("about me").fadeIn(200);
        });
    });
});
$(function () {
    $("#contact").click(function () {
        $("#content").fadeOut(200, function () {
            $(this).html("contact").fadeIn(200);
        });
    });
});