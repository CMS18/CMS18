var utilities = (function () {

    function readCookie(name) {
        name = name + "=";
        var cookieArray = document.cookie.split(';');

        for (var i = 0; i < cookieArray.length; i++) {
            var currentCookie = cookieArray[i];

            while (currentCookie.charAt(0) == ' ') currentCookie = currentCookie.substring(1, currentCookie.length);
            if (currentCookie.indexOf(name) == 0) return currentCookie.substring(name.length, currentCookie.length);
        }
        return null;
    }

    function setCookie(name, value, validdays) {
        var d = new Date();
        //Set the time to exdays from the current date in milliseconds. 1000 milliseonds = 1 second
        d.setTime(d.getTime() + (validdays * 1000 * 60 * 60 * 24));

        //Compose the expiration date
        var expires = "expires=" + d.toGMTString();

        //Set the cookie with value and the expiration date
        window.document.cookie = name + "=" + value + "; " + expires;
    }

    return {
        setcookie: setCookie,
        readcookie: readCookie

    };


})();