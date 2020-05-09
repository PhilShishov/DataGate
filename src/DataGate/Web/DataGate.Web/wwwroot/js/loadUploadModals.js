function loadUploadModals(token, controllerName) {
    //import { setDates } from './setDates.js';
    var json = { controllerName: controllerName };
    $("#btn-upload-document").click(function () {
        $.ajax({
            url: '/loadDocUpload',
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
            url: '/loadAgrUpload',
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