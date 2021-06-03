$(function () {
    var search = function (searchQuery, url, elementId, templateId, onKey, runFunc) {
        $.ajax({
            url: url + searchQuery,
        })
            .done(function (data) {

                $(elementId).html('');
                var template = $(templateId).html();

                $.each(data, function (i, val) {
                    var temp = template;

                    $.each(val, function (key, value) {
                        if (key !== onKey) {
                            temp = temp.replaceAll('{' + key + '}', value);
                        } else {
                            temp = temp.replaceAll('{' + key + '}', runFunc(value));
                        }
                    });

                    $(elementId).append(temp);
                });
                console.log(data);
            });
    }

    $('#itemsSearch').keyup(function () {
        var t = $(this);
        search(t.val(), "/Products/search?query=", 'tbody', '#items-template')
    });

    $('#ordersSearch').keyup(function () {
        var t = $(this);
        search(t.val(), "/Orders/search?query=", 'tbody', '#orders-template', 'Status', function (status) {
            switch (status) {
                case 0:
                    return "פתוח";
                    break;
                case 1:
                    return "ממתין לטיפול";
                    break;
                case 2:
                    return "בטיפול";
                    break;
                case 3:
                    return "סגור";
                    break;
            }
        })
    });

    $('#usersSearch').keyup(function () {
        var t = $(this);
        var currentUrlArr = window.location.href.split('/');
        var categoryId = currentUrlArr[currentUrlArr.length - 1];
        search(t.val(), '/Users/Search?query=', 'tbody', '#users-template', 'type', function (type) {
            switch (status) {
                case 0:
                    return "לקוח";
                    break;
                case 1:
                    return "מנהל";
                    break;
            }
        });
    });
});