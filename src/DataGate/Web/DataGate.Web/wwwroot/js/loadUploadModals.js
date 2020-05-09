function loadUploadModals(token, controllerName) {
    //import { setDates } from './setDates.js';
    var json = { controllerName: controllerName };
    $("#btn-upload-document").click(function () {
        $.ajax({
            url: '/loadSelectDoc',
            type: "GET",
            data: json,
            contentType: "application/json; charset=utf-8",
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                $('#docModalBody').html(response);
            }
        })
    });

    $("#btn-upload-agreement").click(function () {
        $.ajax({
            url: '/loadSelectAgr',
            type: "GET",
            data: json,
            contentType: "application/json; charset=utf-8",
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                $('#agrModalBody').html(response);
            }
        })
    });
}