function loadUploadModals(token, areaName) {
    //import { setDates } from './setDates.js';
    var json = { areaName: areaName };
    $('#btn-upload-document').click(function () {
        var modalPlaceholder = $('#modal-document-placeholder');
        $.ajax({
            url: '/loadDocUpload',
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                modalPlaceholder.html(response);
                modalPlaceholder.find('.modal').modal('show');
            }
        })
    });

    $('#btn-upload-agreement').click(function () {
        $.ajax({
            url: '/loadAgrUpload',
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                $('#agrModalBody').html(response);
            }
        })
    });
}