

$("#open-menu").click(function () {
    $("#overlay").show('slide', { direction: 'left' }, 300, function () {
        $("#close-menu").fadeIn(300);
        $('#navlist li').each(function (fuckThisShit, li) {
            setTimeout(function () {
                $(li).fadeIn(200)
            }, fuckThisShit * 200)
        });
    });
})

$("#close-menu").click(function () {
    $("#close-menu").fadeOut(300);
    $('#navlist li').each(function (fuckThisShit, li) {
        setTimeout(function () {
            $(li).fadeOut(200)
        }, 200)
    });
    $(function () {
        $("#overlay").delay(450).hide('slide', { direction: 'left' }, 300)
    });
});

$('#navlist a').click(function () {
    var menuItem = $(this).attr('id');
    $("#content").fadeOut(300, function () {
        $(this).html(menuItem).fadeIn(300);
        console.log(menuItem);
    });
});

