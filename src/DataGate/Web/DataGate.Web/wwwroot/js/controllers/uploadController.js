function loadUploadModals(token, areaName) {
    //import { setDates } from './setDates.js';
    const json = { areaName: areaName };
    $('#btn-upload-document').click(function () {
        const modalPlaceholder = $('#modal-body-document');
        $.ajax({
            url: '/loadDocUpload',
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                modalPlaceholder.html(response);
            }
        })
    });

    $('#btn-upload-agreement').click(function () {
        const modalPlaceholder = $('#modal-body-agreement');
        $.ajax({
            url: '/loadAgrUpload',
            type: 'GET',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
            success: function (response) {
                modalPlaceholder.html(response);
            }
        })
    });
}