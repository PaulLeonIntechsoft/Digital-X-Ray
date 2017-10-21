function alterClassRemove() {
    var windowWidth = $(window).width();
    if (arguments.length === 3) {
        $(arguments[1]).removeClass(arguments[2]);
        if (windowWidth < arguments[0]) {
            $(arguments[1]).removeClass(arguments[2]);
        } else {
            $(arguments[1]).addClass(arguments[2]);
        }
    } else if (arguments.length === 4) {
        $(arguments[2]).removeClass(arguments[3]);
        if (windowWidth > arguments[0] && windowWidth < arguments[1]) {
            $(arguments[2]).removeClass(arguments[3]);
        } else {
            $(arguments[2]).addClass(arguments[3]);
        }
    }
}

function alterClassAdd() {
    var windowWidth = $(window).width();
    if (arguments.length === 3) {
        $(arguments[1]).removeClass(arguments[2]);
        if (windowWidth < arguments[0]) {
            $(arguments[1]).addClass(arguments[2]);
        } else {
            $(arguments[1]).removeClass(arguments[2]);
        }
    } else if (arguments.length === 4) {
        $(arguments[2]).removeClass(arguments[3]);
        if (windowWidth > arguments[0] && windowWidth < arguments[1]) {
            $(arguments[2]).addClass(arguments[3]);
        } else {
            $(arguments[2]).removeClass(arguments[3]);
        }
    }
}