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
        search(t.val(), "/Orders/search?query=", 'tbody', '#orders-template', 'status', function (status) {
            switch (status) {
                case OrderStatuses.OPEN:
                    return "פתוח";
                    break;
                case OrderStatuses.WAITING:
                    return "ממתין לטיפול";
                    break;
                case OrderStatuses.IN_PROCESS:
                    return "בטיפול";
                    break;
                case OrderStatuses.CLOSE:
                    return "סגור";
                    break;
            }
        })
    });
});