function uploadModalsGet(token, json) {
    const placeholderDocument = $('#modal-placeholder-document');
    const placeholderAgreement = $('#modal-placeholder-agreement');

    $(document).on('click', '#btn-upload-document', function (event) {
        $.get({
            url: '/loadDocUpload',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderDocument.html(data);
            placeholderDocument.find('.modal').modal('show');
        });
    });

    $(document).on('click', '#btn-upload-agreement', function (event) {
        $.get({
            url: '/loadAgrUpload',
            data: json,
            contentType: 'application/json; charset=utf-8',
            headers: { 'X-CSRF-TOKEN': token },
        }).done(function (data) {
            placeholderAgreement.html(data);
            placeholderAgreement.find('.modal').modal('show');
        });
    });
}

