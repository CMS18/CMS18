

var overlay = document.getElementById('overlay');
var closeMenu = document.getElementById('close-menu');



//document.getElementById('open-menu').addEventListener('click', function () {
//    overlay.classList.remove('close-menu');
//    overlay.classList.add('show-menu');
//});
//document.getElementById('close-menu').addEventListener('click', function () {
//    overlay.classList.remove('show-menu');
//    overlay.classList.add('close-menu');
//});
$(function () {
    $("#open-menu").click(function () {
        $("#overlay").show('slide', {direction: 'left'}, 300, function () {
                $("#close-menu").fadeIn(300);
                $('#navlist li').each(function (fuckThisShit, li) {
                    setTimeout(function () {
                        $(li).fadeIn(200)
                    }, fuckThisShit * 200)
                });
        });        
    })
})

$(function () {
    $("#close-menu").click(function () {
        $("#close-menu").fadeOut(300);
        $('#navlist li').each(function (fuckThisShit, li) {
            setTimeout(function () {
                $(li).fadeOut(200)}, 200)
        });
        $(function () {
            $("#overlay").delay(450).hide('slide', { direction: 'left' }, 300)
        });
    });
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