var $ws = $ws || {};

$ws.utilities = (function () {

    save = function (url, data, ajaxSuccess, ajaxError) {
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            url: url,
            data: data,
            dataType: 'json',
            type: 'POST',
            success: ajaxSuccess,
            error: ajaxError
        });
    };

    get = function (url, ajaxSuccess, ajaxError) {
        $.ajax({
            cache: false,
            url: url,
            dataType: 'json',
            type: 'GET',
            success: ajaxSuccess,
            error: ajaxError
        });
    };

    getHtml = function (url, ajaxSuccess, ajaxError) {
        $.ajax({
            cache: false,
            url: url,
            dataType: 'html',
            type: 'GET',
            success: ajaxSuccess,
            error: ajaxError
        });
    };

    getQueryStrings = function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    };

    return {
        save: save,
        get: get,
        getHtml: getHtml,
        querystrings: getQueryStrings
    };
}());